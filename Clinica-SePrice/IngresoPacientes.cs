using Clinica_SePrice.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clinica_SePrice
{
    public partial class IngresoPacientes : Form
    {
        private ClinicaContext dbContext;
        public IngresoPacientes(ClinicaContext dbContext)
        {
            this.dbContext = dbContext;
            InitializeComponent();
            ConfigurarDataGridView();
            ActualizarDataGridView();
        }

        private void ConfigurarDataGridView()
        {
            // Asegúrate de que las columnas estén configuradas correctamente
            dataGridView1.Columns.Clear();

            dataGridView1.Columns.Add("IdColumn", "ID");
            dataGridView1.Columns.Add("NombreColumn", "Nombre");
            dataGridView1.Columns.Add("ApellidoColumn", "Apellido");
            dataGridView1.Columns.Add("DniColumn", "DNI");

            // Establece el modo de ajuste automático para que las columnas se ajusten al contenido
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow filaSeleccionada = dataGridView1.SelectedRows[0];
                txtNombre.Text = filaSeleccionada.Cells["NombreColumn"].Value.ToString();
                txtApellido.Text = filaSeleccionada.Cells["ApellidoColumn"].Value.ToString();
                txtDni.Text = filaSeleccionada.Cells["DniColumn"].Value.ToString();
            }
        }

        private void ActualizarDataGridView()
        {
            var pacientes = dbContext.Pacientes.ToList();
            dataGridView1.Rows.Clear();

            foreach (var paciente in pacientes)
            {
                dataGridView1.Rows.Add(
                    paciente.Id,
                    paciente.Nombre,
                    paciente.Apellido,
                    paciente.Dni
                );
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNombre.Text) || string.IsNullOrEmpty(txtApellido.Text) || string.IsNullOrEmpty(txtDni.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos obligatorios.", "Campos Incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Paciente nuevoPaciente = new Paciente
            {
                Nombre = txtNombre.Text,
                Apellido = txtApellido.Text,
                Dni = txtDni.Text,
                //Direccion = txtDireccion.Text,
                //Telefono = txtTelefono.Text,
                //Email = txtEmail.Text
            };

            dbContext.Pacientes.Add(nuevoPaciente);
            dbContext.SaveChanges();
            LimpiarControles();
            ActualizarDataGridView();
            MessageBox.Show("Paciente guardado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void LimpiarControles()
        {
            txtNombre.Clear();
            txtApellido.Clear();
            txtDni.Clear();
            //txtDireccion.Clear();
            //txtTelefono.Clear();
            //txtEmail.Clear();
        }



        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, seleccione un paciente para modificar.", "Selección Requerida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int pacienteId = (int)dataGridView1.SelectedRows[0].Cells["IdColumn"].Value;

            Paciente pacienteAModificar = dbContext.Pacientes.Find(pacienteId);
            if (pacienteAModificar != null)
            {
                pacienteAModificar.Nombre = txtNombre.Text;
                pacienteAModificar.Apellido = txtApellido.Text;
                pacienteAModificar.Dni = txtDni.Text;
                //pacienteAModificar.Direccion = txtDireccion.Text;
                //pacienteAModificar.Telefono = txtTelefono.Text;
                //pacienteAModificar.Email = txtEmail.Text;

                dbContext.SaveChanges();
                LimpiarControles();
                ActualizarDataGridView();
                MessageBox.Show("Paciente modificado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, seleccione un paciente para eliminar.", "Selección Requerida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int pacienteId = (int)dataGridView1.SelectedRows[0].Cells["IdColumn"].Value;

            Paciente pacienteAEliminar = dbContext.Pacientes.Find(pacienteId);
            if (pacienteAEliminar != null)
            {
                dbContext.Pacientes.Remove(pacienteAEliminar);
                dbContext.SaveChanges();
                ActualizarDataGridView();
                MessageBox.Show("Paciente eliminado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            string filtro = txtBuscar.Text;
            FiltroPaciente(filtro);
        }

        private void FiltroPaciente(string filtro)
        {
            var pacientes = dbContext.Pacientes.Where(p => p.Nombre.Contains(filtro) || p.Apellido.Contains(filtro) || p.Dni.Contains(filtro)).ToList();
            dataGridView1.Rows.Clear();

            foreach (var paciente in pacientes)
            {
                dataGridView1.Rows.Add(paciente.Id, paciente.Nombre, paciente.Apellido, paciente.Dni);
            }
        }

        private void btnLimpiarFiltro_Click(object sender, EventArgs e)
        {
            txtBuscar.Clear();
        }
    }
}
