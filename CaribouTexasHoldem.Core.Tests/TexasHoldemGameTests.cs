using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CaribouTexasHoldem.Core.PlayerActions;

namespace CaribouTexasHoldem.Core.Tests
{
	[TestClass]
	public class TexasHoldemGameTests
	{

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void WhenMinBuyInGreaterThanMaxBuyIn()
		{
			new TexasHoldemGame(new CommonGameSettings() { MaxBuyIn = 2, MinBuyIn = 4 });
		}

		[TestMethod]
		public void WhenMinBuyInEqualsMaxBuyIn()
		{
			// Arrange, Act
			var game = new TexasHoldemGame(new CommonGameSettings() { MinBuyIn = 6, MaxBuyIn = 6 });

			// Assert
			Assert.AreEqual(game.MaxBuyIn, game.MinBuyIn, "The MaxBuyIn should be the same as the MinBuyIn.");
		}

		[TestMethod]
		public void WhenMinBuyInIsLessThanMaxBuyIn()
		{
			// Arrange, Act
			var game = new TexasHoldemGame(new CommonGameSettings() { MinBuyIn = 4, MaxBuyIn = 6 });

			// Assert
			Assert.IsTrue(game.MinBuyIn < game.MaxBuyIn, "The MinBuyIn is allowed to be less than the MaxBuyIn.");
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void WhenMinBuyInLessThanBigBlind()
		{
			new TexasHoldemGame(new CommonGameSettings() { MinBuyIn = 10, BigBlind = 50 });
		}

		[TestMethod]
		public void WhenAddingAPlayerToTheGameASeatIsTaken()
		{
			// Arrange
			var player = new Player();
			var game = new TexasHoldemGame(new CommonGameSettings());

			// Act
			game.AddPlayer(player);
			var addedPlayer = game.Players.ElementAt(0);

			// Assert
			Assert.AreEqual(game.SeatsTaken, 1, "Adding a player should take a seat.");
			Assert.AreSame(addedPlayer, player, "The player should be added to the game.");
		}

		[TestMethod]
		public void WhenAskingForNextPlayer()
		{
			//Arrange			
			Dealer dealer = SimpleDealerAndTable();

			////Act
			Better currentPlayer1 = dealer.CallsNextPlayer();
			Better currentPlayer2 = dealer.CallsNextPlayer();
			Better currentPlayer3 = dealer.CallsNextPlayer();
			Better currentPlayer4 = dealer.CallsNextPlayer();
			Better currentPlayer5 = dealer.CallsNextPlayer();
			Better currentPlayer6 = dealer.CallsNextPlayer();
			Better currentPlayer7 = dealer.CallsNextPlayer();
			Better currentPlayer8 = dealer.CallsNextPlayer();


			////Assert
			Assert.AreEqual(currentPlayer1.Player.Name, dealer.Table.Seats[1].Player.Name, "Second Better is chosen by dealer");
			Assert.AreEqual(currentPlayer2.Player.Name, dealer.Table.Seats[2].Player.Name, "Third Better is chosen by dealer");
			Assert.AreEqual(currentPlayer3.Player.Name, dealer.Table.Seats[3].Player.Name, "Fourth Better is chosen by dealer");
			Assert.AreEqual(currentPlayer4.Player.Name, dealer.Table.Seats[0].Player.Name, "First Better is chosen by dealer");
			Assert.AreEqual(currentPlayer5.Player.Name, dealer.Table.Seats[1].Player.Name, "Second Better is chosen by dealer");
			Assert.AreEqual(currentPlayer6.Player.Name, dealer.Table.Seats[2].Player.Name, "Third Better is chosen by dealer");
			Assert.AreEqual(currentPlayer7.Player.Name, dealer.Table.Seats[3].Player.Name, "Fourth Better is chosen by dealer");
			Assert.AreEqual(currentPlayer8.Player.Name, dealer.Table.Seats[0].Player.Name, "First Better is chosen by dealer");

		}

		[TestMethod]
		public void WhenAskingForNextPlayerAndBet()
		{
			//Arrange			
			var dealer = DealerWithSimpleTable();

			////Act
			Better currentPlayer1 = dealer.CallsNextPlayer();
			Better currentPlayer2 = dealer.CallsNextPlayer();
			Better currentPlayer3 = dealer.CallsNextPlayer();
			Better currentPlayer4 = dealer.CallsNextPlayer();


			//Assert
			//Are the players bets correct
			Assert.IsTrue(currentPlayer1.Player.TakesAction() is CallPlayerAction, "First Player Calls");
			Assert.IsTrue(currentPlayer2.Player.TakesAction() is BetPlayerAction, "Second Player Calls");
			Assert.IsTrue(currentPlayer3.Player.TakesAction() is FoldPlayerAction, "Third Player Calls");
			Assert.IsTrue(currentPlayer4.Player.TakesAction() is CallPlayerAction, "Forth Player Calls");

		}

		public Dealer SimpleDealerAndTable()
		{
			return new Dealer
			{
				Table = new Table
				{
					Seats = new List<Seat>{
						new Seat { Player = new Player{Name = "Player1"} },
						new Seat { Player = new Player{Name = "Player2"} },
						new Seat { Player = new Player{Name = "Player3"} },
						new Seat { Player = new Player{Name = "Player4"} }
				}
				}
			};
		}

		public Dealer DealerWithSimpleTable()
		{
			return new Dealer
			{
				Table = new Table
				{
					Seats = new List<Seat>{
						new Seat { Player = new CallingPlayer{Name = "player1"} },
						new Seat { Player = new CallingPlayer{Name = "player2"} },
						new Seat { Player = new BettingPlayer{Name = "player3"} },
						new Seat { Player = new FoldingPlayer{Name = "player4"} }
					}
				}
			};
		}

		public Dealer DealerWithLastRaiser()
		{
			return new Dealer
			{
				Table = new Table
				{
					Seats = new List<Seat>{
						new Seat { Player = new CallingPlayer{Name = "player1"} },
						new Seat { Player = new CallingPlayer{Name = "player2"} },
						new Seat { Player = new BettingPlayer{Name = "player3"} },
						new Seat { Player = new FoldingPlayer{Name = "player4"} }
					}
				},
				LastRaiser = new Better { Player = new Player(), Bet = 0, HasFolded = false }
			};
		}

		public class FoldingPlayer : Player
		{
			public override IPlayerAction TakesAction()
			{
				return new FoldPlayerAction();
			}
		}
		public class BettingPlayer : Player
		{
			public override IPlayerAction TakesAction()
			{
				return new BetPlayerAction();
			}
		}
		public class CallingPlayer : Player
		{
			public override IPlayerAction TakesAction()
			{
				return new CallPlayerAction();
			}
		}

		[TestMethod]
		public void NextPlayer()
		{
			//Arrange
			Dealer CurrentDealer = DealerWithLastRaiser();

			//Act
			Better nextPlayer1 = CurrentDealer.NextPlayer();
			Better currentPlayer1 = CurrentDealer.CallsNextPlayer();
			Better nextPlayer2 = CurrentDealer.NextPlayer();
			Better currentPlayer2 = CurrentDealer.CallsNextPlayer();
			Better nextPlayer3 = CurrentDealer.NextPlayer();
			Better currentPlayer3 = CurrentDealer.CallsNextPlayer();
			Better nextPlayer4 = CurrentDealer.NextPlayer();
			Better currentPlayer4 = CurrentDealer.CallsNextPlayer();
			Better nextPlayer5 = CurrentDealer.NextPlayer();

			//Assert
			Assert.AreEqual(nextPlayer1, null, "The first Next Player should be null");
			Assert.AreEqual(nextPlayer2.Player, currentPlayer2.Player, "The NextPlayer after player1 should be player2");
			Assert.AreEqual(nextPlayer3.Player, currentPlayer3.Player, "The NextPlayer after player2 should be player3");
			Assert.AreEqual(nextPlayer4.Player, currentPlayer4.Player, "The NextPlayer after player3 should be player4");
			Assert.AreEqual(nextPlayer5.Player, currentPlayer1.Player, "The NextPlayer after player4 should be player1");
		}
	}

}
