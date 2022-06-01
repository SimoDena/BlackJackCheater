using System.ComponentModel.DataAnnotations;

namespace BlackJackCheater.ViewModels
{
    public class CreateRoomViewModel
    {
        [Required(ErrorMessage = "The field \"Room Name\" is required!")]
        [MaxLength(50, ErrorMessage = "The lenght must be lower than 50 chars!")]
        public string RoomName { get; set; }

        [Required(ErrorMessage = "The field \"Number of Decks\" is required!")]
        public int Decks { get; set; }
    }
}
