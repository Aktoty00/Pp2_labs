using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace complexser
{
    [Serializable]
    class Program
    {
       
        static void Main(string[] args)
        {
            string s = Console.ReadLine();
            string c = s.Split(' ')[0];
            string d = s.Split(' ')[1];
            int a_ = int.Parse(c.Split('/')[0]);
            int b_ = int.Parse(c.Split('/')[1]);
            int c_ = int.Parse(d.Split('/')[0]);
            int d_ = int.Parse(d.Split('/')[1]);
            complex_number a = new complex_number(a_, b_);
            complex_number b = new complex_number(c_, d_);
            complex_number res = a + b;
            Console.WriteLine(res);

            FileStream fs = new FileStream("data.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, res);
            fs.Close();
            bf = new BinaryFormatter();
            FileStream fss = new FileStream("data.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            complex_number t = bf.Deserialize(fss) as complex_number;
            Console.WriteLine(t);
            Console.ReadKey();
        }
    }
}
