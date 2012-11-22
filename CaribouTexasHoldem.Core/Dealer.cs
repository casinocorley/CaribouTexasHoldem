using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaribouTexasHoldem.Core
{
	public class Dealer
	{
		public Player CurrentDealer { get; set; }
		public Table Table { get; set; }
		public Player PlayerWithButton { get; set; }


		public Player CallsNextPlayer()
		{
			return new Player();
		}
		public Player GiveDealerButtonTo(int? index)
		{
			if (index.HasValue != true)
				PlayerWithButton = Table.Seats[index.Value].Player;
			//else if (player.HasValue == true)
			//	PlayerWithButton = Table.Seats.Find(p => p.Player == player.Value).Player;
			else
			{
				if (Table.Seats.FindIndex(p => p.Player == PlayerWithButton) != Table.Seats.Count() - 1)
					PlayerWithButton = Table.Seats[Table.Seats.FindIndex(p => p.Player == PlayerWithButton) + 1].Player;
			}
			
			if (PlayerWithButton == null)
				PlayerWithButton = Table.Seats.FirstOrDefault().Player;

			return PlayerWithButton;
		}
	}
}
