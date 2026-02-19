using System;

namespace Cards
{
    internal abstract class Player
    {
        public Guid Id { get; } = Guid.NewGuid();
        public string Name { get; protected set; }
        public Hand Hand { get; }

        public DateTime CreatedAt { get; } = DateTime.UtcNow;

        protected Player() : this("Player") { }

        protected Player(string name)
        {
            Name = string.IsNullOrWhiteSpace(name) ? "Player" : name.Trim();
            Hand = new Hand();
        }

        public void ReceiveCard(Card card)
        {
            if (card is null) throw new ArgumentNullException(nameof(card));
            Hand.AddCard(card);
        }

        public void ClearHand() => Hand.Clear();

        public virtual void ShowHand()
        {
            foreach (var c in Hand.Cards)
            {
                Console.WriteLine($"- {c}");
            }
        }

        public virtual void TakeTurn(Deck deck)
        {
        }

        public override string ToString() => $"{Name} (Id: {Id})";
    }
}