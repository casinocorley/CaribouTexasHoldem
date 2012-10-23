using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CaribouTexasHoldem.Core.Tests
{
    [TestClass]
    public class TexasHoldemGameSettingsTests
    {
        public void WhiteBoard()
        {
            /* 1. Texas Holdem game is created
             * 1. Player join table (dealer and cards)
             * 2. Player get a seat (position)
             * 3. Player buy in
             * 4. 2 x Cards are dealt each player, player can see their own card
             * 5. Blinds are placed
             * 6. Betting (folding) 
             * 7. Flop
             * 8. Betting
             * 9. Turn
             * 10. Betting
             * 11. River
             * 12. Betting
             * 13. Determine winner
             * 14. Payout
             */
        }

        // Happy Path

        [TestMethod]
        public void WhenBigBlindIsNotSet()
        {
            // Arrange
            var gameSettings = new GameSettings();

            // Act
            var bigBlind = gameSettings.BigBlind;

            // Assert
            Assert.IsTrue(bigBlind > 0, "Big Blind should be greater zero");
            Assert.IsTrue(bigBlind % 2 == 0, "Big Blind should be an even number");
        }

        [TestMethod]
        public void WhenBigBlindIsSetToEvenPostiveNumber()
        {
            // Arrange
            var gameSettings = new GameSettings
            {
                NumOfPlayers = 9, 
                BigBlind = 1000
            };

            // Act 
            var littleBlind = gameSettings.LittleBlind;

            // Assert
            Assert.AreEqual(500, littleBlind, "Little blind should be half of the Big Blind");
        }

        [TestMethod]
        public void WhenMaxBuyInIsNotSet()
        {
            // Arrange
            var gameSettings = new GameSettings();

            // Act
            var maxBuyIn = gameSettings.MaxBuyIn;

            // Assert
            Assert.IsTrue(maxBuyIn > 0, "Max Buy-in should be greater than zero");
            Assert.IsTrue(maxBuyIn % 2 == 0, "Max Buy-in should be even");
        }

        [TestMethod]
        public void WhenMinBuyInIsNotSet()
        {
            // Arrange
            var gameSettings = new GameSettings();

            // Act
            var minBuyIn = gameSettings.MinBuyIn;

            // Assert
            Assert.IsTrue(minBuyIn > 0, "Min Buy-in should be greater than 0");
        }


        // Unhappy Path

        [TestMethod]
        [ExpectedException(typeof (ArgumentException))]
        public void WhenBigBlindIsSetToOddNumber()
        {
            new GameSettings { BigBlind = 99 };
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void WhenBigBlindIsSetToIsZero()
        {
            new GameSettings { BigBlind = 0 };
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void WhenBigBlindIsSetToNegativeNumber()
        {
            new GameSettings { BigBlind = -1000 };
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void WhenMaxBuyInIsSetToOddNumber()
        {
            new GameSettings { MaxBuyIn = 99 };
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void WhenMaxBuyInIsSetToZero()
        {
            new GameSettings { MaxBuyIn = 0 };
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void WhenMaxBuyInIsSetToNegativeNumber()
        {
            new GameSettings { MaxBuyIn = -10000 };
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void WhenMinBuyInIsSetToNegNumber()
        {
            new GameSettings { MinBuyIn = -1000 };
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void WhenMinBuyInIsSetToZero()
        {
            new GameSettings { MinBuyIn = 0 };
        }
    }

   
}
