﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaribouTexasHoldem.Core
{
    public class Hand : List<Card>
    {
        public List<Card> HeyGimmeTheBestFiveCards
        {
            get
            {
                return new List<Card>();
            }
        }
    }
}
