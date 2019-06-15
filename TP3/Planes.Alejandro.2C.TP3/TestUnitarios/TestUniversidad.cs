using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EntidadesAbstractas;
using Clases_Instanciables;
using Archivos;
using Excepciones;

namespace TestUnitarios
{
    [TestClass]
    public class TestUniversidad
    {
        [TestMethod]
        [ExpectedException(typeof(AlumnoRepetidoException))]
        public void TestAlumnoRepetidoException()
        {
            //Arrange
            Alumno alumnoUno;
            Alumno alumnoDos;
            Universidad universidad;

            //Act
            alumnoUno = new Alumno(2, "Juan", "Perez", "33333333", Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion);
            alumnoDos = new Alumno(2, "Pepito", "Pereyra", "12341234", Persona.ENacionalidad.Argentino, Universidad.EClases.Legislacion);
            universidad = new Universidad();


            universidad += alumnoUno;
            universidad += alumnoDos;
            //Assert
        }
    }
}
