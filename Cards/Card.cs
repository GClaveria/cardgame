namespace Cards
{
    internal class Card
    {
        internal enum Suit
        {
            Hearts,
            Diamonds,
            Clubs,
            Spades
        }
        internal enum Rank  
        {
            Ace,
            Two,
            Three,
            Four,
            Five,
            Six,
            Seven,
            Eight,
            Nine,
            Ten,
            Jack,
            Queen,
            King
        }

        public Rank rank;
        public Suit suit;

        // My 2 read-onlys
        public int Value => BlackJackRules.GetValue(this);
        public string DisplayName => $"{rank} of {suit}";

        // ToString() the Displayname so like then it's like actually read-onmy
        public override string ToString() => DisplayName;
    }
}