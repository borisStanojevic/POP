using POP_SF8_2016.Model;
using Project.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Project
{
    class Program
    {
        static void Main(string[] args)
        {
            //Store s1 = new Store()
            //{
            //    Id = 122,
            //    Name = "Formaaaaaaaaa FTNale",
            //    Address = "Trg Dositeja obradovica 6",
            //    Account = "840-00076899-83",
            //    Email = "kontakt@uns.ac.ftn.ac.rs",
            //    TaxingId = 12223124,
            //    Phone = "021/445-342",
            //    Website = "www.nekisalon.com",
            //    Deleted = false

            //};
            //// Inicijalizujem xml pisac i odredjujem koji tip objekata ce upisivati


            //XmlSerializer xmlWriter = new XmlSerializer(s1.GetType());

            ////Kreiram relativnu putanju do fajla u koji treba da serijalizujem odredjeni objekat
            //string path = Directory.GetCurrentDirectory() + "\\..\\..\\Data\\stores.xml";
            ////Kreiram stream i proslijedim mu putanju
            //FileStream stream = File.Open(path,FileMode.Append);

            ////Serijalizujem objekat
            //xmlWriter.Serialize(stream, s1);
            //stream.Close();
        }

    }
}
