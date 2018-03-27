using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    class Program
    {

        public static Save Init()
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = new FileStream(@"data.bin", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            
            try
            {
                return bf.Deserialize(fs) as Save;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            } finally
            {
                fs.Close();
            }
            return null;
        }

        static void Main(string[] args)
        {
            Console.CursorVisible = false;

            Market cur;

            Save d = Init();

            cur = d.market;

            int pos = 0;
            cur.ShowBrands(pos);

            while(true)
            {
                ConsoleKeyInfo btn = Console.ReadKey();
                Console.Clear();
                if (btn.Key == ConsoleKey.UpArrow)
                {
                    pos--;
                    if(pos == -1)
                    {
                        pos = 2;
                    }
                }
                if(btn.Key == ConsoleKey.DownArrow)
                {
                    pos++;
                    if (pos == 3)
                        pos = 0;
                }
                if(btn.Key == ConsoleKey.Enter)
                {
                    Console.Clear();
                    cur.showProduct(pos);
                    Console.ReadKey();
                    Console.Clear();
                }
                cur.ShowBrands(pos);
                SaveData(cur);
            }
        }
        public static void SaveData(Market cur)
        {
            Save curSave = new Save(cur, cur.brands);
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = new FileStream(@"Data.bin", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            try
            {
                bf.Serialize(fs, curSave);
            } catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                fs.Close();
            }
        }
    }
}
