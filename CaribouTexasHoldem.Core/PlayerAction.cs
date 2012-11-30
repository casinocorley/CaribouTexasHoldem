using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaribouTexasHoldem.Core
{
	public class PlayerAction
	{
		public bool Fold {
			get
			{
				return fold;
			}
			set
			{
				if (value == true)
				{
					fold = value;
					check = false;
					bet = 0;
				}
				else fold = value;
			} 
		}		

		public bool Check 
		{
			get
			{
				return check;
			}
			set
			{
				if (value == true)
				{
					check = value;
					fold = false;
					bet = 0;
				}
				else check = value;
			}
		}

		public int Bet 
		{
			get { return bet; }
			set
			{
				bet = value;
				fold = false;
				check = false;
			}
		}

		private bool fold;
		private bool check;
		private int bet;
		
	}
}
