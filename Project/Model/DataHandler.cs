using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Project.Model
{
    //Klasa koja rukuje podacima. Pisanje, citanje ...
    class DataHandler
    {

        public void WriteEntity(Object entity)
        {
            Type entityType = entity.GetType();
            string fileName;
            switch (entityType.Name)
            {
                case "Furniture":
                    fileName = "furniture.xml";
                    break;
                case "Sale":
                    fileName = "sales.xml";
                    break;
                case "User":
                    fileName = "users.xml";
                    break;
                case "FurnitureType":
                    fileName = "furniture_type.xml";
                    break;
                case "ActionSale":
                    fileName = "action_sales.xml";
                    break;
                case "AdditionalService":
                    fileName = "additional_services.xml";
                    break;
                default:
                    fileName = "";
                    break;
            }
            /*
               U sledece tri linije inicijalizujem XmlSerializer kome u konstruktoru kazem koji tip objekta se serijalizuje,
               kreiram putanju do fajla u koji cu serijalizovati objekat (putanja je relativna), i kreiram stream nad tim fajlom,
               u modu append da ne bi svaki put pregazio postojece podatke u fajlu.
            */
            XmlSerializer writer;
            string path;
            FileStream stream;
            try
            {
                writer = new XmlSerializer(entityType);
                path = $@"{Directory.GetCurrentDirectory()}\\..\\..Data\\{fileName}";
                stream = File.Open(path, FileMode.Append);

                writer.Serialize(stream, entity);

                stream.Close();
            }
            catch (IOException exc)
            {
                Console.WriteLine(exc.Data);
                throw;
            }

            }

        }
    }

