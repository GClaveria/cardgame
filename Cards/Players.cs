namespace Cards
{
    internal abstract class Players
    {
        public Guid Id { get; } = Guid.NewGuid();
        public string Name { get; protected set; }
        public DateTime CreatedAt { get; } = DateTime.UtcNow;

        public int GamesPlayed { get; protected set; }
        public int Wins { get; protected set; }
        public int Losses { get; protected set; }
        public int Score { get; protected set; }

        protected Players() : this("Player") { }

        protected Players(string name)
        {
            Name = string.IsNullOrWhiteSpace(name) ? "Player" : name.Trim();
        }


        public override string ToString() => $"{Name} (Id: {Id}, Score: {Score}, Games: {GamesPlayed}, W/L: {Wins}/{Losses})";
    }
}