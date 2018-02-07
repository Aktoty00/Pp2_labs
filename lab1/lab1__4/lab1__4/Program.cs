using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program1.cs
{
    public class Student
    {   //fields
        public string name;
        public string sname;
        public int age;


        public Student()
        {
            name = "Aktoty";      //initial firstname
            sname = "Rysdaulet";  //initial lastname
            age = 17;             //initial age
        }
        public Student(string name, string sname, int age)
        {
            this.name = name;
            this.sname = sname;
            this.age = age;
        }
        public override string ToString()
        {
            return "firstname-" + name + " lastname-" + sname + " age-" + age;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            string nname = Console.ReadLine();
            string ssname = Console.ReadLine();
            int aage = int.Parse(Console.ReadLine());
            Student me = new Student(nname, ssname, aage);  //creating new person
            Console.WriteLine(me);

            Console.ReadKey();

        }
    }
}