using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace l3_4
{
    class Program
    {
        static void ShowDirectoryInfo(DirectoryInfo directory, int cursor)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            FileSystemInfo[] fileSystemInfos = directory.GetFileSystemInfos();

            for (int i = 0; i < fileSystemInfos.Length; i++)
            {
                FileSystemInfo fileSystemInfo = fileSystemInfos[i];
                if (i == cursor)
                 Console.BackgroundColor = ConsoleColor.Gray;
                else
                    Console.BackgroundColor = ConsoleColor.Black;

                if (fileSystemInfo.GetType() == typeof(DirectoryInfo))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                Console.WriteLine(fileSystemInfo.Name);
            }
        }

        static void Main(string[] args)
        {
            DirectoryInfo directory = new DirectoryInfo(@"C:\Users\Рысдаулет Актоты\Desktop\PP2-labs");
            int cursor = 0;
            int n = directory.GetFileSystemInfos().Length;
            ShowDirectoryInfo(directory, cursor);

            while (true)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                if (keyInfo.Key == ConsoleKey.DownArrow)
                {
                    cursor++;
                    if (cursor == n)
                        cursor = 0;
                }
                if (keyInfo.Key == ConsoleKey.UpArrow)
                {
                    cursor--;
                    if (cursor == -1)
                        cursor = n - 1;
                }
                if (keyInfo.Key == ConsoleKey.Enter)
                {
                    if (directory.GetFileSystemInfos()[cursor].GetType() == typeof(DirectoryInfo))
                    {
                        directory = new DirectoryInfo(directory.GetFileSystemInfos()[cursor].FullName);
                        cursor = 0;
                        n = directory.GetFileSystemInfos().Length;
                    }
                    else
                    {
                        StreamReader sr = new StreamReader(directory.GetFileSystemInfos()[cursor].FullName);
                        string s = sr.ReadToEnd();
                        Console.Clear();
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine(s);
                        Console.ReadKey();
                    }
                }
                if (keyInfo.Key == ConsoleKey.Backspace)
                {
                    if (directory.Parent != null)
                    {
                        directory = directory.Parent;
                        cursor = 0;
                        n = directory.GetFileSystemInfos().Length;
                    }
                    else
                        break;
                }
            ShowDirectoryInfo(directory, cursor);
            }
        }
    }
}