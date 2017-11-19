using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MyApplication.DAO
{
    public class GenericSerializer
    {
        public static void Serialize<T>(string fileName, ObservableCollection<T> objToSerialize)
        {
            try
            {
                var serializer = new XmlSerializer(typeof(ObservableCollection<T>));
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

        public static ObservableCollection<T> Deserialize<T>(string fileName)
        {
            try
            {
                var serializer = new XmlSerializer(typeof(ObservableCollection<T>));
                using (var streamReader = new StreamReader($@"../../Data/{fileName}"))
                {
                    return (ObservableCollection<T>)serializer.Deserialize(streamReader);
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
