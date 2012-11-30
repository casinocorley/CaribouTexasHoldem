using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaribouTexasHoldem.Core
{
    public static class PokerLogic
    {
        public static List<Card> DetermineBestFiveCardHand(List<Card> theHand)
        {
            if (Get5ofaKind(theHand) != null)
            {
                
            }

            return new List<Card>();
        }

        /// <summary>
        /// Check if a 5 of a kind is present and return the 5 associated cards.
        /// </summary>
        /// <param name="theHand"></param>
        /// <returns>If no 5 of a kind present, return null</returns>
        public static List<Card> Get5ofaKind(List<Card> theHand)
        {
            foreach(Card aCard in theHand)
            {
                List<Card> aHand = theHand.FindAll(t => t.ShortHandRank == aCard.ShortHandRank);
                if (aHand.Count > 1) return aHand;
            }
            return null;
        }

       

    }
}
