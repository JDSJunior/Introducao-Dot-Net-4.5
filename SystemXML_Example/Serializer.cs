using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace SystemXML_Example
{
    public static class Serializer
    {
        public static T Deserialize<T>(this XElement xElement)
        {
            using (var memoryStream = new MemoryStream(Encoding.ASCII.GetBytes(xElement.ToString())))
            {
                var XmlSerealizer = new XmlSerializer(typeof(T));
                return (T)XmlSerealizer.Deserialize(memoryStream);
            }
        }

        public static XElement Serealize<T>(this object o)
        {
            using (var memoryStream = new MemoryStream())
            {
                using (TextWriter streamWritter = new StreamWriter(memoryStream))
                {
                    var xmlSerializer = new XmlSerializer(typeof(T));
                    xmlSerializer.Serialize(streamWritter, o);
                    return XElement.Parse(Encoding.ASCII.GetString(memoryStream.ToArray());
                }
            }
        }
    }
}
