  namespace Cards
{
    internal class BlackjackGame
    {
        private Deck deck;
        private HumanPlayer player;
        private Dealer dealer;

        public BlackjackGame()
        {
            deck = new Deck();
            player = new HumanPlayer("Player", 100);
            dealer = new Dealer();
        }

        public void Start()
        {
            deck.Reset();
        }

        public void PlayRound(int bet)
        {
            player.ClearHand();
            dealer.ClearHand();

            if (!player.PlaceBet(bet)) throw new InvalidOperationException("Invalid bet.");

            // initial deal
            player.ReceiveCard(deck.DrawCard());
            dealer.ReceiveCard(deck.DrawCard());
            player.ReceiveCard(deck.DrawCard());
            dealer.ReceiveCard(deck.DrawCard());

            // player turn
            player.TakeTurn(deck);

            // dealer turn (only if player not busted)
            if (!player.Hand.IsBusted)
            {
                dealer.TakeTurn(deck);
            }

            DetermineWinner();
        }

        public void DetermineWinner()
        {
            var playerValue = player.Hand.TotalValue;
            var dealerValue = dealer.Hand.TotalValue;

            if (player.Hand.IsBusted)
            {
                player.Lose();
                return;
            }

            if (dealer.Hand.IsBusted)
            {
                player.Win();
                return;
            }

            if (playerValue > dealerValue)
            {
                player.Win();
            }
            else if (playerValue < dealerValue)
            {
                player.Lose();
            }
            else
            {
                player.Push();
            }
        }
    }
}