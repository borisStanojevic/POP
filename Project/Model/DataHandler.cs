using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Project.Model
{
    class DataHandler
    {

        public void WriteEntity(Object entity)
        {
            Type entityType = entity.GetType();
            string fileName = "";
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
                    break;
            }
             //Incijalizujem XmlSerialzier i kazem mu koji tip podataka treba da serijalizuje
             XmlSerializer xmlWriter = new XmlSerializer(entityType);
             
             //Kreiram relativnu putanju do fajla u koji treba da serijalizujem odredjeni objekat
             string path = $"{Directory.GetCurrentDirectory()}\\..\\..Data\\{fileName}";
             //Kreiram stream i proslijedim mu putanju
             FileStream stream = File.Open(path,FileMode.Append);

            //Serijalizujem objekat
            xmlWriter.Serialize(stream, entity);

             stream.Close();
            }

        }
    }

