using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeYourCodeMoreOO
{
    class BadCodeSample
    {
        /// <summary>
        /// what is bad with this function ?
        /// - it lacks flexibility
        /// 1- one day your customer may ask you to "Sum up only the odd numbers"
        ///     - so you change function 1 to function 2
        /// 2- then your customer said i want to choose:
        ///     - sum up all numbers or
        ///     - sum only odd numbers
        ///     - so you change function 2 to function 3
        ///     
        /// - this is a BAD way of doing things
        /// - because this solution does not support varying requirements, its complexity will grow as new requirements are added
        /// 
        /// - now we need to pin point the problem -> the truth that it lacks "Dynamic Dispatch" 
        ///   (substite one concrete function implementation to another at run time without disturbing the caller)
        /// - the point that makes our code lacks "Dynamic Dispatch" is the "If Statement" (decision of which number to include is static)
        /// - for every new requirement we will need to change the "IF Condition" for example if he requested "Even" Numbers.
        /// 
        /// - SOLUTION: Makes the decision Dynamic, It Lacks Object
        /// 
        /// - ADVICE: Avoid changing existing code. each change may break a feature which used to work fine.
        /// 
        ///  modification 1
        /// - it first recommened solution, we may need "selector" that select applicable values.
        /// - of course this enhances the solution, but what about the array in function parameter "int[] values", we need it to be object too.
        /// - so let the array be the object
        /// 
        /// modifictaion 2
        /// - let be the array apply the "Selector" and come up with the "Sum"
        /// 
        /// modification 3
        /// - now after making this modification, the function looks good, we have global function
        /// that takes an object as input (selector), and use "Sum" function that is implemented inside an array, so best thing is to delete this function.
        /// 
        /// - the sum function is already implemented in "Array" class, and "Selection" criteria have been coded in the "Selector" Class, so this function
        ///   now has no role now, so we can delete it.
        /// - Advice: Try to assign responsibilities to classes. Client will then have nothing to do.
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        static int Sum(int[] values)
        {
            // function 1
            int sum = 0;
            for(int i = 0; i < values.Length; i++)
            {
                sum += values[i];
            }

            return sum;
        }

        static int SumOddNumbersOnly(int[] values)
        {
            // function 1
            int sum = 0;
            for(int i = 0; i < values.Length; i++)
            {
                if(values[i] % 2 !=0)
                {
                    sum += values[i];
                }
            }
            return sum;
        }

        static int ChooseSumOddOrAllNumbers(int[] values, bool flag)
        {
            // function 1
            int sum = 0;
            for (int i = 0; i < values.Length; i++)
            {
                if (values[i] % 2 != 0 && flag)
                {
                    sum += values[i];
                }
                else
                {
                    sum += values[i];
                }
            }
            return sum;
        }


        // modification 1
        /*
        static int Sum(int[] values, selector)
        {
            int sum = 0;

            foreach(int value in selector.Pick(values))
            {
                sum += values[i];
            }

            return sum;
        }
        */

        // modification 2
        /*
        static int Sum(int[] values, selector)
        {
            int sum = values.Sum(selector);          
            return sum;
        }
        */
        static void Main(string[] args)
        {
            Console.WriteLine();
        }
    }
}
