using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CaribouTexasHoldem.Core.Tests.GameSettingsTests
{
    [TestClass]
    public class NumOfSeatsTests
    {
        [TestMethod]
        public void WhenNumOfSeatsAreNotSet()
        {
            // Arrange
            var gameSetting = new CommonGameSettings();

            // Act
            var numOfSeats = gameSetting.NumOfSeats;

            //Assert
            Assert.IsTrue(numOfSeats >= 2, "Need two seats to play");
            Assert.IsTrue(numOfSeats <= 22, "There is only so many class");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void WhenNumOfSeatsIsSetTooManySeats()
        {
            new CommonGameSettings {NumOfSeats = 23};
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void WhenNumOfSeatsIsSetToLessThanTwo()
        {
            new CommonGameSettings { NumOfSeats = 1 };
        }
    }
}
