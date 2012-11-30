using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaribouTexasHoldem.Core
{
    public class Game
    {
        public Outcome GameOutCome { get; set; }
        public List<Better> RoundOfBets { get; set; }
        public bool RoundOfBetsComplete { get; set; }
        public List<Better> Pot { get; set; }
        public Better LastRaiser { get; set; }
		public Table MyTable { get; set; }
		public Dealer MyDealer { get; set; }

		public void Game()
		{
			MyDealer = new Dealer { Table = MyTable };
		}

        private List<Better> AskForBets(List<Player> PlayersAtTable)
        {
            RoundOfBets.Clear();
			Better CurrentBetter;
			if (MyDealer.CurrentDealer == null)
				MyDealer.GiveDealerButtonTo(null);

			while (MyDealer.NextPlayer().Player != LastRaiser.Player)
			{
				CurrentBetter = MyDealer.CallsNextPlayer();
				if (CurrentBetter.Bet > LastRaiser.Bet)
					LastRaiser = CurrentBetter;
				RoundOfBets.Add(CurrentBetter);
				
			}
			
            return RoundOfBets;
        }

        private Better PlayersBet(Player CurrentPlayer)
        {
            Better CurrentBetter = new Better { Player = CurrentPlayer, Bet = 0 };
            //CurrentBetter.Player.PlayerPlacesBet
            return CurrentBetter;
        }

        public void IsRoundOfBetsComplete(Player NextBetter)
        {
            if (RoundOfBets.FindAll(p => p.HasFolded == false).Count() == 1)
            {
                RoundOfBetsComplete = true;
                return;
            }

            if (NextBetter == LastRaiser.Player)
            {
                RoundOfBetsComplete = true;
                return;
            }

            RoundOfBetsComplete = false;
        }
    }
}
