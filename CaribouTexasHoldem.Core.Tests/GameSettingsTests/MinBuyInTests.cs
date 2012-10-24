using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CaribouTexasHoldem.Core.Tests.GameSettingsTests
{
    [TestClass]
    public class MinBuyInTests
    {
        // Happy Path

        [TestMethod]
        public void WhenMinBuyInIsNotSet()
        {
            // Arrange
            var gameSettings = new CommonGameSettings();

            // Act
            var minBuyIn = gameSettings.MinBuyIn;

            // Assert
            Assert.IsTrue(minBuyIn > 0, "Min Buy-in should be greater than 0");
        }

        [TestMethod]
        public void WhenMinBuyInIsSetToPositiveNumber()
        {
            // Arrange
            var gameSettings1000 = new CommonGameSettings { MinBuyIn = 1000 };
            var gameSettings999 = new CommonGameSettings { MinBuyIn = 999 };

            // Act
            var minBuyIn1000 = gameSettings1000.MinBuyIn;
            var minBuyIn999 = gameSettings999.MinBuyIn;

            // Assert
            Assert.AreEqual(1000, minBuyIn1000, "Max Buyin for 1000 should not have changed");
            Assert.AreEqual(999, minBuyIn999, "Max Buyin for 999 should not have changed");
        }

        // Unhappy Path

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void WhenMinBuyInIsSetToNegNumber()
        {
            new CommonGameSettings { MinBuyIn = -1000 };
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void WhenMinBuyInIsSetToZero()
        {
            new CommonGameSettings { MinBuyIn = 0 };
        }
    }
}
