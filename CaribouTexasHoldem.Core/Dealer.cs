using CaribouTexasHoldem.Core.PlayerActions;
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
		public Better LastRaiser { get; set; }
		
		public Better CallsNextPlayer()
		{
			if (PlayerWithButton == null) PlayerWithButton = GiveDealerButtonTo(null);

			if (CurrentPlayer == null)
				CurrentPlayer = Table.Seats[Table.Seats.FindIndex(s => s.Player == PlayerWithButton) + 1].Player;
			else if (Table.Seats.Count == Table.Seats.FindIndex(s => s.Player == CurrentPlayer) + 1)
				CurrentPlayer = Table.Seats[0].Player;
			else 
				CurrentPlayer = Table.Seats[Table.Seats.FindIndex(s => s.Player == CurrentPlayer) + 1].Player;

			return CurrentPlayersAction(AskForAction());
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
		public Better NextPlayer()
		{
			Better SaveMyPlayer = new Better { Player = CurrentPlayer };
			Better NextPlayer = CallsNextPlayer();
			CurrentPlayer = SaveMyPlayer.Player;
			return NextPlayer;
		}
		public IPlayerAction AskForAction()
		{
			return CurrentPlayer.TakesAction();
		}
		private Better CurrentPlayersAction(IPlayerAction PlayersAction)
		{
			if (PlayersAction is FoldPlayerAction)
				return new Better { Player = CurrentPlayer, HasFolded = true, Bet = 0 };
			if (PlayersAction is CallPlayerAction)
				return new Better { Player = CurrentPlayer, HasFolded = false, Bet = LastRaiser.Bet };
			if (PlayersAction is BetPlayerAction)
				return new Better { Player = CurrentPlayer, HasFolded = false, Bet = (PlayersAction as BetPlayerAction).Bet};
			return new Better();
		}
	}
}
