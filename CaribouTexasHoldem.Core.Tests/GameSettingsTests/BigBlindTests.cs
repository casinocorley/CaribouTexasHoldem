using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CaribouTexasHoldem.Core.Tests.CommonGameSettingsTests
{
    [TestClass]
    public class BigBlindTests
    {
        // Happy Path

        [TestMethod]
        public void WhenBigBlindIsNotSet()
        {
            // Arrange
            var gameSettings = new CommonGameSettings();

            // Act
            var bigBlind = gameSettings.BigBlind;

            // Assert
            Assert.IsTrue(bigBlind > 0, "Big Blind should be greater zero");
            Assert.IsTrue(bigBlind >= 2, "Big Blind should be greater two");
        }

        [TestMethod]
        public void WhenBigBlindIsSetToEvenPostiveNumber()
        {
            // Arrange
            var gameSettings = new CommonGameSettings
            {
                BigBlind = 1000
            };

            // Act 
            var littleBlind = gameSettings.LittleBlind;

            // Assert
            Assert.AreEqual(500, littleBlind, "Little blind should be half of the Big Blind");
        }


        // Unhappy Path

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void WhenBigBlindIsSetToOddNumber()
        {
            new CommonGameSettings { BigBlind = 99 };
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void WhenBigBlindIsSetToIsZero()
        {
            new CommonGameSettings { BigBlind = 0 };
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void WhenBigBlindIsSetToNegativeNumber()
        {
            new CommonGameSettings { BigBlind = -1000 };
        }
    }
}
