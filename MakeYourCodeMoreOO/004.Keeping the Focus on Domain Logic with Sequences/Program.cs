using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _004.Keeping_the_Focus_on_Domain_Logic_with_Sequences
{
    class Program
    {
        private static IPainter FindCheapestPainter(double sqMeters, IEnumerable<IPainter> painters)
        {
            // normal solution to select the cheapest painter
            // this is bad coding style
            // because it is difficult to understand what this code is doing.
            // because it need big time to prove that it works correctly.
            // there is 3 levels of branching

            //our target in this module to remove this loop with something more clean
            double bestPrice = 0;
            IPainter cheapest = null;
            foreach (IPainter painter in painters)
            {
                if (painter.IsAvailable)
                {
                    double price = painter.EstimateCompensation(sqMeters);
                    if (cheapest == null || price < bestPrice)
                    {
                        cheapest = painter;
                    }
                }
            }
            return cheapest;
        }
        static void Main(string[] args)
        {
        }
    }
}
