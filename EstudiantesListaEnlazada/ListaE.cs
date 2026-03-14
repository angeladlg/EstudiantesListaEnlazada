using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstudiantesListaEnlazada
{
    public class ListaE<E>
    {
        //atributos de la lista enlazada
        public Nodo<E> Cabeza { get; set; }
        public Nodo<E> ultimo { get; set; }

        //contador para llevar el seguimiento del número de nodos en la lista
        public int count { get; set; }
        //propiedad para obtener el número de nodos en la lista
        public int Count => count;
        //propiedad para verificar si la lista está vacía
        public bool IsEmpty => count == 0;

        //metodo para crear nodos

        public void InsertALaCabeza(E value)
        {
            //crear un nuevo nodo en memoria 
            var newNodo = new Nodo<E>(value);
            //hace que el nuevo nodo que antes era la cabeza 
            newNodo.Next = Cabeza;
            Cabeza = newNodo;
            //si la lista estaba vacía, el nuevo nodo también será el último
            if
                (ultimo == null)
            {
                ultimo = Cabeza;
            }
            //incrementar el contador de nodos en la lista
            count++;
        }

        public void InsertarAlMedio(E value)
        {
            //crear un nuevo nodo en memoria
            var newNodo = new Nodo<E>(value);

            //si la lista está vacía, el nuevo nodo se convierte en la cabeza y el último
            if (IsEmpty)
            {
                Cabeza = newNodo;
                ultimo = newNodo;
            }
            //si la lista tiene un solo nodo, el nuevo nodo se convierte en el último
            else
            {
                Nodo<E> actual = Cabeza;
                //calcular el índice del medio de la lista
                int midIndex = count / 2;

                //recorrer la lista hasta el nodo anterior al índice del medio
                for (int i = 0; i < midIndex - 1; i++)
                {
                    //moverse al siguiente nodo
                    actual = actual.Next;
                }
                //insertar el nuevo nodo después del nodo actual
                newNodo.Next = actual.Next;
                actual.Next = newNodo;
                //si el nuevo nodo se inserta al final de la lista, actualizar el último nodo
                if (newNodo.Next == null)
                {
                    //actualizar el último nodo para que apunte al nuevo nodo
                    ultimo = newNodo;
                }
            }
            //incrementar el contador de nodos en la lista
            count++;
        }

        public void InsertarAlFinal(E value)
        {
            //crear un nuevo nodo en memoria
            var newNodo = new Nodo<E>(value);

            //si la lista está vacía, el nuevo nodo se convierte en la cabeza y el último
            if (IsEmpty)
            {
                Cabeza = newNodo;
                ultimo = newNodo;
            }
            // si la lista no está vacía, el nuevo nodo se agrega al final y se actualiza el último nodo
            else
            {
                ultimo.Next = newNodo;
                ultimo = newNodo;
            }
            //incrementar el contador de nodos en la lista
            count++;
        }

        //metodo para obtener la lista de estudiantes
        public List<E> ObtenerLista()
        {
            //crear una lista para almacenar los datos de los estudiantes
            List<E> datos = new List<E>();
            //recorrer la lista enlazada y agregar los valores de cada nodo a la lista de datos
            Nodo<E> actual = Cabeza;
            //mientras el nodo actual no sea nulo, agregar su valor a la lista de datos y avanzar al siguiente nodo
            while (actual != null)

            {
                //agregar el valor del nodo actual a la lista de datos
                datos.Add(actual.Value);
                actual = actual.Next;
            }
            //retornar la lista de datos de los estudiantes
            return datos;
        }

        //metodo para buscar un estudiante por su ID
        public Nodo<E> BuscarEstudiante(string id)
        {
            //recorrer la lista enlazada para encontrar el estudiante con el ID especificado
            Nodo<E> actual = Cabeza;
            //mientras el nodo actual no sea nulo, verificar si su valor es un estudiante con el ID buscado
            while (actual != null)
            {
                //verificar si el valor del nodo actual es un objeto de tipo DatosEstudiantes y si su ID coincide con el ID buscado
                if (actual.Value is DatosEstudiantes estudiante && estudiante.ID == id)
                {
                    return actual;
                }
                //avanzar al siguiente nodo
                actual = actual.Next;
            }
            // No se encontró el estudiante
            return null; 
        }
        //metodo para eliminar un estudiante por su ID
        public Nodo<E> EliminarEstudiante(string id)
        {
            if (IsEmpty)
            { // La lista está vacía
                return null; 
            }

            Nodo<E> actual = Cabeza;
            Nodo<E> anterior = null;
            // Recorrer la lista para encontrar el nodo con el estudiante a eliminar
            while (actual != null)
            {
                // Verificar si el nodo actual contiene el estudiante con el ID especificado
                if (actual.Value is DatosEstudiantes estudiante && estudiante.ID == id)
                {
                    if (anterior == null)
                    {
                        // El nodo a eliminar es la cabeza
                        Cabeza = actual.Next;
                    }
                    else
                    {
                        // El nodo a eliminar está en medio o al final
                        anterior.Next = actual.Next;
                    }
                    // Si el nodo a eliminar es el último, actualizar el puntero del último nodo
                    if (actual.Next == null)
                    {
                        // El nodo a eliminar es el último
                        ultimo = anterior;
                    }

                    count--;
                    // Retorna el nodo eliminado
                    return actual; 
                }
                // Avanzar al siguiente nodo
                anterior = actual;
                actual = actual.Next;
            }
            // No se encontró el estudiante
            return null; 
        }
    }
}
