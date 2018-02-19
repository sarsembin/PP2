using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polyndrome
{
   
    class Program
    {
        static void Main(string[] args)
        {
            FileStream fs = new FileStream(@"C:\Users\Daur\Desktop\c# kbtu pp 2\lab 5\text1.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            FileStream fs1 = new FileStream(@"C:\Users\Daur\Desktop\c# kbtu pp 2\lab 5\output.txt", FileMode.Open, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs1);
            string kek = sr.ReadToEnd();
            int lolz = int.Parse(kek);
            for (int i = 1; i <= lolz; i++)
            {
                if (lolz % i == 0)
                {
                    sw.WriteLine(i);
                }
            }
            fs.Close();
            sr.Close();
            sw.Close();
            fs1.Close();
            Console.ReadKey();

        }
    }
}
