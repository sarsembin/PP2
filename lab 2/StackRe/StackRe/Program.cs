using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackRe
{
    class Program
    {
        static void show_files()
        {
            DirectoryInfo dir = new DirectoryInfo(@"C:\Users\Daur\Desktop\acmp");
            FileInfo[] files = dir.GetFiles();
            for (int i=0;i<files.Length; i++)
            {
                Console.WriteLine(files[i].Name);
            }
        }
        static void show_dirs()
        {
            DirectoryInfo dir = new DirectoryInfo(@"C:\Users\Daur\Desktop\acmp");
            DirectoryInfo[] dirs = dir.GetDirectories();
            for (int i = 0; i < dirs.Length; i++)
            {
                Console.WriteLine(dirs[i].Name);
            }
        }
        static void show_ever(string path, int depth = 0)
        {
            DirectoryInfo dir = new DirectoryInfo(path);
            FileInfo[] files = dir.GetFiles();
            DirectoryInfo[] dirs = dir.GetDirectories();
            Stack s1 = new Stack();
            for (int i = 0; i < dirs.Length; i++)
            {
                s1.Push(dirs[i]);
            }
        }
        static void Main(string[] args)
        {
            show_ever(@"C:\Users\Daur\Desktop\acmp");
        }
    }
}
