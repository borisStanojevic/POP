using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_SF8_2016.Tests
{
    class Test1
    {

        static void Main(string[] args)
        {
            //Console.WriteLine("Hello C#");
            //Console.ReadLine();

            Person p1 = new Person("Mitar", "Miric");
            Console.WriteLine(String.Format("Hi my name is {0} and my last name is {1}", p1.Name, p1.Surname));
            Console.WriteLine($"{p1.Name}\n{p1.Surname}");

            int[] array = new int[] { 1, 3, 4, 5, 6342, 2 };
            for (var i = 0; i < array.Count(); i++)
            {
                Console.WriteLine(array[i]);
            }

            List<Person> ppl = new List<Person>();
            for (int i = 0; i < 10; i++)
            {
                ppl.Add(new Person("Osoba", $"{i}"));
            }

            foreach (Person p in ppl)
            {
                Console.WriteLine(p.ToString());
            }
            Console.Read();

        }
    }
}
