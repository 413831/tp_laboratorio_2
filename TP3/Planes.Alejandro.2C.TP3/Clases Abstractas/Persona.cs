﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace EntidadesAbstractas
{
    public class Persona
    {
        /// <summary>
        /// Enumerado de nacionalidades posibles 
        /// </summary>
        public enum ENacionalidad
        {
            Argentino,
            Extranjero
        };

        #region Atributos

        private string apellido;
        private int dni;
        private string nombre;
        private ENacionalidad nacionalidad;

        #endregion

        #region Propiedades

        /// <summary>
        /// Propiedad para setear el valor del atributo apellido siempre y cuando sea un apellido válido
        /// </summary>
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

        /// <summary>
        /// Propiedad para setear el valor del atributo dni siempre y cuando sea un dni válido
        /// </summary>
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

        /// <summary>
        /// Propiedad para setear el valor del atributo nacionalidad
        /// </summary>
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

        /// <summary>
        /// Propiedad para setear el valor del atributo nombre siempre y cuando sea un nombre válido
        /// </summary>
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

        /// <summary>
        /// Propiedad para setear el valor del atributo dni desde un string siempre y cuando sea un dni válido
        /// </summary>
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

        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public Persona()
        {}

        /// <summary>
        /// Constructor con tres parámetros
        /// </summary>
        /// <param name="nombre">Valor para el atributo nombre</param>
        /// <param name="apellido">Valor para el atributo apellido</param>
        /// <param name="nacionalidad">Valor para el atributo nacionalidad</param>
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad) : this()
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }

        /// <summary>
        /// Constructor con cuatro parámetros con dni como número
        /// </summary>
        /// <param name="nombre">Valor para el atributo nombre</param>
        /// <param name="apellido">Valor para el atributo apellido</param>
        /// <param name="dni">Valor para el atributo dni</param>
        /// <param name="nacionalidad">Valor para el atributo nacionalidad</param>
        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad)
            : this(nombre,apellido,nacionalidad)
        {
            this.Dni = dni;
        }

        /// <summary>
        /// Constructor con cuatro parámetros con dni como string
        /// </summary>
        /// <param name="nombre">Valor para el atributo nombre</param>
        /// <param name="apellido">Valor para el atributo apellido</param>
        /// <param name="dni">Valor para el atributo dni</param>
        /// <param name="nacionalidad">Valor para el atributo nacionalidad</param>
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }

        /// <summary>
        /// Sobrecarga de método ToString() que retorna los datos de la persona
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder datos = new StringBuilder("");

            datos.AppendFormat("NOMBRE COMPLETO: {0}, {1}\n",this.Apellido, this.Nombre);
            datos.AppendFormat("NACIONALIDAD: {0}\n", this.Nacionalidad.ToString());

            return datos.ToString();
        }

        /// <summary>
        /// Validación de un numero de dni contra la nacionalidad recibida por parámetro
        /// </summary>
        /// <param name="nacionalidad">Nacionalidad para verificar el dni</param>
        /// <param name="dato">Número de dni</param>
        /// <returns>Retorna 1 si el dni es correcto sino retorna una excepción del tipo NacionalidadInvalidaException</returns>
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

        /// <summary>
        /// Validación de un string como dni contra la nacionalidad recibida por parámetro
        /// </summary>
        /// <param name="nacionalidad">Nacionalidad para verificar el dni</param>
        /// <param name="dato">Número de dni</param>
        /// <returns>Retorna 1 si es correcto el número respecto a la nacionalidad,
        /// sino retorna 0 y una excepcion del tipo DniInvalidoException </returns>
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
            catch(NacionalidadInvalidaException exception)
            {
                throw new DniInvalidoException("DNI invalido.", exception);
            }
        }

        /// <summary>
        /// Validación de un string como nombre o apellido
        /// </summary>
        /// <param name="dato">String recibido a validar</param>
        /// <returns>Retorna el string ingresado si es correcto sino retorna un string vacío</returns>
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
