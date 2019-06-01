using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace Clases_Abstractas
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
                this.apellido = value;
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
                this.nombre = value;
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

        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad)
        {

        }

        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad)
        {

        }

        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad)
        {

        }

        public override string ToString()
        {
            return base.ToString();
        }
        
        /*
         *  Se deberá validar que el DNI sea correcto, teniendo en cuenta su nacionalidad. Argentino entre 1 y
        89999999 y Extranjero entre 90000000 y 99999999. Caso contrario, se lanzará la excepción
        NacionalidadInvalidaException.
         */

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
            else if (Convert.ToInt32(dato) > 99999999 || Convert.ToInt32(dato) <= 0)
            {
                throw new NacionalidadInvalidadException("Nacionalidad inválida");
            }
            return 0;
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

        private ValidarNombreApellido(string dato)
        {
            string[] nombre;
            string[] apellido;

            nombre = dato.Split(' ');
            apellido = dato.Split(' ');

            for (i = 0; i < nombre.Length) ; if++)
            {

            }
        }


        #endregion


    }
}
