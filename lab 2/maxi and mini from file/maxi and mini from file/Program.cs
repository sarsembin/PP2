using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace maxi_and_mini_from_file
{
    class Read
    {
        public int maxi;
        public int mini;
        public void maximin()
        {
            FileStream fs = new FileStream(@"C:\Users\Daur\Desktop\c# kbtu pp 2\lab 2\nums.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            string s = sr.ReadLine();
            string[] sos = s.Split(' ');
            for (int i = 0; i < sos.Length; i++)
            {
                int n = int.Parse(sos[i]);
                if (n > maxi)
                {
                    maxi = n;
                }
                if (n < mini)
                {
                    mini = n;
                }
            }
            fs.Close();
            sr.Close();
        }
        class Program
        {
            static void Main(string[] args)
            {
                Read r = new Read();
                r.maximin();
                Console.WriteLine("Max " + r.maxi + "\n" + "Min " + r.mini);
                Console.ReadKey();
            }
        }
    }
}
