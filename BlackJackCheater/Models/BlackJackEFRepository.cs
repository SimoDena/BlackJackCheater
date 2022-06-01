using System;
using System.Collections.Generic;
using System.Linq;

namespace BlackJackCheater.Models
{
    public class BlackJackEFRepository : IBlackJackRepository
    {
        private readonly BlackJackDbContext context;

        public BlackJackEFRepository(BlackJackDbContext _context)
        {
            context = _context;
        }

        public void CreateMatch(Match match)
        {
            context.Matches.Add(match);
            context.SaveChanges();
        }

        public Card GetCard(string cardName, string idMatch)
        {
            return context.Cards.Where(c => c.Name == cardName && c.IdMatch == idMatch).FirstOrDefault();
        }

        public IEnumerable<Card> GetCards()
        {
            return context.Cards.ToList();
        }

        public Match GetMatch(string idMatch)
        {
            return context.Matches.Find(idMatch);
        }

        public void InsertCardsForMatch(string idMatch, int numberOfDecks)
        {
            List<Card> deck = new List<Card>()
            {
                #region Init
                new Card {Name = "HA", Value = 1, IdMatch = idMatch, Occurences = numberOfDecks},
                new Card {Name = "H2", Value = 2, IdMatch = idMatch, Occurences = numberOfDecks},
                new Card {Name = "H3", Value = 3, IdMatch = idMatch, Occurences = numberOfDecks},
                new Card {Name = "H4", Value = 4, IdMatch = idMatch, Occurences = numberOfDecks},
                new Card {Name = "H5", Value = 5, IdMatch = idMatch, Occurences = numberOfDecks},
                new Card {Name = "H6", Value = 6, IdMatch = idMatch, Occurences = numberOfDecks},
                new Card {Name = "H7", Value = 7, IdMatch = idMatch, Occurences = numberOfDecks},
                new Card {Name = "H8", Value = 8, IdMatch = idMatch, Occurences = numberOfDecks},
                new Card {Name = "H9", Value = 9, IdMatch = idMatch, Occurences = numberOfDecks},
                new Card {Name = "H10", Value = 10, IdMatch = idMatch, Occurences = numberOfDecks},
                new Card {Name = "HJ", Value = 10, IdMatch = idMatch, Occurences = numberOfDecks},
                new Card {Name = "HQ", Value = 10, IdMatch = idMatch, Occurences = numberOfDecks},
                new Card {Name = "HK", Value = 10, IdMatch = idMatch, Occurences = numberOfDecks},
                new Card {Name = "DA", Value = 1, IdMatch = idMatch, Occurences = numberOfDecks},
                new Card {Name = "D2", Value = 2, IdMatch = idMatch, Occurences = numberOfDecks},
                new Card {Name = "D3", Value = 3, IdMatch = idMatch, Occurences = numberOfDecks},
                new Card {Name = "D4", Value = 4, IdMatch = idMatch, Occurences = numberOfDecks},
                new Card {Name = "D5", Value = 5, IdMatch = idMatch, Occurences = numberOfDecks},
                new Card {Name = "D6", Value = 6, IdMatch = idMatch, Occurences = numberOfDecks},
                new Card {Name = "D7", Value = 7, IdMatch = idMatch, Occurences = numberOfDecks},
                new Card {Name = "D8", Value = 8, IdMatch = idMatch, Occurences = numberOfDecks},
                new Card {Name = "D9", Value = 9, IdMatch = idMatch, Occurences = numberOfDecks},
                new Card {Name = "D10", Value = 10, IdMatch = idMatch, Occurences = numberOfDecks},
                new Card {Name = "DJ", Value = 10, IdMatch = idMatch, Occurences = numberOfDecks},
                new Card {Name = "DQ", Value = 10, IdMatch = idMatch, Occurences = numberOfDecks},
                new Card {Name = "DK", Value = 10, IdMatch = idMatch, Occurences = numberOfDecks},
                new Card {Name = "CA", Value = 1, IdMatch = idMatch, Occurences = numberOfDecks},
                new Card {Name = "C2", Value = 2, IdMatch = idMatch, Occurences = numberOfDecks},
                new Card {Name = "C3", Value = 3, IdMatch = idMatch, Occurences = numberOfDecks},
                new Card {Name = "C4", Value = 4, IdMatch = idMatch, Occurences = numberOfDecks},
                new Card {Name = "C5", Value = 5, IdMatch = idMatch, Occurences = numberOfDecks},
                new Card {Name = "C6", Value = 6, IdMatch = idMatch, Occurences = numberOfDecks},
                new Card {Name = "C7", Value = 7, IdMatch = idMatch, Occurences = numberOfDecks},
                new Card {Name = "C8", Value = 8, IdMatch = idMatch, Occurences = numberOfDecks},
                new Card {Name = "C9", Value = 9, IdMatch = idMatch, Occurences = numberOfDecks},
                new Card {Name = "C10", Value = 10, IdMatch = idMatch, Occurences = numberOfDecks},
                new Card {Name = "CJ", Value = 10, IdMatch = idMatch, Occurences = numberOfDecks},
                new Card {Name = "CQ", Value = 10, IdMatch = idMatch, Occurences = numberOfDecks},
                new Card {Name = "CK", Value = 10, IdMatch = idMatch, Occurences = numberOfDecks},
                new Card {Name = "SA", Value = 1, IdMatch = idMatch, Occurences = numberOfDecks},
                new Card {Name = "S2", Value = 2, IdMatch = idMatch, Occurences = numberOfDecks},
                new Card {Name = "S3", Value = 3, IdMatch = idMatch, Occurences = numberOfDecks},
                new Card {Name = "S4", Value = 4, IdMatch = idMatch, Occurences = numberOfDecks},
                new Card {Name = "S5", Value = 5, IdMatch = idMatch, Occurences = numberOfDecks},
                new Card {Name = "S6", Value = 6, IdMatch = idMatch, Occurences = numberOfDecks},
                new Card {Name = "S7", Value = 7, IdMatch = idMatch, Occurences = numberOfDecks},
                new Card {Name = "S8", Value = 8, IdMatch = idMatch, Occurences = numberOfDecks},
                new Card {Name = "S9", Value = 9, IdMatch = idMatch, Occurences = numberOfDecks},
                new Card {Name = "S10", Value = 10, IdMatch = idMatch, Occurences = numberOfDecks},
                new Card {Name = "SJ", Value = 10, IdMatch = idMatch, Occurences = numberOfDecks},
                new Card {Name = "SQ", Value = 10, IdMatch = idMatch, Occurences = numberOfDecks},
                new Card {Name = "SK", Value = 10, IdMatch = idMatch, Occurences = numberOfDecks}
                #endregion
            };

            context.Cards.AddRange(deck);
            context.SaveChanges();
        }

        public void UpdateCard(Card card)
        {
            context.Update(card);
            context.SaveChanges();
        }
    }
}
