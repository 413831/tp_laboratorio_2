using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using Archivos;

namespace Clases_Instanciables
{
    [Serializable]
    public class Universidad
    {
        /// <summary>
        /// Enumerado de clases
        /// </summary>
        public enum EClases
        {
            Programacion,
            Laboratorio,
            Legislacion,
            SPD
        };

        private List<Alumno> alumnos;
        private List<Jornada> jornadas;
        private List<Profesor> profesores;

        #region Propiedades

        /// <summary>
        /// Propiedad para listado de alumnos
        /// </summary>
        public List<Alumno> Alumnos
        {
            get
            {
                return this.alumnos;
            }
            set
            {
                this.alumnos = value;
            }
        }

        /// <summary>
        /// Propiedad para listado de instructores
        /// </summary>        
        public List<Profesor> Instructores
        {
            get
            {
                return this.profesores;
            }
            set
            {
                this.profesores = value;
            }
        }

        /// <summary>
        /// Propiedad para listado de jornadas
        /// </summary>
        public List<Jornada> Jornadas
        {
            get
            {
                return this.jornadas;
            }
            set
            {
                this.jornadas = value;
            }
        }

        /// <summary>
        /// Propiedad para retornar una jornada de la universidad
        /// </summary>
        /// <param name="i">Indexador</param>
        /// <returns>Retorna la jornadad del índice indicado sino retorna null</returns>
        public Jornada this[int i]
        {
            get
            {
                if(i < this.jornadas.Count)
                {
                    return this.jornadas[i];
                }
                return null;
            }
            set
            {
                this.jornadas[i] = value;
            }
        }

        #endregion

        #region Métodos

        /// <summary>
        /// Constructor público que inicializa los listados
        /// </summary>
        public Universidad()
        {
            this.Alumnos = new List<Alumno>();
            this.Instructores = new List<Profesor>();
            this.Jornadas = new List<Jornada>();
        }

        /// <summary>
        /// Método estático para guardar los datos de una universidad en un archivo XML
        /// </summary>
        /// <param name="universidad">Objeto para guardar los datos</param>
        /// <returns>Retorna true si logra guardar sino retorna false</returns>
        public static bool Guardar(Universidad universidad)
        {
            Xml<Universidad> exportarXml = new Xml<Universidad>();

            if(exportarXml.Guardar("Universidad.xml", universidad))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Método estático para leer los datos de un archivo XML
        /// </summary>
        /// <param name="archivo">Nombre del archivo para leer los datos</param>
        /// <param name="datos">Objeto para guardar los datos leídos</param>
        /// <returns>Retorna true si logra leer los datos sino retorna false</returns>
        public static bool Leer(string archivo, out Universidad datos)
        {
            Xml<Universidad> importarXml = new Xml<Universidad>();

            if (importarXml.Leer(archivo,out datos))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Método privado estático que retorna todos los datos de una Universidad en un string
        /// </summary>
        /// <param name="universidad">Objeto del que se retornarán los datos</param>
        /// <returns>Retorna un string con todos los datos</returns>
        private static string MostrarDatos(Universidad universidad)
        {
            StringBuilder datos = new StringBuilder("");

            foreach (Jornada jornada in universidad.Jornadas)
            {
                datos.AppendFormat("JORNADA: \n{0}",jornada.ToString());
                datos.AppendLine("ALUMNOS: \n");
                foreach(Alumno alumno in universidad.Alumnos)
                {
                    if (jornada == alumno)
                    {
                        datos.AppendFormat(alumno.ToString());
                    }
                }
                datos.AppendFormat("<---------------------------------------->\n");
            }
            return datos.ToString();        
        }

        /// <summary>
        /// Sobrecarga de método ToString() que retorna los datos del objeto actual en un string
        /// </summary>
        /// <returns>Retorna los datos de la instancia en un string</returns>
        public override string ToString()
        {
            return Universidad.MostrarDatos(this);
        }


        public static bool operator !=(Universidad universidad, Alumno alumno)
        {
            return !(universidad == alumno);
        }

        public static bool operator !=(Universidad universidad, Profesor profesor)
        {
            return !(universidad == profesor);
        }

        public static Profesor operator !=(Universidad universidad, EClases clase)
        {
            foreach(Profesor profesor in universidad.Instructores)
            {
                if(profesor != clase)
                {
                    return profesor;
                }
            }
            throw new SinProfesorException();
        }

        public static bool operator ==(Universidad universidad, Alumno alumno)
        {
            foreach(Alumno auxiliarAlumno in universidad.Alumnos)
            {
                if(auxiliarAlumno == alumno)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool operator ==(Universidad universidad, Profesor profesor)
        {
            foreach(Profesor auxiliarProfesor in universidad.Instructores)
            {
                if(auxiliarProfesor == profesor)
                {
                    return true;
                }
            }
            return false;
        }

        public static Profesor operator ==(Universidad universidad, EClases clase)
        {
            foreach(Profesor profesor in universidad.Instructores)
            {
                if(profesor == clase)
                {
                    return profesor;
                }
            }
            throw new SinProfesorException();
        }


        public static Universidad operator +(Universidad universidad, EClases clase)
        {
            Jornada jornada;
            Profesor profesor;

            profesor = universidad == clase;// Busco 1 profesor que tenga esa clase

            if (!Object.Equals(profesor,null)) 
            {
                jornada = new Jornada(clase,profesor); //Asigno el profesor a la jornada

                foreach(Alumno alumno in universidad.Alumnos) // Busco todos los alumnos inscriptos en la clase
                {
                    if(alumno == clase)
                    {
                        jornada += alumno;
                    }
                }
                universidad.Jornadas.Add(jornada);           
            }
            else
            {
                throw new SinProfesorException();
            }
            return universidad;
        }

        public static Universidad operator +(Universidad universidad, Alumno alumno)
        {
            if(universidad != alumno)
            {
                universidad.Alumnos.Add(alumno);
            }
            else
            {
                throw new AlumnoRepetidoException();
            }
            return universidad;
        }

        public static Universidad operator +(Universidad universidad, Profesor profesor)
        {
            if(universidad != profesor)
            {
                universidad.Instructores.Add(profesor);
            }
            return universidad;
        }


        #endregion
    }
}