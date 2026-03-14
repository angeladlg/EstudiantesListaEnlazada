using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstudiantesListaEnlazada
{
    public class Nodo<E>
    {
        //atributos del nodo 
        public E Value { get; set; }
        public Nodo<E> Next { get; set; }

        //metodo constructor asignar el valor y donde apuntara el nodo
        public Nodo(E value)
        {
            //asignar el valor al nodo y establecer el siguiente nodo como null
            Value = value;
            Next = null;
        }
    }
}
