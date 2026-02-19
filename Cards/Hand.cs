namespace Cards
{
    internal class Hand
    {
        private readonly List<Card> cards;

        public Hand()
        {
            cards = new List<Card>();
        }

        public IReadOnlyList<Card> Cards => cards.AsReadOnly();

        public int CardCount => cards.Count;

        public int TotalValue => BlackJackRules.CalculateHandValue(cards);

        public bool IsBusted => BlackJackRules.IsBusted(TotalValue);

        public bool IsBlackjack => BlackJackRules.IsBlackjack(TotalValue, CardCount);

        public void AddCard(Card card)
        {
            if (card is null) throw new System.ArgumentNullException(nameof(card));
            cards.Add(card);
        }

        public void Clear() => cards.Clear();
    }
}