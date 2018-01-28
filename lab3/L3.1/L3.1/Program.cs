using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace l3_1
{
    class Program
    {
        static void ShowDirectoryInfo(DirectoryInfo directory, int cursor)
         {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            FileSystemInfo[] fss = directory.GetFileSystemInfos();   
            for(int i = 0; i< fss.Length; ++i)
            {
                FileSystemInfo f = fss[i];
                if(i == cursor)
                {
                    Console.BackgroundColor = ConsoleColor.Gray;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                if (f.GetType() == typeof(DirectoryInfo))
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                Console.WriteLine(f.Name);
            }         
         }

        static void Main(string[] args)
        {
            DirectoryInfo directory = new DirectoryInfo(@" C:\Users\Рысдаулет Актоты\Desktop\PP2-labs");
            int cursor = 0;
            int n = directory.GetFileSystemInfos().Length;
            ShowDirectoryInfo(directory, cursor);
            while (true)
            {
                ConsoleKeyInfo keyinfo = Console.ReadKey();
                if (keyinfo.Key == ConsoleKey.UpArrow)
                {
                    cursor--;
                    if (cursor == -1)
                        cursor = n - 1;
                }
                if (keyinfo.Key == ConsoleKey.DownArrow)
                {
                    cursor++;
                    if (cursor == n)
                        cursor = 0;
                }
                ShowDirectoryInfo(directory, cursor);

            }
            Console.ReadKey();

        }
    }

}