using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Serialization_quiz
{
    [Serializable]
    public class Product
    {
        public string name;
        public double price;
        public int count;
        public Product()
        {

        }
        public Product(string name_of, double price_of, int count_of)
        {
            name = name_of;
            price = price_of;
            count = count_of;
        }
        public void ser_prod(Product p)
        {
            FileStream fs = new FileStream(@"data_prod.xml", FileMode.Create, FileAccess.Write);
            XmlSerializer xs = new XmlSerializer(typeof(Product));
            try
            {
                xs.Serialize(fs, p);
            }
            catch(Exception e)
            {
                //e.Message();
            }
            finally
            {
                fs.Close();
            }
            Console.WriteLine("Serialized");
        }
        public Product deser_prod()
        {
            FileStream fs = new FileStream(@"data_prod.xml", FileMode.Open, FileAccess.Read);
            XmlSerializer xs = new XmlSerializer(typeof(Product));
            Product prod = new Product();
            try
            {
                prod = xs.Deserialize(fs) as Product;
            }
            catch (Exception e)
            {
                //e.Message();
            }
            finally
            {
                fs.Close();
            }
            Console.WriteLine("Deserialized");
            return prod;
        }
        public override string ToString()
        {
            return name + " " + price + " " + count;
        }
    }
    public class Shop
    {
        public List<Product> magaz;
        public Shop()
        {

        }
        public Shop(List<Product> magaz_of)
        {
            magaz = magaz_of;
        }
        public override string ToString()
        {
            return "";
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Product p = new Product("Smetana", 300, 5);
            Product f = new Product();
            p.ser_prod(p);
            f = p.deser_prod();
            Console.WriteLine(p);
            Console.ReadKey();
        }
    }
}
