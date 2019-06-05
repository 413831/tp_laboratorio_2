using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Archivos
{
    public class Xml<T>:IArchivo<T>
    {
        public bool Guardar(string archivo, T datos)
        {
            XmlTextWriter textWriter = new XmlTextWriter(archivo, Encoding.UTF8);
            XmlSerializer serializador = new XmlSerializer(typeof(T));

            serializador.Serialize(textWriter, datos);
            textWriter.Close();
            return true;
        }

        public bool Leer(string archivo, out T datos)
        {
            XmlTextReader textReader = new XmlTextReader(archivo);
            XmlSerializer serializador = new XmlSerializer(typeof(T));

            datos = (T)serializador.Deserialize(textReader);
            textReader.Close();
            return true;
        }
    }
}
