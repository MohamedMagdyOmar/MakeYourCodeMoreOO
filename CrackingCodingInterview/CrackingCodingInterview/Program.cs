using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrackingCodingInterview
{
    class Program
    {
        static void Main(string[] args)
        {
            List<bool> booleanList = new List<bool>();
            int[] arrayOfInt = new int[10];
            //Console.WriteLine(booleanList.Count);
            Console.WriteLine(arrayOfInt[0]);
            Console.WriteLine(arrayOfInt[1]);
            var g = (Encoding.ASCII.GetBytes("ab"));
            var listOfChars = Console.ReadLine().ToList();
            bool IsUnique = true;

            for(int i = 0; i < listOfChars.Count - 1; i++)
            {
                for(int j = i + 1; j < listOfChars.Count; j++)
                {
                    if(listOfChars[i] == listOfChars[j])
                    {
                        IsUnique = false;
                        break;
                    }
                }
            }

            Console.Write(IsUnique);
            Console.ReadLine();
        }
    }
}
