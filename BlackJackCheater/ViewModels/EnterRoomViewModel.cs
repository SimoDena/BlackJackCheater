using System.ComponentModel.DataAnnotations;

namespace BlackJackCheater.ViewModels
{
    public class EnterRoomViewModel
    {
        [Required(ErrorMessage = "Room name is Required!")]
        public string IdMatch { get; set; }

        [Required]
        public string Role { get; set; }
    }
}
