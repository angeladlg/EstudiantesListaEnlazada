using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EstudiantesListaEnlazada
{
    public partial class Form1 : Form
    {
        // Crear una instancia de la lista enlazada para almacenar los datos de los estudiantes
        ListaE<DatosEstudiantes> listaE = new ListaE<DatosEstudiantes>();
        public Form1()
        {
            InitializeComponent();

        }
        private void btnAgregar_Click_1(object sender, EventArgs e)
        {
            // Validar que los campos no estén vacíos antes de agregar un nuevo estudiante
            if (string.IsNullOrEmpty(txtId.Text) ||
               string.IsNullOrEmpty(txtNombre.Text) ||
               string.IsNullOrEmpty(txtGrado.Text))
            {
                MessageBox.Show("Complete todos los campos.");
                return;
            }
            // Crear un nuevo objeto DatosEstudiantes con los datos ingresados por el usuario
            DatosEstudiantes est = new DatosEstudiantes(
              txtId.Text,
              txtNombre.Text,
              txtGrado.Text
            );
            // Limpiar los campos de texto después de agregar el estudiante
            txtNombre.Text = string.Empty;
            txtId.Text = string.Empty;
            txtGrado.Text = string.Empty;

            // Insertar el nuevo estudiante al inicio de la lista enlazada
            listaE.InsertALaCabeza(est);
            // Actualizar el DataGridView para mostrar la lista actualizada de estudiantes
            dataGridViewDatos.DataSource = null;
            dataGridViewDatos.DataSource = listaE.ObtenerLista();

        }

        private void btnAMitad_Click(object sender, EventArgs e)
        {
            // Validar que los campos no estén vacíos antes de agregar un nuevo estudiante
            if (string.IsNullOrEmpty(txtId.Text) ||
               string.IsNullOrEmpty(txtNombre.Text) ||
               string.IsNullOrEmpty(txtGrado.Text))
            {
                MessageBox.Show("Complete todos los campos.");
                return;
            }
            // Crear un nuevo objeto DatosEstudiantes con los datos ingresados por el usuario
            DatosEstudiantes est = new DatosEstudiantes(
                txtId.Text,
                txtNombre.Text,
                txtGrado.Text
            );
            // Limpiar los campos de texto después de agregar el estudiante
            txtNombre.Text = string.Empty;
            txtId.Text = string.Empty;
            txtGrado.Text = string.Empty;
            // Insertar el nuevo estudiante al medio de la lista enlazada
            listaE.InsertarAlMedio(est);
            // Actualizar el DataGridView para mostrar la lista actualizada de estudiantes
            dataGridViewDatos.DataSource = null;
            dataGridViewDatos.DataSource = listaE.ObtenerLista();

        }

        private void btnAFinal_Click(object sender, EventArgs e)
        {
            // Validar que los campos no estén vacíos antes de agregar un nuevo estudiante
            if (string.IsNullOrEmpty(txtId.Text) ||
                   string.IsNullOrEmpty(txtNombre.Text) ||
                   string.IsNullOrEmpty(txtGrado.Text))
            {
                MessageBox.Show("Complete todos los campos.");
                return;
            }
            // Crear un nuevo objeto DatosEstudiantes con los datos ingresados por el usuario
            DatosEstudiantes est = new DatosEstudiantes(
                   txtId.Text,
                   txtNombre.Text,
                   txtGrado.Text
                 );
            // Limpiar los campos de texto después de agregar el estudiante
            txtNombre.Text = string.Empty;
            txtId.Text = string.Empty;
            txtGrado.Text = string.Empty;

            // Insertar el nuevo estudiante al final de la lista enlazada
            listaE.InsertarAlFinal(est);
            // Actualizar el DataGridView para mostrar la lista actualizada de estudiantes
            dataGridViewDatos.DataSource = null;
            dataGridViewDatos.DataSource = listaE.ObtenerLista();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            // Obtener el ID a buscar desde el campo de texto
            string idBuscar = txtBuscar.Text;
            bool encontrado = false;

            // Recorrer las filas del DataGridView para encontrar el estudiante con el ID especificado
            foreach (DataGridViewRow fila in dataGridViewDatos.Rows)
            {
                // Verificar si la celda "Id" no es nula y si su valor coincide con el ID a buscar
                if (fila.Cells["Id"].Value != null &&
                    fila.Cells["Id"].Value.ToString() == idBuscar)
                {
                    // Seleccionar la fila encontrada en el DataGridView
                    fila.Selected = true;
                    dataGridViewDatos.CurrentCell = fila.Cells[0];
                    encontrado = true;
                    break;

                }
                // Limpiar el campo de texto de búsqueda después de realizar la búsqueda
                txtBuscar.Text = string.Empty;

            }
            // Mostrar un mensaje si el campo de búsqueda está vacío o si no se encontró el estudiante
            if (string.IsNullOrEmpty(idBuscar))
            {
                MessageBox.Show("Ingrese de primero el ID del estudiante.");

            }
                if (!encontrado)
                {
                    MessageBox.Show("Estudiante no encontrado.");
                }
            
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            // Verificar si hay una fila seleccionada en el DataGridView
            if (dataGridViewDatos.SelectedRows.Count > 0)
            {
                // Obtener el ID de la fila seleccionada
                string idEliminar = dataGridViewDatos.SelectedRows[0].Cells["Id"].Value.ToString();
                // Eliminar el estudiante de la lista enlazada utilizando el ID obtenido
                Nodo<DatosEstudiantes> eliminado = listaE.EliminarEstudiante(idEliminar);
                // Mostrar un mensaje de confirmación si el estudiante fue eliminado correctamente
                if (eliminado != null)
                {
                    MessageBox.Show("Estudiante eliminado correctamente.");

                    // Actualizar DataGridView
                    dataGridViewDatos.DataSource = null;
                    dataGridViewDatos.DataSource = listaE.ObtenerLista();
                }
            }// Mostrar un mensaje si no hay ninguna fila seleccionada en el DataGridView
            else
            {
                MessageBox.Show("Seleccione un estudiante en la tabla.");
            }
        }
    }
}
