using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
			Dealer dealer = new Dealer
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

			////Act
			Player currentPlayer1 = dealer.CallsNextPlayer();
			Player currentPlayer2 = dealer.CallsNextPlayer();
			Player currentPlayer3 = dealer.CallsNextPlayer();
			Player currentPlayer4 = dealer.CallsNextPlayer();
			Player currentPlayer5 = dealer.CallsNextPlayer();
			Player currentPlayer6 = dealer.CallsNextPlayer();
			Player currentPlayer7 = dealer.CallsNextPlayer();
			Player currentPlayer8 = dealer.CallsNextPlayer();


			////Assert
			Assert.AreEqual(currentPlayer1.Name, dealer.Table.Seats[1].Player.Name, "Second Better is chosen by dealer");
			Assert.AreEqual(currentPlayer2.Name, dealer.Table.Seats[2].Player.Name, "Third Better is chosen by dealer");
			Assert.AreEqual(currentPlayer3.Name, dealer.Table.Seats[3].Player.Name, "Fourth Better is chosen by dealer");
			Assert.AreEqual(currentPlayer4.Name, dealer.Table.Seats[0].Player.Name, "First Better is chosen by dealer");
			Assert.AreEqual(currentPlayer5.Name, dealer.Table.Seats[1].Player.Name, "Second Better is chosen by dealer");
			Assert.AreEqual(currentPlayer6.Name, dealer.Table.Seats[2].Player.Name, "Third Better is chosen by dealer");
			Assert.AreEqual(currentPlayer7.Name, dealer.Table.Seats[3].Player.Name, "Fourth Better is chosen by dealer");
			Assert.AreEqual(currentPlayer8.Name, dealer.Table.Seats[0].Player.Name, "First Better is chosen by dealer");

		}

		[TestMethod]
		public void WhenAskingForNextPlayerAndBet()
		{
			//Arrange			
			Dealer dealer = new Dealer
			{
				Table = new Table
				{
					Seats = new List<Seat>{
						new Seat { Player = new Player{Name = "Player1", CheckOverride = true} },
						new Seat { Player = new Player{Name = "Player2", CheckOverride = true} },
						new Seat { Player = new Player{Name = "Player3", BetOverride = 10} },
						new Seat { Player = new Player{Name = "Player4", FoldOverride = true} }
					}
				}
			};

			////Act
			Player currentPlayer1 = dealer.CallsNextPlayer();
			Player currentPlayer2 = dealer.CallsNextPlayer();
			Player currentPlayer3 = dealer.CallsNextPlayer();
			Player currentPlayer4 = dealer.CallsNextPlayer();


			//Assert
			//Are the players bets correct
			Assert.IsTrue(currentPlayer1.Bet == 0, "second player's bet is 0");
			Assert.IsTrue(currentPlayer1.Check, "second player checks");
			Assert.IsFalse(currentPlayer1.Fold, "second player doesn't fold");
			Assert.IsTrue(currentPlayer2.Bet == 10, "third player's bet is 0");
			Assert.IsFalse(currentPlayer2.Check, "third player checks");
			Assert.IsFalse(currentPlayer2.Fold, "third player doesn't fold");
			Assert.IsTrue(currentPlayer3.Bet == 0, "fourth player bets 10");
			Assert.IsFalse(currentPlayer3.Check, "fourth player doesn't check");
			Assert.IsTrue(currentPlayer3.Fold, "forth player doesn't fold");
			Assert.IsTrue(currentPlayer4.Bet == 0, "first player doesn't bet");
			Assert.IsTrue(currentPlayer4.Check, "first player doesn't check");
			Assert.IsFalse(currentPlayer4.Fold, "first player folds");

		}

	}

}
