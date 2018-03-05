using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zad2
{
    class Program
    {
        static void Main(string[] args)
        {
            FileStream fs = new FileStream(@"C:\Users\Daur\Desktop\c# kbtu pp 2\midt\mass.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            string s = sr.ReadLine();
            string[] s1 = s.Split(' ');
            int a;
            int maxi = -10000000, maxi2 = -10000000;
            for (int i = 0; i < s1.Length; i++)
            {
                a = int.Parse(s1[i]);
                if (a > maxi)
                {
                    maxi2 = maxi;
                    maxi = a;
                    
                }
                else if (a < maxi && a > maxi2)
                {
                    maxi2 = a;
                }
            }
            Console.WriteLine(maxi2);
            Console.ReadKey();

        }
    }
}
