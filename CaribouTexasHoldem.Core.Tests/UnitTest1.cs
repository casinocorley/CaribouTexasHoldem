using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace CaribouTexasHoldem.Core.Tests
{
    [TestClass]
    public class UnitTest1
    {
        public void WhiteBoard()
        {
            /* 
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

            // 1. Player join table (dealer and cards)
            var newPlayer = new Player();
            
            var pokerGame = new PokerGame();

            pokerGame.AddPlayer(newPlayer);

        }

        [TestMethod]
        public void Can_Game_Seat_Player()
        {
            // 1. Player join table (dealer and cards)

            // Arrange 
            var newPlayer = new Player();
            var pokerGame = new PokerGame();

            // Act
            pokerGame.AddPlayer(newPlayer);
            
            // Assert
            Assert.IsTrue(pokerGame.Players.Count == 1, "The new player should be at the table");
            Assert.IsTrue(pokerGame.Seats.Find(x => x.SeatedPlayer == newPlayer) != null , "The new player occupied a seat at the table");
        }

    }

    public class Player
    {
    }

    public class PokerGame
    {
        public List<Player> Players 
        {
            get 
            {
                return Seats.Select(x => x.SeatedPlayer).ToList();
            }
        }
        public List<Chair> Seats { get; set; }
        
        public PokerGame()
        {
            Seats = new List<Chair>();
        }

        public void AddPlayer(Player player)
        {
            Seats.Add(new Chair { SeatedPlayer = player });
        }
    }

    public class Chair 
    {
        public Player SeatedPlayer { get; set; }

    }
}
