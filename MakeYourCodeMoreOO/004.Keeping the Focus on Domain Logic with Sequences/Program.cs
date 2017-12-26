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

        /* Step 0: Dream Code
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

        /* step 2: Implement "WithMinimum"
         * function that takes a sequence and return a single value or object (eg minimum, max,..) is called "Aggregate"
         * the returned object may be of same type as the sequence and may be of different type
         * so in above code, "where" statement returns sequence of object implementing "IPainter" interface, and we have to pick
         * one of them (aggregation)         
        */
        private static IPainter FindCheapestPainterUpdate3(double sqMeters, IEnumerable<IPainter> painters)
        {
            // "where" will return list of objects of type "IPainter", and now we need to implement "WithMinimum"
            // "OrderBy" (Sort Sequence) takes a function that takes parameter of type "IPainter", and return "TKey" type.

            // note that, this function will be invoked for each object returned from "where" statement, and will return something of time "TKey"
            // then it will sort these returned "TKey" in an ascending order.
            // so "order by" will return sequence of object order by "tkey" in an ascending order.

            // "firstOrDefault" will return null if no objects found, while "first" will fire exception
            return
                painters
                .Where(painter => painter.IsAvailable)
                .OrderBy(painter => painter.EstimateCompensation(sqMeters))
                .FirstOrDefault();
        }

        /* Step 3: Attack Previous Solution
         * previous solution (sort the sequence and pick the first element) is bad idea
         * because sorting a sequence yields to O(NLogN) running time, where N is the length of the sequence.
         * 
         * Better Idea, pick only required elemnt without need to sort, so we have O(N) running time.
         * check below modification
        */

        /* Step 4: better solution
        */
        private static IPainter FindCheapestPainterUpdate(double sqMeters, IEnumerable<IPainter> painters)
        {
            // the "aggregate" function works by pick the first element as the best one, then the "aggregate" method
            // walks the remaining elements of the sequence. for each element, it calls the aggregate function, passing the current aggregate
            // as the first parameter, and the "sequence" as the second argument, and the result of the function is kept as the new aggregate result

            // finally when all the elements of the sequence is exhausted, aggregate value is returned as the overall result.
            // there 3 difference between below code and for loop used firstly:

            // 1- in below code you will find that "EstimateCompensation" is repeated 2 times, but in first solution, it is called once in each iteration
            // so this solution is less effecient

            // 2- this code will throw exception if the sequence is empty, so we have to make sure that (IEnumerable<IPainter> painters) is not empty
            // and returned sequnece from (where) is not empty.

            // 3- below code is not readable

            // previous solution will return null if there no suitable painter
            return
                painters
                .Where(painter => painter.IsAvailable)
                .Aggregate((best, cur) => best.EstimateCompensation(sqMeters) < cur.EstimateCompensation(sqMeters) ? best : cur);
                
            // simply this code do the following:
                // 1- aggregate asks for a function which recieves 2 objects implementing "IPainter" interface, and return object of IPainter interface
                // 2- it picks the first element of the sequence (from where statetemnt) as the best fit.
                // 3- the aggregate method walks the remaining elements of the sequence, for each element it calls the aggregate function passing the
                // current aggregate as the first argument, and the current element of the sequence(that is selected as best fit) as the second argument
                // 4- the result of the function is kept as the new aggregate result
                // 5- finally when all elements of the sequence are exhausted, the aggregate value is retuned as the over all result
        }
        static void Main(string[] args)
        {
        }
    }
}
