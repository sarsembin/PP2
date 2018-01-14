using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circle
{
    class Circle
    {
        public int radius;
        public int D;
        public double S;
        public double L;
        public Circle()
        {
            string r = Console.ReadLine();
            radius = int.Parse(r);
        }
        public int diam()
        {
            D = radius * 2;
            return D;
        }
        public double area()
        {
            S = 3.14 * radius * radius;
            return S;
        }
        public double length()
        {
            L = 2 * 3.14 * radius;
            return L;
        }
        public override string ToString()
        {
            return radius + "\n" + D + "\n" + L + "\n" + S;
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Circle C = new Circle();
            C.diam();
            C.length();
            C.area();
            Console.WriteLine(C);
            Console.ReadKey();

        }
    }
}
