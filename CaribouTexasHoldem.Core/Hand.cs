using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaribouTexasHoldem.Core
{
    public class Hand : List<Card>
    {
        private List<Card> _myHand;
        public List<Card> MyHand
        {
            get {
                return _myHand.OrderBy(t => t.ShortHandRank).ToList();
            }
            set { _myHand = value; }
        }


        public Hand GimmeTheBestFiveCards
        {
            get
            {
                return new Hand();
            }
        }
    }
}
