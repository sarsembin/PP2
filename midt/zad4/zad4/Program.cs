using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace zad4
{
    class Point
    {
        public int x;
        public int y;
        public Point()
        {

        }
        public Point(int xs,int ys)
        {
            x = xs;
            y = ys;
        }
    }
    class Program
    {
        public static string s;
        //public static List<Point> body;
        public static int cnt = 0;
        public static int clock = 11;
        public static int clock1 = 1;
        public static string[] s1;
        static void Draw()
        {
            while (true)
            {
                /*foreach (Point p in body)
                {
                    Console.SetCursorPosition(p.x, p.y);
                    if (cnt == 0)
                    {
                        Console.Write(12);
                    }
                    else if (cnt % 2 == 0)
                    {
                        Console.Write(clock1);
                        clock1++;
                    }
                    else
                    {
                        Console.Write(clock);
                        clock--;
                    }
                    cnt++;
                }*/
                for(int i=0;i< s1.Length;i++)
                {
                    if (cnt == i)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(s1[i]);
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine(s1[i]);
                    }
                }
                 
                Thread.Sleep(1000);
                cnt++;
                if (cnt == s1.Length )
                {
                    cnt = 0;
                }
                Console.Clear();
            }
        }
        static void Main(string[] args)
        {
            Thread t = new Thread(Draw);
            FileStream fs = new FileStream(@"C:\Users\Daur\Desktop\c# kbtu pp 2\midt\nums_for_thread.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            s = sr.ReadToEnd();
            s1 = s.Split('\n');
            /*for (int i = 0; i < s1.Length; i++)
            {
                for (int j = 0; j < s1[i].Length; j++)
                {
                    if (s1[i][j] != ' ')
                    {
                        body.Add(new Point(i, j));
                    }
                }
            }*/
            t.Start();
            Console.ReadKey();
        }
    }
}
