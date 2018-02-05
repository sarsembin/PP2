﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Serialization_Deserialization
{
    class Program
    {
        static void Main(string[] args)
        {
            deser_bin();
            Console.ReadKey();
        }
        static void ser_bin()
        {
            FileStream fs = new FileStream(@"test1.ser", FileMode.Create, FileAccess.Write);
            Complex c1 = new Complex(1,3);
            BinaryFormatter bf = new BinaryFormatter();
            try
            {
                bf.Serialize(fs, c1);
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
        static void deser_bin()
        {
            FileStream fs = new FileStream(@"test1.ser", FileMode.Open, FileAccess.Read);
            BinaryFormatter bf = new BinaryFormatter();
            try
            {
               Complex c1 = bf.Deserialize(fs) as Complex;
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
    }
    [Serializable]
    class Complex
    {
        public int a, b;
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
}
