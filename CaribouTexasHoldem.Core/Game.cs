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


        private Game PlayHand(out Outcome GameOutCome, Game CurrentGame)
        {
            GameOutCome = new Outcome();

            return CurrentGame;
        }

        private List<Better> AskForBets(List<Player> PlayersAtTable)
        {
            RoundOfBets.Clear();

            // Need to rewrite so that Round of Bets is checked before the player bets
            while (RoundOfBetsComplete)
            {
                PlayersAtTable.ForEach(p => RoundOfBets.Add(PlayersBet(p)));
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
