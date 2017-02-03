using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace NinjaStriker
{
    public class XmlManager<T>
    {
        public Type Type { get; set; }
        ///public Type Type { get; private set; }

        public XmlManager()
        {
            Type = typeof(T);
        }

        public T Load(string path)
        {
            T instance;
            using (TextReader reader = new StreamReader(path))
            {
                System.Diagnostics.Debug.WriteLine("Xml-Serialization Type:");
                System.Diagnostics.Debug.WriteLine((Type));
                XmlSerializer xml = new XmlSerializer(Type);
                instance = (T)xml.Deserialize(reader);
            }
            return instance;
        }

        public void Save(string path, object obj)
        {
            using (TextWriter writer = new StreamWriter(path))
            {
                XmlSerializer xml = new XmlSerializer(Type);
                xml.Serialize(writer, obj);
            }
        }
    }
}
