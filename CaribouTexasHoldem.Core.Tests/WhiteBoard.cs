using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaribouTexasHoldem.Core.Tests
{
    public class WhiteBoard
    {
        public void Main()
        {
            /*  1. Create Texas Holdem game
			 *		Big Blind, Small Blind, num of seats, Max and Min buy in
             *  2. Player join table (dealer and cards)
             *  3. Player get a seat (position)
             *  4. Player buy in
             *  5. Blinds are placed
             *  6. 2 x Cards are dealt each player, player can see their own card
             *  7. Betting (folding) 
             *  8. Flop
             *  9. Betting
             * 10. Turn
             * 11. Betting
             * 12. River
             * 13. Betting
             * 14. Showdown
             * 15. Payout
             */

            // 1. Create a new Texas Holdem Game. Use default game settings.
            var game = new TexasHoldemGame(new CommonGameSettings());
        }
    }
}
