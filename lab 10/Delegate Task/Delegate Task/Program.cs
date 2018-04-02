using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace Delegate_Task
{
    class first_delegate
    {
        public static double sum(double a, double b)
        {
            return a + b;
        }
    }
    delegate double MathAction(double a, double b);
    class Program
    {
        static void Main(string[] args)
        {
            Timer t = new Timer(del_ex);
            t.Change(0,10000);
            
        }
        public static void del_ex(object state)
        {
            MathAction ma = first_delegate.sum;
            double summa = ma(2, 3);
            Console.WriteLine("Sum:" + summa);
        }
    }
}
