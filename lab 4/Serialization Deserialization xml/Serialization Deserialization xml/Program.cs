using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Serialization_Deserialization_xml
{
    [Serializable]
    public class Complex
    {
        public int a, b;
        public Complex()
        {
            a = 2;
            b = 5;
            /* s1 = Console.ReadLine();
            string[] sos1 = s1.Split(' ');
            a = int.Parse(sos1[0]);
            b = int.Parse(sos1[1]);*/
        }
        public Complex(int chi, int zna)
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
            int nod = 1;
            for (int i = 2; i <= chis; i++)
            {
                if (chis % i == 0 && znam % i == 0)
                {
                    nod = i;
                }
            }
            if (da == true)
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

            return a + "/" + b;
        }
    }
    class Program
    {
        static void f1()
        {
            FileStream fs = new FileStream(@"data.xml", FileMode.Create, FileAccess.Write);
            XmlSerializer xs = new XmlSerializer(typeof(Complex));
            Complex c1 = new Complex(1,3);
            try
            {
                xs.Serialize(fs, c1);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                fs.Close();
            }
            Console.WriteLine("done");
        }
        static void f2()
        {
            FileStream fs = new FileStream(@"data.xml", FileMode.Open, FileAccess.Read);
            XmlSerializer xs = new XmlSerializer(typeof(Complex));
            try
            {
                Complex c1  = xs.Deserialize(fs) as Complex;
                Console.WriteLine(c1);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                fs.Close();
            }
        }
        static void Main(string[] args)
        {
            f2();
            Console.ReadKey();
        }
    }
}
