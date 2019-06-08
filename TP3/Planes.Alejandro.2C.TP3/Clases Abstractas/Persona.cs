using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace EntidadesAbstractas
{
    public class Persona
    {
        public enum ENacionalidad
        {
            Argentino,
            Extranjero
        };

        private string apellido;
        private int dni;
        private string nombre;
        private ENacionalidad nacionalidad;

        #region Propiedades

        public string Apellido
        {
            get
            {
                return this.apellido;
            }
            set
            {
                if(this.ValidarNombreApellido(value) != "")
                {
                    this.apellido = value;
                }
            }
        }

        public int Dni
        {
            get
            {
                return this.dni;
            }
            set
            {
                if (this.ValidadDni(this.nacionalidad, value.ToString()) == 1)
                {
                    this.dni = value;
                }
            }
        }

        public ENacionalidad Nacionalidad
        {
            get
            {
                return this.nacionalidad;
            }
            set
            {
                this.nacionalidad = value;
            }
        }

        public string Nombre
        {
            get
            {
                return this.nombre;
            }
            set
            {
                if(this.ValidarNombreApellido(value) != "")
                {
                    this.nombre = value;
                }
            }
        }

        public string StringToDNI
        {
            set
            {
                if(this.ValidadDni(this.nacionalidad,value) == 1)
                {
                    this.dni = Convert.ToInt32(value);
                }
            }
        }

        #endregion

        #region Métodos

        public Persona()
        {

        }

        public Persona(string nombre, string apellido, ENacionalidad nacionalidad) : this()
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }

        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad)
            : this(nombre,apellido,nacionalidad)
        {
            this.Dni = dni;
        }

        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }

        public override string ToString()
        {
            StringBuilder datos = new StringBuilder("");

            datos.AppendFormat("NOMBRE COMPLETO: {0}, {1}\n",this.Apellido, this.Nombre);
            datos.AppendFormat("NACIONALIDAD: {0}\n", this.Nacionalidad.ToString());

            return datos.ToString();
        }
        

        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            if(nacionalidad == ENacionalidad.Argentino && dato > 0 && dato < 89999999)
            {
                return 1;
            }
            else if(nacionalidad == ENacionalidad.Extranjero && dato > 90000000 && dato < 99999999)
            {
                return 1;
            }
            else
            {
                throw new NacionalidadInvalidaException("La nacionalidad no se condice con el número de DNI");
            }
        }

        private int ValidadDni(ENacionalidad nacionalidad, string dato)
        {
            try
            {
                if(this.ValidarDni(nacionalidad, Convert.ToInt32(dato)) == 1)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            catch(FormatException exception)
            {
                throw new DniInvalidoException("DNI invalido.", exception);
            }
        }

        private string ValidarNombreApellido(string dato)
        {
            string[] nombreApellido;

            nombreApellido = dato.Split(' ');

            for (int i = 0; i < nombreApellido.Length ; i++) // CONSULTAR REGEX
            {   
                for (int j = 0; j < nombreApellido[i].Length; j++) //
                {
                    if(!Char.IsLetter(nombreApellido[i][j]))
                    {
                        return "";
                    }
                }
            }
            return dato;
        }


        #endregion
    }
}
