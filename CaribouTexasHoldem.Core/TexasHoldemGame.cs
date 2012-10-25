using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaribouTexasHoldem.Core
{
    public class TexasHoldemGame
    {
        private IGameSettings _settings;

        private HashSet<Player> _players; 

        public int MaxBuyIn { get { return _settings.MaxBuyIn; } }

        public int MinBuyIn { get { return _settings.MinBuyIn; } }

        public int SeatsTaken { get; set; }

        public IEnumerable<Player> Players { get {return _players; } }

        public TexasHoldemGame(IGameSettings settings)
        {
            if (settings.MaxBuyIn < settings.MinBuyIn)
            {
                throw new ArgumentException("Cannot have a smaller MinBuyIn than MaxBuyIn.");
            }

            _settings = settings;
            _players = new HashSet<Player>();
        }

        public void AddPlayer(Player player)
        {
            SeatsTaken++;
            _players.Add(player);
        }
    }
}
