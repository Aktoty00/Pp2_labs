using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace l3_4s
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
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                }
                Console.WriteLine(fileSystemInfo.Name);
            }
        }

        static void Main(string[] args)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(@"C:\Users\Рысдаулет Актоты\Desktop\PP2-labs");
            int cursor = 0;
            int n = directoryInfo.GetFileSystemInfos().Length;
            ShowDirectoryInfo(directoryInfo, cursor);

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
                    if (directoryInfo.GetFileSystemInfos()[cursor].GetType() == typeof(DirectoryInfo))
                    {
                        directoryInfo = new DirectoryInfo(directoryInfo.GetFileSystemInfos()[cursor].FullName);
                        cursor = 0;
                        n = directoryInfo.GetFileSystemInfos().Length;
                    }
                    else
                    {
                        StreamReader sr = new StreamReader(directoryInfo.GetFileSystemInfos()[cursor].FullName);
                        string s = sr.ReadToEnd();
                        Console.Clear();
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine(s);
                        Console.ReadKey();
                    }
                }
                if (keyInfo.Key == ConsoleKey.Escape)
                {
                    if (directoryInfo.Parent != null)
                    {
                        directoryInfo = directoryInfo.Parent;
                        cursor = 0;
                        n = directoryInfo.GetFileSystemInfos().Length;
                    }
                    else
                        break;
                }
                ShowDirectoryInfo(directoryInfo, cursor);
            }
        }
    }
}