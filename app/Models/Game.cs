using inception.Interfaces;

namespace inception.Models
{
    class Game: IGame
    {
        public IPlayer CurrentPlayer { get; set; }
        public IRoom CurrentRoom { get; set; }

        public Game()
        {
            // Create rooms and exits

        }
    }
}