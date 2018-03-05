using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zad3
{
    class Program
    {
        static void Main(string[] args)
        {
            DirectoryInfo dir = new DirectoryInfo(@"C:\Users\Daur\Desktop\c# kbtu pp 2\midt");
            FileSystemInfo[] fsi = dir.GetFileSystemInfos();
            for (int i = 0; i < fsi.Length; i++)
            {
                if (fsi[i].GetType() == typeof(FileInfo))
                {
                    FileStream fs = new FileStream(fsi[i].FullName, FileMode.Open, FileAccess.Read);
                    StreamReader sr = new StreamReader(fs);
                    string s = sr.ReadToEnd();
                    string[] s1 = s.Split(' ');
                    for (int j = 0; j < s1.Length; j++)
                    {
                        if (s1[j] == "KBTU")
                        {
                            Console.WriteLine(fsi[i].Name);
                        }
                    }
                }
            }
            Console.ReadKey();
        }
    }
}
