﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace lab2_2
{
       class Program
    {
       static int primetest(int a) {
            int n = 0;
            for (int i=1; i<=a; ++i)
            {
                if (a % i == 0)
                {
                    n++;
                }
            }
            return n;
    }
        static void Main(string[] args)
        {
            string line = File.ReadAllText(@"C:\Users\Рысдаулет Актоты\Desktop\PP2-labs\labs\lab2\minmax.txt");
            string[] line1 = line.Split(' ');
            int minprime =1287112322;
            foreach(string s in line1)
            {
                int k = int.Parse(s);
               if( (primetest(k)==2) && (minprime>k)  )
                {
                    minprime = k;
                }
            }

            StreamWriter sw = new StreamWriter(@"C:\Users\Рысдаулет Актоты\Desktop\PP2-labs\labs\lab2\res_for_prime");
            sw.WriteLine("min prime number is " + minprime);
            sw.Close();
            Console.ReadKey();
        }
    }
}
