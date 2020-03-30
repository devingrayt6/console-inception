using System.Collections.Generic;
using inception.Interfaces;

namespace inception.Services
{
    class GameService: IGameService
    {
        public List<string> Messages { get; set; }
        private IGame _game { get; set; }

        public GameService(string playerName)
        {
            Messages = new List<string>();
            Messages.Add(playerName);
        }
    }
}