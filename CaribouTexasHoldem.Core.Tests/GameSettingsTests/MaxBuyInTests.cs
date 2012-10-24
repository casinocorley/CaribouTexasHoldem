using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CaribouTexasHoldem.Core.Tests.GameSettingsTests
{
    [TestClass]
    public class MaxBuyInTests
    {
        // Happy Path

        [TestMethod]
        public void WhenMaxBuyInIsNotSet()
        {
            // Arrange
            var gameSettings = new CommonGameSettings();

            // Act
            var maxBuyIn = gameSettings.MaxBuyIn;

            // Assert
            Assert.IsTrue(maxBuyIn > 0, "Max Buy-in should be greater than zero");
            Assert.IsTrue(maxBuyIn % 2 == 0, "Max Buy-in should be even");
        }

        [TestMethod]
        public void WhenMaxBuyInIsSetToPositiveNumber()
        {
            // Arrange
            var gameSettings1000 = new CommonGameSettings { MaxBuyIn = 1000 };
            var gameSettings999 = new CommonGameSettings { MaxBuyIn = 999 };

            // Act
            var maxBuyIn1000 = gameSettings1000.MaxBuyIn;
            var maxBuyIn999 = gameSettings999.MaxBuyIn;

            // Assert
            Assert.AreEqual(1000, maxBuyIn1000, "Max Buyin for 1000 should not have changed");
            Assert.AreEqual(999, maxBuyIn999, "Max Buyin for 999 should not have changed");
        }

        // Unhappy Path

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void WhenMaxBuyInIsSetToZero()
        {
            new CommonGameSettings { MaxBuyIn = 0 };
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void WhenMaxBuyInIsSetToNegativeNumber()
        {
            new CommonGameSettings { MaxBuyIn = -10000 };
        }
    }

    
}
