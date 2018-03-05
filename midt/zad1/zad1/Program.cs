using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zad1
{
    class Program
    {
        static int fact(int n)
        {
            int a=1;
            if (n == 0)
            {
                return 0;
            }
            for (int i = 1; i <= n; i++)
            {
                a = a * i;
            }
            return a;
        }
        static void Main(string[] args)
        {
            int n , nf;
            string s = Console.ReadLine();
            n = int.Parse(s);
            nf = fact(n);
            Console.WriteLine(nf);
            Console.ReadKey();
        }
    }
}
