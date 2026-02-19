namespace Cards
{
    internal class Deck
    {
        private List<Card> cards;
        private readonly Random rng = new();
        
        // Makes the deck and shuffles the entire deck at the end
        public Deck()
        {
            cards = new List<Card>(52);
            foreach (Card.Suit s in Enum.GetValues(typeof(Card.Suit)))
            {
                foreach (Card.Rank r in Enum.GetValues(typeof(Card.Rank)))
                {
                    cards.Add(new Card { suit = s, rank = r });
                }
            }
            Shuffle();
        }

        //Cards remaining :)
        public int CardsRemaining => cards.Count;

        // Fisher Yates shuffle or however you spell it idk
        private void Shuffle()
        {
            for (int i = cards.Count - 1; i > 0; i--)
            {
                int j = rng.Next(i + 1);
                var temp = cards[i];
                cards[i] = cards[j];
                cards[j] = temp;
            }
        }

        //Deals a card from the deck
        public Card DrawCard()
        {
            if (cards.Count == 0) throw new InvalidOperationException("No cards left to deal.");
            var last = cards.Count - 1;
            var c = cards[last];
            cards.RemoveAt(last);
            return c;
        }

        //Clears deck :) :) :) :) 
        public void Reset()
        {
           cards.Clear();
           foreach (Card.Suit s in Enum.GetValues(typeof(Card.Suit)))
           {
               foreach (Card.Rank r in Enum.GetValues(typeof(Card.Rank)))
               {
                   cards.Add(new Card { suit = s, rank = r });
               }
           }
           Shuffle();
        }
    }

}
