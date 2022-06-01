using System.ComponentModel.DataAnnotations;

namespace BlackJackCheater.ViewModels
{
    public class UpdateCardsViewModel
    {
        [Required]
        public string CardName { get; set; }

        public string RoomId { get; set; }
    }
}
