using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Entidades
{
    public static class GuardaString
    {
        public static bool Guardar(this string texto, string archivo)
        {
            StreamWriter escritor;
            
            try
            {
                escritor = new StreamWriter(archivo,true);
                escritor.Write(texto);
                escritor.Close();
            }
            catch(IOException exception) // Lanzo exception a clase superior
            {
                throw exception;
            }
            return true;
        }
    }
}
