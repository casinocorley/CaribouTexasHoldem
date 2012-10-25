using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaribouTexasHoldem.Core
{
    public class CommonGameSettings : IGameSettings
    {
        public CommonGameSettings()
        {
            // Set Defaults
            NumOfSeats = 9;
            BigBlind = 1000;
            MaxBuyIn = 200000;
            MinBuyIn = 40000;
        }

        public int NumOfSeats
        {
            get { return _numOfSeats; }
            set
            {
                if (value >= 23)
                    throw new ArgumentOutOfRangeException("Number of seats cannot be set to this value because of the number of cars");

                if(value <= 1)
                    throw new ArgumentOutOfRangeException("Need at least 2 seats to play");

                _numOfSeats = value;
            }
        }

        public int BigBlind 
        {
            get { return _bigBlind; }
            set 
            {
                CheckBigBlind(value);
                _bigBlind = value; 
            } 
        }

        public int LittleBlind 
        { get { return BigBlind / 2; } }

        public int MaxBuyIn 
        {
            get { return _maxBuyIn; }
            set 
            {
                CheckMaxBuyIn(value);
                _maxBuyIn = value; 
            }
        }

        public int MinBuyIn
        {
            get { return _minBuyIn; }
            set 
            {
                CheckMinBuyIn(value);
                _minBuyIn = value;
            }
        }

        private void CheckBigBlind(int bigBlind)
        {
            Check.IsNotZero
                (bigBlind, "Big Blind cannot be 0");

            Check.IsNotNegative
                (bigBlind, "Big Blind cannot be less than zero");

            Check.IsNotOdd
                (bigBlind, "Big Blind cannot be an odd number");
        }

        private void CheckMaxBuyIn(int maxBuyIn)
        {
            Check.IsNotZero
                (maxBuyIn, "Max Buy-in cannot be zero");

            Check.IsNotNegative
                (maxBuyIn, "Max Buy-in cannot be less than zero");
        }

        private void CheckMinBuyIn(int minBuyIn)
        {
            Check.IsNotZero
                (minBuyIn, "Min Buy-in cannot be zero");

            Check.IsNotNegative
                (minBuyIn, "Min Buy-in cannot be less than zero");
        }

        private int _numOfSeats;
        private int _bigBlind;
        private int _maxBuyIn;
        private int _minBuyIn;
    }
}
