namespace Cards
{
    internal class Dealer : Player
    {
        public Dealer() : base("Dealer") { }

        public Dealer(string name) : base(name) { }

        public bool MustHit => BlackJackRules.DealerMustHit(Hand.Cards);

        public override void ShowHand()
        {
            if (Hand.CardCount == 0) return;

            if (Hand.CardCount == 1)
            {
                foreach (var c in Hand.Cards) System.Console.WriteLine($"- {c}");
                return;
            }

            // show first card, hide the rest
            var first = Hand.Cards[0];
            System.Console.WriteLine($"- {first}");
            System.Console.WriteLine("- [hidden]");
        }

        public override void TakeTurn(Deck deck)
        {
            while (BlackJackRules.DealerMustHit(Hand.Cards))
            {
                var drawn = deck.DrawCard();
                ReceiveCard(drawn);
            }
        }
    }
}