namespace BlackJackCheater.ViewModels
{
    public class CheaterUpdatesViewModel : UpdateCardsViewModel
    {
        public int Hand { get; set; }
        public string Message { get; set; }
        public int OverShootCards { get; set; }
        public int SafeCards { get; set; }
    }
}
