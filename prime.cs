using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prime
{
    class Program
    {
        static void Main(string[] args)
        {
            bool result = true;                                          // let initial value of Result be true
            int[] arr = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 10, 13, 17 };//we write several numbers, which will be the array arr
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 2; j * j <= arr[i]; j++)                     // by using the rule of primebility we find prime numbers
                {
                    result = true;
                    if (arr[i] % j == 0)
                    {
                        result = false;
                        break;
                    }
                }
                if (result && i != 0)                                    // when result is true and i is not equal to 0
                {
                    Console.WriteLine(arr[i]);                           //printing out these numbers

                }
                else
                {
                    continue;
                }
            }
            Console.ReadKey();
        }
    }
}
