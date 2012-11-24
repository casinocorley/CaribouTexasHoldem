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
				return Fold;
			}
			set
			{
				if (value == true)
				{
					Fold = value;
					Check = false;
					Bet = 0;
				}
				else Fold = value;
			} 
		}		

		public bool Check 
		{
			get
			{
				return Check;
			}
			set
			{
				if (value == true)
				{
					Check = value;
					Fold = false;
					Bet = 0;
				}
				else Check = value;
			}
		}

		public int Bet 
		{
			get { return Bet; }
			set
			{
				Bet = value;
				Fold = false;
				Check = false;
			}
		}

		
	}
}
