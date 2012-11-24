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
		public Player CurrentPlayer { get; set; }


		public Player CallsNextPlayer()
		{
			if (PlayerWithButton == null) PlayerWithButton = GiveDealerButtonTo(null);

			if (CurrentPlayer == null) CurrentPlayer = Table.Seats[Table.Seats.FindIndex(s => s.Player == PlayerWithButton) + 1].Player;
			else if (Table.Seats.Count == Table.Seats.FindIndex(s => s.Player == CurrentPlayer) + 1)
				CurrentPlayer = Table.Seats[0].Player;
			else CurrentPlayer = Table.Seats[Table.Seats.FindIndex(s => s.Player == CurrentPlayer) + 1].Player;

			return CurrentPlayer;
		}
		public Player GiveDealerButtonTo(int? index)
		{
			if (index.HasValue == true)
				PlayerWithButton = Table.Seats[index.Value].Player;
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
