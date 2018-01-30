using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplexNums
{
    class Complex
    {
        public int a, b;
        public Complex(int chi,int zna)
        {
            a = chi;
            b = zna;
        }
        static void swap(int a, int b)
        {
            int c = a;
            a = b;
            b = c;
            
        }
        public static Complex operator +(Complex c1, Complex c2)
        {
            int chis, znam;
            znam = c1.b * c2.b;
            chis = (c1.a * c2.b) + (c2.a * c1.b);
            bool da = false;
            if (chis > znam)
            {
                swap(chis, znam);
            }
            int nod=1;
            for (int i = 2; i <= chis; i++)
            {
                if (chis % i == 0 && znam % i == 0)
                {
                    nod = i;
                }
            }
            if(da == true)
            {
                swap(chis, znam);
            }
            chis = chis / nod;
            znam = znam / nod;
            string s = chis + "/" + znam;
            Complex c3 = new Complex(chis, znam);
            return c3;
        }
        public override string ToString()
        {
            
            return a +"/"+ b;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int a, b, c, d;
            string fnum = Console.ReadLine();
            string[] sos = fnum.Split(' ');
            a = int.Parse(sos[0]);
            b = int.Parse(sos[1]);
            string fnum1 = Console.ReadLine();
            string[] sos1 = fnum1.Split(' ');
            c = int.Parse(sos1[0]);
            d = int.Parse(sos1[1]);
            Complex c1 = new Complex(a,b);
            Complex c2 = new Complex(c,d);
            Complex c3 = c1 + c2;
            Console.WriteLine(c3);
            Console.ReadKey();
        }
    }
}
