using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstudiantesListaEnlazada
{
    //clase para almacenar los datos de los estudiantes
    public class DatosEstudiantes
    {
        //atributos de la clase datos estudiantes
        public string ID { get; set; }
        public string Nombre { get; set; }
        public string Grado { get; set; }

        public DatosEstudiantes(string id, string nombre, string grado)
        {
            //asignar los valores a los atributos de la clase datos estudiantes
            ID = id;
            Nombre = nombre;
            Grado = grado;
        }
    }
}