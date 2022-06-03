using BlackJackCheater.Models;
using BlackJackCheater.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BlackJackCheater.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBlackJackRepository blackJackRepository;

        public HomeController(ILogger<HomeController> logger, IBlackJackRepository _blackJackRepository)
        {
            _logger = logger;
            blackJackRepository = _blackJackRepository;
        }

        public ViewResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(EnterRoomViewModel model)
        {
            if (ModelState.IsValid)
            {
                Match matchFromRepo = blackJackRepository.GetMatch(model.IdMatch);
                if (matchFromRepo == null)
                {
                    ModelState.AddModelError("", $"Room named {model.IdMatch} does not exist!");
                    return View();
                }

                if (model.Role == "Cheater")
                {
                    return RedirectToAction("Cheater", new { idMatch = model.IdMatch });
                }

                return RedirectToAction("Helper", new { idMatch = model.IdMatch });
            }

            return View();
        }

        public ViewResult HowTo()
        {
            return View();
        }

        [HttpGet]
        public ViewResult CreateRoom()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateRoom(CreateRoomViewModel model)
        {
            if (ModelState.IsValid)
            {
                Match matchFromRepo = blackJackRepository.GetMatch(model.RoomName);
                if (matchFromRepo != null)
                {
                    ModelState.AddModelError("", $"A Room with the name {model.RoomName} already exists");
                }
                else
                {
                    Match newMatch = new Match()
                    {
                        IdMatch = model.RoomName,
                        CreationTime = DateTime.Now,
                        NumberOfUsers = 1
                    };

                    blackJackRepository.CreateMatch(newMatch);

                    blackJackRepository.InsertCardsForMatch(newMatch.IdMatch, model.Decks);

                    return RedirectToAction("Cheater", new { idMatch = newMatch.IdMatch });
                }

            }

            return View();
        }

        public ViewResult Helper(string idMatch)
        {
            HelperUpdatesViewModel viewModel = new HelperUpdatesViewModel()
            {
                RoomId = idMatch
            };

            return View(viewModel);
        }

        [HttpPost]
        public ViewResult Helper(HelperUpdatesViewModel model)
        {
            Card cardFromRepo = blackJackRepository.GetCard(model.CardName, model.RoomId);
            cardFromRepo.Occurences = cardFromRepo.Occurences - 1;
            blackJackRepository.UpdateCard(cardFromRepo);

            HelperUpdatesViewModel viewModel = new HelperUpdatesViewModel()
            {
                RoomId = model.RoomId
            };
            return View(viewModel);
        }

        [HttpGet]
        public ViewResult Cheater(string idMatch)
        {
            CheaterUpdatesViewModel viewModel = new CheaterUpdatesViewModel()
            {
                RoomId = idMatch
            };

            return View(viewModel);
        }

        [HttpPost]
        public ViewResult Cheater(CheaterUpdatesViewModel model)
        {
            Card cardFromRepo = blackJackRepository.GetCard(model.CardName, model.RoomId);
            cardFromRepo.Occurences = cardFromRepo.Occurences - 1;
            blackJackRepository.UpdateCard(cardFromRepo);

            int sum = model.Hand + cardFromRepo.Value;
            string message = "";
            int nOverShoot = 0;
            int nSafe = 0;

            if (sum > 11)
            {
                blackJackRepository.CountCards(sum, out nOverShoot, out nSafe);
                if (nOverShoot > nSafe)
                {
                    message = "Stand";
                }
                else
                {
                    message = "Hit";
                }
            }

            CheaterUpdatesViewModel viewModel = new CheaterUpdatesViewModel()
            {
                RoomId = model.RoomId,
                Hand = sum,
                Message = message,
                OverShootCards = nOverShoot,
                SafeCards = nSafe
            };

            return View(viewModel);
        }
    }
}
