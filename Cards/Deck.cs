namespace Cards
{
    internal class Deck
    {
        private readonly List<Card> deck;
        private readonly Random rng = new();
        
        // Makes the deck and shuffles the entire deck at the end
        public Deck()
        {
            deck = new List<Card>(52);
            foreach (Card.Suit s in Enum.GetValues(typeof(Card.Suit)))
            {
                foreach (Card.Rank r in Enum.GetValues(typeof(Card.Rank)))
                {
                    deck.Add(new Card { suit = s, rank = r });
                }
            }
            Shuffle();
        }

        //Cards remaining :)
        public int CardsRemaining => deck.Count;

        // Fisher Yates shuffle or however you spell it idk
        private void Shuffle()
        {
            for (int i = deck.Count - 1; i > 0; i--)
            {
                int j = rng.Next(i + 1);
                var temp = deck[i];
                deck[i] = deck[j];
                deck[j] = temp;
            }
        }

        //Deals a card from the deck
        public Card Deal()
        {
            if (deck.Count == 0) throw new InvalidOperationException("No cards left to deal.");
            var last = deck.Count - 1;
            var c = deck[last];
            deck.RemoveAt(last);
            return c;
        }

        //Clears deck :) :) :) :) 
        public void Clear()
        {
           deck.Clear();
        }
    }

}

   
