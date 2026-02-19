namespace Cards
{
    internal static class BlackJackRules
    {
        public static IReadOnlyDictionary<Card.Rank, int> Constants { get; } =
            new Dictionary<Card.Rank, int>
            {
                [Card.Rank.Ace]   = 1,
                [Card.Rank.Two]   = 2,
                [Card.Rank.Three] = 3,
                [Card.Rank.Four]  = 4,
                [Card.Rank.Five]  = 5,
                [Card.Rank.Six]   = 6,
                [Card.Rank.Seven] = 7,
                [Card.Rank.Eight] = 8,
                [Card.Rank.Nine]  = 9,
                [Card.Rank.Ten]   = 10,
                [Card.Rank.Jack]  = 10,
                [Card.Rank.Queen] = 10,
                [Card.Rank.King]  = 10
            };

        // Returns value for rank
        public static int GetValue(Card.Rank rank, bool aceHigh = false) =>
            rank == Card.Rank.Ace ? (aceHigh ? 11 : 1) : Constants[rank];

        // Convenience overload for Card instance
        public static int GetValue(Card card, bool aceHigh = false) =>
            card is null ? 0 : GetValue(card.rank, aceHigh);

        // Calculate best hand value
        public static int CalculateHandValue(IEnumerable<Card> cards)
        {
            if (cards is null) return 0;

            var cardList = cards as IList<Card> ?? cards.ToList();

            int nonAceSum = cardList
                .Where(c => c.rank != Card.Rank.Ace)
                .Sum(c => Constants[c.rank]);

            int aceCount = cardList.Count(c => c.rank == Card.Rank.Ace);

            int total = nonAceSum + aceCount;

            if (aceCount > 0 && total + 10 <= 21)
            {
                total += 10;
            }

            return total;
        }

        public static bool IsBusted(int value) => value > 21;

        public static bool IsBlackjack(int value, int cardCount) => value == 21 && cardCount == 2;

        // DealerMustHit overloads: by numeric value and by card collection
        public static bool DealerMustHit(int handValue) => handValue < 17;

        public static bool DealerMustHit(IEnumerable<Card> cards) => DealerMustHit(CalculateHandValue(cards));
    }
}