using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MyApplication.DAO
{
    public class GenericSerializer
    {
        public static void Serialize<T>(string fileName, List<T> objToSerialize)
        {
            try
            {
                var serializer = new XmlSerializer(typeof(List<T>));
                using (var streamWriter = new StreamWriter($@"../../Data/{fileName}"))
                {
                    serializer.Serialize(streamWriter, objToSerialize);
                }
            }
            catch (IOException exc)
            {
                Console.WriteLine(exc.Message);
                throw;
            }
        }

        public static List<T> Deserialize<T>(string fileName)
        {
            try
            {
                var serializer = new XmlSerializer(typeof(List<T>));
                using (var streamReader = new StreamReader($@"../../Data/{fileName}"))
                {
                    return (List<T>)serializer.Deserialize(streamReader);
                }
            }
            catch (IOException exc)
            {
                Console.WriteLine(exc.Message);
                throw;
            }
        }
    }
}
