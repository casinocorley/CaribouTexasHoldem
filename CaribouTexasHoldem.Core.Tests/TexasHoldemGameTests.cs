﻿using System;
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
		public void WhenAskingForPlayersBet()
		{
			//Arrange			
			Dealer dealer = new Dealer{
				Table = new Table{
					Seats = new List<Seat>{
						new Seat { Player = new Player{Name = "Player1"} },
						new Seat { Player = new Player{Name = "Player2"} },
						new Seat { Player = new Player{Name = "Player3"} },
						new Seat { Player = new Player{Name = "Player4"} }
				}}
			};
			//dealer.GiveDealerButtonTo(2);
			//dealer.GiveDealerButtonTo(player1);

			//dealer.PlayerWithButton();
			////Act
			Player currentPlayer1 = dealer.CallsNextPlayer();
			Player currentPlayer2 = dealer.CallsNextPlayer();
			Player currentPlayer3 = dealer.CallsNextPlayer();
			Player currentPlayer4 = dealer.CallsNextPlayer();


			//Assert
			Assert.AreEqual(currentPlayer1.Name, playersAtTable[0].Name, "First Better is chosen by dealer");
			Assert.AreEqual(currentPlayer2.Name, playersAtTable[1].Name, "First Better is chosen by dealer");
			Assert.AreEqual(currentPlayer3.Name, playersAtTable[2].Name, "First Better is chosen by dealer");
			Assert.AreEqual(currentPlayer4.Name, playersAtTable[0].Name, "First Better is chosen by dealer");

		}

		//[TestMethod]
		//public void WhenCheckingThatBettingIsComplete()
		//{
		////Arrange
		//Game TestGame = new Game();
		//List<Better> ListOfBetters = new List<Better>{
		//new Better { Player = new Player(), Bet = 100, HasFolded = false},
		//new Better { Player = new Player(), Bet = 50, HasFolded = true}
		//};


		//Act
		//TestGame.IsRoundOfBetsComplete();


		//Assert
	}

}
