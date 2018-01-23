
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
        public override string ToString()
        {
            return "firstname-s"+name + " lastname-" +  sname + " age-" + age;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Student me = new Student();  //creating new person
            Console.WriteLine(me);
            Console.ReadKey();

         }
    }
}
