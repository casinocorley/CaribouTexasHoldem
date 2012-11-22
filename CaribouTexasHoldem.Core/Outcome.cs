using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaribouTexasHoldem.Core
{
    public class Outcome
    {
        public List<Better> Betters { get; set; }
        public List<Winner> Winners { get; set; }
    }
}
