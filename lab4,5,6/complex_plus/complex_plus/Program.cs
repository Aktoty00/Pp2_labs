using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace complex_plus
{ 
    class Program
    {
        static XmlSerializer Serializerfunction(complex_plus d)
        {
            XmlSerializer xs = new XmlSerializer(typeof(complex_plus));
            FileStream fs = new FileStream("data.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            xs.Serialize(fs, d);
            fs.Close();
            return xs;
        }
        static void Deserializerfunction(XmlSerializer xs)
        {
            XmlSerializer dxs = new XmlSerializer(typeof(complex_plus));
            FileStream dfs = new FileStream("data.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            complex_plus t = dxs.Deserialize(dfs) as complex_plus;
            Console.WriteLine(t);
            dfs.Close();
        }
        static void Main(string[] args)
        {
            string s = Console.ReadLine();
            string c = s.Split(' ')[0];
            string d = s.Split(' ')[1];
            int a_ = int.Parse(c.Split('/')[0]);
            int b_ = int.Parse(c.Split('/')[1]);
            int c_ = int.Parse(d.Split('/')[0]);
            int d_ = int.Parse(d.Split('/')[1]);
            complex_plus a = new complex_plus(a_, b_);
            complex_plus b = new complex_plus(c_, d_);
            complex_plus res = a + b;
            Console.WriteLine(res);
            Deserializerfunction(Serializerfunction(res));
            Console.ReadKey();
        }
    }
}
