using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

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

        /* Step 0: imaginary code for what we need
        private static IPainter FindCheapestPainterUpdate1(double sqMeters, IEnumerable<IPainter> painters)
        {
            // IEnumerable<IPainter> sequence of set of objects which follow wach other in an order
            // we need something like this:
            // look how below code is so clean, descriptive, close to user requirement
            // but we have problem that we donot have something called "ThoseAvailable", and 
            // donot have something called "withminimum"
            // LINQ can help us to do something like that. 

            return
                painters
                .ThoseAvailable()
                .WithMinimum(painters.EstimateCompensation(sqMeters));
        }
        */

        /* step 1: implement "Those Available"
        private static IPainter FindCheapestPainterUpdate2(double sqMeters, IEnumerable<IPainter> painters)
        {
            // function return boolean called predicate
            // "where" takes a function (called predicate), this function takes object of type IPainter, and return bool
            // "predicate" tells whether the object should be included in the output set, that is when it return true

            return
                painters.Where(painter => painter.IsAvailable).WithMinimum(painters.EstimateCompensation(sqMeters));

            // "where" now acts as "ThoseAvailable" in above code
        }
        */

        static void Main(string[] args)
        {
        }
    }
}
