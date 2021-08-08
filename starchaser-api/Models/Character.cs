namespace starchaser_api.Models
{
    public class Character
    {
        public int CharacterId { get; set; }

        public string Name { get; set; }

        public int Health { get; set; }

        public string Bio { get; set; }

        public Planet Planet { get; set; }
    }
}
