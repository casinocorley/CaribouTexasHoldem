using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using CaribouTexasHoldem.Core;

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
            var gameSettings = new TexasHoldemGameSettings();

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
            var gameSettings = new TexasHoldemGameSettings
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
            var gameSettings = new TexasHoldemGameSettings();

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
            var gameSettings = new TexasHoldemGameSettings();

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
            // Arrange, Act, Assert
            var gameSettings = new TexasHoldemGameSettings { BigBlind = 99 };
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void WhenBigBlindIsSetToIsZero()
        {
            var gameSettings = new TexasHoldemGameSettings { BigBlind = 0 };
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void WhenBigBlindIsSetToNegativeNumber()
        {
            var gameSettings = new TexasHoldemGameSettings { BigBlind = -1000 };
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void WhenMaxBuyInIsSetToOddNumber()
        {
            // Arrange
            var gameSettings = new TexasHoldemGameSettings { MaxBuyIn = 99 };
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void WhenMaxBuyInIsSetToZero()
        {
            // Arrange
            var gameSettings = new TexasHoldemGameSettings { MaxBuyIn = 0 };
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void WhenMaxBuyInIsSetToNegativeNumber()
        {
            var gameSettings = new TexasHoldemGameSettings { MaxBuyIn = -10000 };
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void WhenMinBuyInIsSetToNegNumber()
        {
            var gameSettings = new TexasHoldemGameSettings { MinBuyIn = -1000 };
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void WhenMinBuyInIsSetToZero()
        {
            var gameSettings = new TexasHoldemGameSettings { MinBuyIn = 0 };
        }
    }

   
}
