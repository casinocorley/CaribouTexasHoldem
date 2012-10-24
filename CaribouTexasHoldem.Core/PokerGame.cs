using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaribouTexasHoldem.Core
{
    public class TexasHoldemGame
    {
        private CommonGameSettings _settings;

        public List<Player> Players
        {
            get
            {
                return Seats.Select(x => x.SeatedPlayer).ToList();
            }
        }
        public List<Chair> Seats { get; set; }

        public TexasHoldemGame() : this(null)
        {
        }

        public TexasHoldemGame(CommonGameSettings settings)
        {
            settings = _settings;
            Seats = new List<Chair>();
        }

        public void AddPlayer(Player player)
        {
            Seats.Add(new Chair { SeatedPlayer = player });
        }
    }

    public class Chair
    {
        public Player SeatedPlayer { get; set; }

    }
}
