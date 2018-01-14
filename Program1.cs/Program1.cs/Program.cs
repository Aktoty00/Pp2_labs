
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program1.cs
{
   public class Person
    {
        public string name;
        public string sname;
        public int age;


        public Person()
        {
            name = "asdf";
            sname = "qwer";
            age = 25;
        }
        public Person (string q, string w, int e)
        {
            name = q;
            sname = w;
            age = e;
        }
        public override string ToString()
        {
            return name + " " + sname + " " + age ;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Person me = new Person();
            Console.WriteLine(me);
            Console.ReadKey();

            string a = Console.ReadLine();
            string d = Console.ReadLine();
            int n = int.Parse(Console.ReadLine());

            Person he = new Person(a, d, n);
            Console.WriteLine(he);
            Console.ReadKey();
 


        }
    }
}
