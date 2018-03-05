using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace far
{
    class Program
    {
        public static int kek;
        static void show_all(DirectoryInfo dir,int pos)
        {
            FileSystemInfo[] names = dir.GetFileSystemInfos();
            kek = names.Length;
            for (int i = 0; i < names.Length; i++)
            {
                if (i == pos)
                { 
                    Console.BackgroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                if (names[i].GetType() == typeof(DirectoryInfo))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                }
                Console.WriteLine(names[i]);
            }
        }
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            int pos = 0;
            DirectoryInfo dir = new DirectoryInfo(@"C:\Users\Daur\Desktop\acmp");
            while (true)
            {
                Console.Clear();
                show_all(dir, pos);
                ConsoleKeyInfo button = Console.ReadKey();
                switch (button.Key)
                {
                    case ConsoleKey.UpArrow:
                        pos--;
                        if (pos < 0)
                        {
                            pos = kek - 1;
                            Console.BackgroundColor = ConsoleColor.Black;
                        }
                        else if (pos == kek - 2)
                        {
                            Console.BackgroundColor = ConsoleColor.Black;
                            //Console.BackgroundColor = ConsoleColor.White;
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        pos++;
                        if (pos > kek-1)
                        {
                            pos = 0;
                            Console.BackgroundColor = ConsoleColor.Black;
                        }
                        break;
                    case ConsoleKey.Enter:
                        FileSystemInfo f = dir.GetFileSystemInfos()[pos];
                        if (f.GetType() == typeof(DirectoryInfo))
                        {
                            dir = new DirectoryInfo(f.FullName);
                            pos = 0;
                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.Black;
                            FileStream fs = new FileStream(f.FullName, FileMode.Open, FileAccess.Read);
                            StreamReader sr = new StreamReader(fs);
                            string data = sr.ReadToEnd();
                            Console.Clear();
                            Console.WriteLine(data);
                            bool da = true;
                            while (da == true)
                            {
                                Console.Clear();
                                Console.WriteLine(data);
                                ConsoleKeyInfo butt = Console.ReadKey();
                                switch (butt.Key)
                                {
                                    case ConsoleKey.Q:
                                        da = false;
                                        break;
                                }
                            }

                            ConsoleKeyInfo bb = Console.ReadKey();
                            while (bb.Key != ConsoleKey.Q)
                                bb = Console.ReadKey();
                            
                        }
                        break;
                    case ConsoleKey.Escape:
                        dir = dir.Parent;
                        pos = 0;
                        break;
                }
            }

        }
    }
}
