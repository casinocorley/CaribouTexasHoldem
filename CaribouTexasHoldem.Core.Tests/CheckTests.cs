using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaribouTexasHoldem.Core.Tests
{
    [TestClass]
    public class IsNotZeroTests
    {
        [TestMethod]
        public void WhenValueIsNotZero()
        {
            // Arrange and Act
            Check.IsNotZero(10, "errorMessage");

            // Assert
            Assert.IsTrue(true, 
                "Should not have thrown an error because the value is valid");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void WhenValueIsZero()
        {
            Check.IsNotZero(0, "errorMessage");
        }
    }

    [TestClass]
    public class IsNotNegativeTests
    {
        [TestMethod]
        public void WhenValueIsNotNegative()
        {
            // Arrange and Act
            Check.IsNotNegative(2, "errorMessage");

            // Assert
            Assert.IsTrue(true, 
                "Should not have thrown an error because this value is valid");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void WhenValueIsNegative()
        {
            Check.IsNotNegative(-1, "errorMessage");
        }
    }

    [TestClass]
    public class IsNotOddTests
    {
        [TestMethod]
        public void WhenValueIsNotOdd()
        {
            // Arrange and Act
            Check.IsNotOdd(2, "errorMessage");

            // Assert
            Assert.IsTrue(true, 
                "Should not have thrown an error because the value is valid");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void WhenValueIsOdd()
        {
            Check.IsNotOdd(3, "errorMessage");
        }
    }
}
