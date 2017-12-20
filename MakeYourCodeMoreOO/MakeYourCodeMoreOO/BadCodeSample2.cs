using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeYourCodeMoreOO
{
    class BadCodeSample2
    {
        /// <summary>
        /// is there any thing better than if-else statement to check that the string is not null? why we branch around "Null" reference?
        /// CAUSE OF PROBLEMS: 
        /// - Null is not an object
        /// - we have a class but we do not have an object
        /// - we can not build OO Code on null reference
        /// 
        /// - here we have another problem than previous one, in the previous one we do not have a "class", but
        ///   the problem here we have a "class" but we do not have an "object" of that class.
        ///   
        /// - ADVICE:
        ///     - Consider Constructing an object which represents "Nothing" then call method on it. that will be the proper object again.
        /// </summary>
        /// <param name="data"></param>
        static void ShowIt(string data)
        {
            string upper;

            if(data == null)
            {
                upper = null;
            }
            else
            {
                upper = data.ToUpper();
            }

            Console.WriteLine(upper);
        }

        static void ShowIt(MayBeString data)
        {
            MayBeString upper = data.ToMaybeUpper();
            Console.WriteLine(upper);
        }
    }
}
