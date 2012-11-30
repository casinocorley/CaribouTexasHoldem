using CaribouTexasHoldem.Core.PlayerActions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaribouTexasHoldem.Core
{
    public class Player
    {
        public string Name { get; set; }
		
		public IPlayerAction TakesAction()
		{
			//if (FoldOverride == true)
			//	Fold = true;
			//else if (CheckOverride == true)
			//	Check = true;
			//else Bet = BetOverride;

			IPlayerAction myActionC = new CallPlayerAction();
			IPlayerAction myActionB = new BetPlayerAction();
			IPlayerAction myActionF = new FoldPlayerAction();
			return myActionC;
		}
    }

    
}
