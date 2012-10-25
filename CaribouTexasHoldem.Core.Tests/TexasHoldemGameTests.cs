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
            new TexasHoldemGame(new CommonGameSettings() {MaxBuyIn = 2, MinBuyIn = 4});
        }

        [TestMethod]
        public void WhenMinBuyInEqualsMaxBuyIn()
        {
            // Arrange, Act
            var game = new TexasHoldemGame(new CommonGameSettings() {MinBuyIn = 6, MaxBuyIn = 6});

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
            new TexasHoldemGame(new CommonGameSettings() {MinBuyIn = 10, BigBlind = 50});
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
    }
}
