using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CaribouTexasHoldem.Core.Tests
{
    [TestClass]
    public class CardTests
    {
        public CardTests()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion
        

        [TestMethod]
        public void TestShortHandCards()
        {
            // Arrange
            Card card1 = new Card(Rank.Ace, Suit.Club);
            Card card2 = new Card(Rank.King, Suit.Diamond);
            Card card3 = new Card(Rank.Queen, Suit.Heart);
            Card card4 = new Card(Rank.Jack, Suit.Spade);
            Card card5 = new Card(Rank.Ten, Suit.Club);
            Card card6 = new Card(Rank.Nine, Suit.Diamond);
            Card card7 = new Card(Rank.Eight, Suit.Heart);
            Card card8 = new Card(Rank.Seven, Suit.Spade);

            //Act

            //Assert
            Assert.AreEqual(card1.ShortHandRank, 'a');
            Assert.IsTrue(card1.ShortHandRank == 'a');
            Assert.IsTrue(card1.ShortHandSuit == 'c');
            Assert.IsTrue(card2.ShortHandRank == 'k');
            Assert.IsTrue(card2.ShortHandSuit == 'd');
            Assert.IsTrue(card3.ShortHandRank == 'q');
            Assert.IsTrue(card3.ShortHandSuit == 'h');
            Assert.IsTrue(card4.ShortHandRank == 'j');
            Assert.IsTrue(card4.ShortHandSuit == 's');
            Assert.IsTrue(card5.ShortHandRank == 't');
            Assert.IsTrue(card5.ShortHandSuit == 'c');
            Assert.IsTrue(card6.ShortHandRank == '9');
            Assert.IsTrue(card6.ShortHandSuit == 'd');
            Assert.IsTrue(card7.ShortHandRank == '8');
            Assert.IsTrue(card7.ShortHandSuit == 'h');
            Assert.IsTrue(card8.ShortHandRank == '7');
            Assert.IsTrue(card8.ShortHandSuit == 's');
        }

        [TestMethod]
        public void TestCardComparison()
        {
            //Arrange
            Card card1 = new Card(Rank.Ace, Suit.Club);
            Card card2 = new Card(Rank.King, Suit.Diamond);
            Card card3 = new Card(Rank.Queen, Suit.Heart);
            Card card4 = new Card(Rank.Jack, Suit.Spade);
            Card card5 = new Card(Rank.Ten, Suit.Club);
            Card card6 = new Card(Rank.Nine, Suit.Diamond);
            Card card7 = new Card(Rank.Eight, Suit.Heart);
            Card card8 = new Card(Rank.Seven, Suit.Spade);
            Card card9 = new Card(Rank.Seven, Suit.Heart);
            //Act

            //Assert
            Assert.IsTrue(card1 > card2);
            Assert.IsTrue(card2 > card3);
            Assert.IsTrue(card8 < card1);
            Assert.IsTrue(card4 < card3);
            Assert.IsTrue(card9 == card8);
            Assert.IsTrue(card5 > card9);


        }
    }

}
