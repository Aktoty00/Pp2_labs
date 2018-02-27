using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace mid3
{
    class Program
    {
        static void Main(string[] args)
        {
            DirectoryInfo directory = new DirectoryInfo(@"C:\Users\Рысдаулет Актоты\Desktop\PP2-labs\labs");
            FileSystemInfo[] fileinfos = directory.GetFileSystemInfos();

            for(int i= 0; i < fileinfos.Length; ++i)
            {
                FileSystemInfo fs = fileinfos[i];
                if(fs.GetType() == typeof(FileInfo))
                    {
                    StreamReader sr = new StreamReader(fs.FullName);
                    string s = sr.ReadToEnd();
                    for (int j = 0; j < s.Length; ++j)
                        {
                        if (s[j] =='F' && s[j+1]== 'I' && s[j+2] == 'T')
                        {

                            Console.WriteLine(fs.Name);
                            Console.ReadKey();
                        }
                        }

                    }
                
            }

        }
    }
}
