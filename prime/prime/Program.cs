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
            bool result = true;
            int[] arr = new int[] { 1, 2, 3, 4, 5, 6, 7, 8 , 10, 13, 17};
            for( int i = 0; i < arr.Length; i++)
            {
                for(int j = 2; j * j <= arr[i]; j++)
                {
                    result = true;
                    if (arr[i] % j == 0)
                    {
                        result = false;
                        break;
                    }
                }
                if(result  && i != 0)
                {
                    Console.WriteLine(arr[i]);
                   
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
