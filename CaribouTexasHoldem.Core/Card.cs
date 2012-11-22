using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaribouTexasHoldem.Core
{
    public enum Rank { Ace, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King }
    public enum Suit { Spade, Heart, Diamond, Club }
    public class Card
    {
        public Card(Rank theRank, Suit theSuit)
        {
            rank = theRank;
            suit = theSuit;
        }
        public Card(string theShortHand)
        {
            char chrRank = theShortHand[0];
            char chrSuit = theShortHand[1];

            switch (chrRank)
            {
                case 'a':
                case 'A': rank = Rank.Ace; break;
                case '2': rank = Rank.Two; break;
                case '3': rank = Rank.Three; break;
                case '4': rank = Rank.Four; break;
                case '5': rank = Rank.Five; break;
                case '6': rank = Rank.Six; break;
                case '7': rank = Rank.Seven; break;
                case '8': rank = Rank.Eight; break;
                case '9': rank = Rank.Nine; break;
                case 't':
                case 'T': rank = Rank.Ten; break;
                case 'j':
                case 'J': rank = Rank.Jack; break;
                case 'q':
                case 'Q': rank = Rank.Queen; break;
                case 'k':
                case 'K': rank = Rank.King; break;
            }
            switch (chrSuit)
            {
                case 's':
                case 'S': suit = Suit.Spade; break;
                case 'h':
                case 'H': suit = Suit.Heart; break;
                case 'd':
                case 'D': suit = Suit.Diamond; break;
                case 'c':
                case 'C': suit = Suit.Club; break;
            }
        }

        public Rank rank { get; set; }
        public Suit suit { get; set; }

        public string ShortHand
        {
            get
            {
                return ShortHandRank.ToString() + ShortHandSuit;
            }
        }

        public char ShortHandRank
        {
            get
            {
                switch (rank)
                {
                    case Rank.Ace: return 'a';
                    case Rank.Two: return '2';
                    case Rank.Ten: return 't';
                    case Rank.Jack: return 'j';
                    case Rank.Queen: return 'q';
                    case Rank.King: return 'k';
                    default: return Convert.ToInt16(rank).ToString()[0];
                }
            }
        }
        public char ShortHandSuit
        {
            get
            {
                switch (suit)
                {
                    case Suit.Spade: return 's';
                    case Suit.Heart: return 'h';
                    case Suit.Diamond: return 'd';
                    case Suit.Club: return 'c';
                    default: throw new NotSupportedException();

                }
            }
        }
    }
}
