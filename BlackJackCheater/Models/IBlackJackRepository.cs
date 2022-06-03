using System.Collections.Generic;

namespace BlackJackCheater.Models
{
    public interface IBlackJackRepository
    {
        Match GetMatch(string idMatch);
        void CreateMatch(Match match);

        Card GetCard(string cardName, string idMatch);
        void UpdateCard(Card card);
        IEnumerable<Card> GetCards();
        void InsertCardsForMatch(string idMatch, int numberOfDecks);
        void CountCards(int hand, out int nOvershoot, out int nSafe);
    }
}
