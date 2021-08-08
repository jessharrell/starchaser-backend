namespace starchaser_api.Models
{
    public class Character
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Health { get; set; }

        public string Bio { get; set; }

        public Planet Homeplanet { get; set; }
    }
}
