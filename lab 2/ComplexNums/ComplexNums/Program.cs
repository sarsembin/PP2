using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplexNums
{
    class Complex
    {
        public int a,b,c,d;
        public int sum1, sum2;
        public Complex()
        {
            string fnum = Console.ReadLine();
            string[] sos = fnum.Split(' ');
            a = int.Parse(sos[0]);
            b = int.Parse(sos[1]);
            string snum = Console.ReadLine();
            string[] sos1 = snum.Split(' ');
            c = int.Parse(sos1[0]);
            d = int.Parse(sos1[1]);

        }
        public void swap(int a, int b)
        {
            int c = a;
            a = b;
            b = c;
            
        }
        public void sum()
        {
            int k = b;
            int m = d;
            a = a * m;
            c = c * k;
            sum1 = a + c;
            sum2 = b * d;
            bool da = false;
            if (sum1 > sum2)
            {
                swap(sum1,sum2);
                da = true;
            }
            int nod=1;
            for (int i = 2; i <= sum1; i++)
            {
                if (sum1%i==0 && sum2 % i == 0)
                {
                    nod = i;
                }
            }
            if (da == true)
            {
                swap(sum1, sum2);
            }
            sum1 = sum1 / nod;
            sum2 = sum2 / nod;

        }
        public override string ToString()
        {
            return sum1 + " " + sum2;
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Complex co = new Complex();
            co.sum();
            Console.WriteLine(co);
            Console.ReadKey();
        }
    }
}
