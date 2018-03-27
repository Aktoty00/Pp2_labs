using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace mid2
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(@"C:\Users\Рысдаулет Актоты\Desktop\PP2-labs\labs\mid2\input.txt");
            string s = sr.ReadLine();
            string[] s1 = s.Split(' ');
            int minn1 = 123123123; // min number
            int minn2 = 123456789; // second min number
            for (int i=0; i< s1.Length; ++i)
            {
                int k = int.Parse(s1[i]);
               if(k < minn1)
                {
                    minn2 = minn1;
                    minn1 = k;
                }               
            }
            StreamWriter sw = new StreamWriter(@"C:\Users\Рысдаулет Актоты\Desktop\PP2-labs\labs\mid2\output.txt");
            sw.WriteLine(minn2);
            sw.Close();
        }
    }
}
