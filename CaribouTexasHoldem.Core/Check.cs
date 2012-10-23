using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaribouTexasHoldem.Core
{
    public static class Check
    {
        public static void IsNotZero(int value, string errorMessage)
        {
            if (value == 0)
                throw new ArgumentException(errorMessage);
        }

        public static void IsNotNegative(int value, string errorMessage)
        {
            if (value < 0)
                throw new ArgumentException(errorMessage);
        }

        public static void IsNotOdd(int value, string errorMessage)
        {
            if (value % 2 != 0)
                throw new ArgumentException(errorMessage);
        }
    }
}
