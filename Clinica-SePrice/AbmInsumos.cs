using Clinica_SePrice.Entidades;
using Microsoft.EntityFrameworkCore;
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
    public partial class AbmInsumos : Form
    {
        private ClinicaContext dbContext;

        public AbmInsumos(ClinicaContext dbContext)
        {
            InitializeComponent();
            this.dbContext = dbContext;
            InitializeDataGridView();
            CargarInsumos();
            dataGridView1.Enabled = false;
            dataGridView1.ReadOnly = true;
        }

        private void InitializeDataGridView()
        {
            DataGridViewComboBoxColumn insumoColumn = new DataGridViewComboBoxColumn();
            insumoColumn.HeaderText = "Insumo";
            insumoColumn.Name = "Insumo";
            insumoColumn.DataPropertyName = "Id"; 
            dataGridView1.Columns.Add(insumoColumn);

  
            DataGridViewTextBoxColumn stockActualColumn = new DataGridViewTextBoxColumn();
            stockActualColumn.HeaderText = "Stock Actual";
            stockActualColumn.Name = "StockActual";
            stockActualColumn.ReadOnly = true;
            dataGridView1.Columns.Add(stockActualColumn);

        
            DataGridViewTextBoxColumn cantidadUsadaColumn = new DataGridViewTextBoxColumn();
            cantidadUsadaColumn.HeaderText = "Cantidad Usada";
            cantidadUsadaColumn.Name = "CantidadUsada";
            dataGridView1.Columns.Add(cantidadUsadaColumn);
        }

        private void CargarInsumos()
        {
            using (dbContext = new ClinicaContext())
            {
                var insumos = dbContext.Insumos.Select(i => new { i.Id, i.Descripcion }).ToList();
                DataGridViewComboBoxColumn comboBoxColumn = (DataGridViewComboBoxColumn)dataGridView1.Columns["Insumo"];
                comboBoxColumn.DataSource = insumos;
                comboBoxColumn.DisplayMember = "Descripcion";
                comboBoxColumn.ValueMember = "Id";
            }
        }

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dataGridView1.CurrentCell.ColumnIndex == dataGridView1.Columns["Insumo"].Index && e.Control is ComboBox comboBox)
            {
                comboBox.SelectedIndexChanged -= ComboBox_SelectedIndexChanged;
                comboBox.SelectedIndexChanged += ComboBox_SelectedIndexChanged;
            }
        }

        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ComboBox comboBox = sender as ComboBox;
                if (comboBox != null)
                {
                    var selectedItem = comboBox.SelectedItem as dynamic;
                    if (selectedItem != null)
                    {
                      
                        int selectedInsumoId = selectedItem.Id;

                        using (dbContext = new ClinicaContext())
                        {
                            var insumo = dbContext.Insumos.SingleOrDefault(i => i.Id == selectedInsumoId);
                            if (insumo != null)
                            {
                                dataGridView1.CurrentRow.Cells["StockActual"].Value = insumo.StockActual;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error: {ex.Message}");
            }
        }



        private void btnAgregarRenglon_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Add();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        private void LlenarInformacionDelTurno(int idTurno)
        {
            using (var dbContext = new ClinicaContext())
            {

                var turno = dbContext.Turnos
                    .Include(t => t.Paciente)
                    .Include(t => t.Medico)
                    .Include(t => t.Estudio)
                    .FirstOrDefault(t => t.Id == idTurno);

                if (turno != null)
                {

                    txtNombre.Text = turno.Paciente != null ? turno.Paciente.Nombre : "No disponible";
                    txtApellido.Text = turno.Paciente != null ? turno.Paciente.Apellido : "No disponible";
                    txtDni.Text = turno.Paciente != null ? turno.Paciente.Dni : "No disponible";

                    if (turno.Medico != null)
                    {
                        txtNombreMedico.Text = turno.Medico.Nombre != null ? turno.Medico.NombreCompleto : "No disponible";
                        txtBoxEspecialidadMedico.Text = turno.Medico != null ? turno.Medico.Especialidad : "No disponible";
                    }
                    else
                    {
                        txtNombreMedico.Text = "No disponible";
                        txtBoxEspecialidadMedico.Text = "No disponible";
                    }
                    txtBoxEspecialidadMedico.Text = turno.Medico != null ? turno.Medico.Especialidad : "No disponible";

                    txtBoxNombreEstudio.Text = turno.Estudio != null ? turno.Estudio.Nombre : "No disponible";

                    if (turno.Estudio != null)
                    {

                        var especialidades = dbContext.EspecialidadesEstudiosMedicos
                            .Where(e => e.EstudioMedicoId == turno.Estudio.Id)
                            .Select(e => e.Especialidad.Nombre)
                            .ToList();


                        string especialidadesStr = string.Join(", ", especialidades);

                        txtBoxEspecialidadEstudio.Text = !string.IsNullOrEmpty(especialidadesStr) ? especialidadesStr : "No disponible";
                    }
                    else
                    {

                        txtBoxEspecialidadEstudio.Text = "No disponible";
                    }

                    dataGridView1.Enabled = turno != null;
                    dataGridView1.ReadOnly = turno == null;

                }
                else
                {

                    MessageBox.Show("El turno no pudo ser encontrado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtBoxIdTurno.Text, out int idTurno))
            {

                LlenarInformacionDelTurno(idTurno);
            }
            else
            {
                MessageBox.Show("Por favor, ingrese un ID de turno válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void limpiar()
        {

            txtBoxIdTurno.Clear();
            txtNombre.Clear();
            txtApellido.Clear();
            txtDni.Clear();
            txtNombreMedico.Clear();
            txtBoxEspecialidadMedico.Clear();
            txtBoxNombreEstudio.Clear();
            txtBoxEspecialidadEstudio.Clear();

            dataGridView1.Rows.Clear();
        }

        private int ObtenerIdInsumoSeleccionado()
        {
            int idInsumo = -1;
            if (dataGridView1.CurrentRow != null && dataGridView1.CurrentRow.Cells["Insumo"] != null)
            {
                var cellValue = dataGridView1.CurrentRow.Cells["Insumo"].Value;
                if (cellValue != null && int.TryParse(cellValue.ToString(), out idInsumo))
                {
                    return idInsumo;
                }
            }

            MessageBox.Show("Por favor, seleccione un insumo válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return idInsumo;
        }

        private int ObtenerCantidadUtilizada()
        {
            int cantidadUtilizada = 0;
            if (dataGridView1.CurrentRow != null && dataGridView1.CurrentRow.Cells["CantidadUsada"] != null)
            {
                var cellValue = dataGridView1.CurrentRow.Cells["CantidadUsada"].Value;
                if (cellValue != null && int.TryParse(cellValue.ToString(), out cantidadUtilizada))
                {
                    return cantidadUtilizada;
                }
            }

            MessageBox.Show("Por favor, ingrese una cantidad utilizada válida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return cantidadUtilizada;
        }

        private void GuardarTransaccion()
        {
            try
            {
                using (var dbContext = new ClinicaContext())
                {
                    int idTurno = int.Parse(txtBoxIdTurno.Text);

                    var turnoExistente = dbContext.Turnos.Any(t => t.Id == idTurno);
                    if (!turnoExistente)
                    {
                        MessageBox.Show("El turno seleccionado no existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        int idInsumo = -1;
                        int cantidadUtilizada = 0;

                        if (row.Cells["Insumo"].Value != null && row.Cells["CantidadUsada"].Value != null)
                        {
                            idInsumo = Convert.ToInt32(row.Cells["Insumo"].Value);
                            cantidadUtilizada = Convert.ToInt32(row.Cells["CantidadUsada"].Value);
                        }
                        else
                        {
                            continue;
                        }

                        var insumo = dbContext.Insumos.FirstOrDefault(i => i.Id == idInsumo);
                        if (insumo == null)
                        {
                            MessageBox.Show("El insumo seleccionado no existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        if (cantidadUtilizada <= 0)
                        {
                            MessageBox.Show("La cantidad utilizada debe ser mayor que cero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        var transaccion = new TransaccionInsumo
                        {
                            InsumoId = idInsumo,
                            CantidadUtilizada = cantidadUtilizada,
                            Fecha = DateTime.Now,
                            TurnoId = idTurno
                        };


                        dbContext.TransaccionesInsumos.Add(transaccion);
                        insumo.StockActual -= cantidadUtilizada;
                    }


                    dbContext.SaveChanges();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al guardar las transacciones: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBoxIdTurno.Text))
            {
                MessageBox.Show("Por favor, busque y seleccione un turno antes de guardar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {

                GuardarTransaccion();


                limpiar();


                MessageBox.Show("Transacciones guardadas exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {

                MessageBox.Show($"Error al guardar las transacciones: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void ReponerStock()
        {
            try
            {
                using (var dbContext = new ClinicaContext())
                {
                    var insumos = dbContext.Insumos.ToList();
                    foreach (var insumo in insumos)
                    {
                        insumo.StockActual = insumo.StockMaximo;
                    }
                    dbContext.SaveChanges();
                    MessageBox.Show("Stocks repuestos correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al reponer los stocks: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReponerStock_Click(object sender, EventArgs e)
        {
            ReponerStock();
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
