namespace Cards
{
    internal class HumanPlayer : Player
    {
        public int Chips { get; private set; }
        public int CurrentBet { get; private set; }

        public HumanPlayer() : this("Player", 100) { }

        public HumanPlayer(string name, int startingChips) : base(name)
        {
            Chips = startingChips >= 0 ? startingChips : 0;
            CurrentBet = 0;
        }

        public bool PlaceBet(int amount)
        {
            if (amount <= 0 || amount > Chips) return false;
            CurrentBet = amount;
            Chips -= amount;
            return true;
        }

        public void Win()
        {
            Chips += CurrentBet * 2;
            CurrentBet = 0;
        }

        public void Lose()
        {
            CurrentBet = 0;
        }

        public void Push()
        {
            Chips += CurrentBet;
            CurrentBet = 0;
        }

        public override void TakeTurn(Deck deck)
        {
        }
    }
}