using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaribouTexasHoldem.Core
{
    public class Player : PlayerAction
    {
        public string Name { get; set; }

		public bool FoldOverride { get; set; }
		public bool CheckOverride { get; set; }
		public int BetOverride { get; set; }

		public void TakesAction()
		{
			if (FoldOverride == true)
				Fold = true;
			else if (CheckOverride == true)
				Check = true;
			else Bet = BetOverride;
		}
    }

    
}
