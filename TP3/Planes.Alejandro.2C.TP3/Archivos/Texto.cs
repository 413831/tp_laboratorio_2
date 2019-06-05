using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Archivos
{
    public class Texto: IArchivo<string>
    {
        public bool Guardar(string archivo, string datos)
        {
            StreamWriter txtWriter = new StreamWriter(archivo,true);

            txtWriter.Write(datos);
            txtWriter.Close();
            return true;
        }

        public bool Leer(string archivo, out string datos)
        {
            StreamReader txtReader = new StreamReader(archivo);

            datos = txtReader.ReadToEnd();
            txtReader.Close();
            return true;
        }
    }
}
