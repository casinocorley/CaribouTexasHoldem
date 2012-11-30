using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace CaribouTexasHoldem.Core.Tests
{
    [TestClass]
    public class PokerLogicTests
    {
        [TestMethod]
        public void DetermineBestFiveCardHand()
        {
            // Arrange
            var hand1 = new List<Card>() {
                new Card(Rank.Seven, Suit.Club),
                new Card(Rank.Eight, Suit.Diamond),
                new Card(Rank.Jack, Suit.Diamond),
                new Card(Rank.Eight, Suit.Club),
                new Card(Rank.Ace, Suit.Heart),
                new Card(Rank.Queen, Suit.Heart),
                new Card(Rank.Three, Suit.Club),
            };

            // Act
            var fiveCardHand = PokerLogic.DetermineBestFiveCardHand(hand1);
            
            // Assert
            Assert.IsTrue(fiveCardHand.Any(t => t.ShortHand == "8D"), "Expected 8d to be part of the best 5 card hand");
            Assert.IsTrue(fiveCardHand.Any(t => t.ShortHand == "8c"), "Expected 8c to be part of the best 5 card hand");
            Assert.IsTrue(fiveCardHand.Any(t => t.ShortHand == "ah"), "Expected ah to be part of the best 5 card hand");
            Assert.IsTrue(fiveCardHand.Any(t => t.ShortHand == "qh"), "Expected qh to be part of the best 5 card hand");
            Assert.IsTrue(fiveCardHand.Any(t => t.ShortHand == "jd"), "Expected jd to be part of the best 5 card hand");
        }

        [TestMethod]
        public void DoesShortHandWork()
        {
            // Arrange // Act
            var card = new Card("7c");
            var card2 = new Card("ad");
            var card3 = new Card("KC");
            var card4 = new Card("qH");

            // Assert
            Assert.IsTrue(card.suit == Suit.Club, "7c should have the Club suit");
            Assert.IsTrue(card.rank == Rank.Seven, "7c should have the Seven rank");
            Assert.IsTrue(card2.suit == Suit.Diamond, "ad should have the Diamond suit");
            Assert.IsTrue(card2.rank == Rank.Ace, "ad should have the Ace rank");
            Assert.IsTrue(card3.suit == Suit.Club, "KC should have the Club suit");
            Assert.IsTrue(card3.rank == Rank.King, "KC should have the King rank");
            Assert.IsTrue(card4.suit == Suit.Heart, "qH should have the Heart suit");
            Assert.IsTrue(card4.rank == Rank.Queen, "qH should have the Queen rank");

        }

        
    
    }
}
