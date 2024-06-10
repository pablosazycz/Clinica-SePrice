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
    public partial class FormSalaEspera : Form
    {
        private ClinicaContext dbContext;

        public FormSalaEspera(ClinicaContext dbContext)
        {
            InitializeComponent();
            this.dbContext = dbContext;
            ActualizarDataGridView();
        }

        private void ActualizarDataGridView()
        {
            var turnosValidadosEnSalaEspera = dbContext.SalaEspera
       .Include(se => se.Turno.Paciente)
       .Where(se => se.Turno.Validado && se.HoraLlamado == null)
       .ToList();

            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("IdColumn", "ID");
            dataGridView1.Columns.Add("HoraEntradaColumn", "Hora de Entrada");
            dataGridView1.Columns.Add("HoraLlamadoColumn", "Hora de Llamado");
            dataGridView1.Columns.Add("NombrePacienteColumn", "Nombre Paciente");
            dataGridView1.Columns.Add("ApellidoPacienteColumn", "Apellido Paciente");
            dataGridView1.Columns.Add("DniPacienteColumn", "DNI Paciente");

            DataGridViewButtonColumn columnaBoton = new DataGridViewButtonColumn();
            columnaBoton.Name = "Llamar Paciente";
            columnaBoton.HeaderText = "Llamar Paciente";
            columnaBoton.Text = "Llamar";
            columnaBoton.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(columnaBoton);
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            foreach (var salaEspera in turnosValidadosEnSalaEspera)
            {
                if (salaEspera.Turno != null)
                {
                    string nombrePaciente = salaEspera.Turno.Paciente != null ? salaEspera.Turno.Paciente.Nombre : "N/A";
                    string apellidoPaciente = salaEspera.Turno.Paciente != null ? salaEspera.Turno.Paciente.Apellido : "N/A";
                    string dniPaciente = salaEspera.Turno.Paciente != null ? salaEspera.Turno.Paciente.Dni : "N/A";

                    dataGridView1.Rows.Add(
                        salaEspera.Id,
                        salaEspera.HoraEntrada.ToShortTimeString(),
                        salaEspera.HoraLlamado.HasValue ? salaEspera.HoraLlamado.Value.ToShortTimeString() : "No llamado",
                        nombrePaciente,
                        apellidoPaciente,
                        dniPaciente);
                }
                else
                {

                    dataGridView1.Rows.Add(
                        salaEspera.Id,
                        salaEspera.HoraEntrada.ToShortTimeString(),
                        salaEspera.HoraLlamado.HasValue ? salaEspera.HoraLlamado.Value.ToShortTimeString() : "No llamado",
                        "N/A",
                        "N/A",
                        "N/A");
                }
            }
        }


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dataGridView1.Columns["Llamar Paciente"].Index)
            {

                int indiceTurno = e.RowIndex;
                int idSalaEspera = (int)dataGridView1.Rows[indiceTurno].Cells["IdColumn"].Value;

                DialogResult dialogResult = MessageBox.Show("¿Llamar al paciente?", "Llamar Paciente", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    var salaEspera = dbContext.SalaEspera.FirstOrDefault(se => se.Id == idSalaEspera);
                    if (salaEspera != null)
                    {
                        salaEspera.HoraLlamado = DateTime.Now;
                        dbContext.SaveChanges();
                        dataGridView1.Rows.RemoveAt(indiceTurno);
                        MessageBox.Show("Paciente llamado", "Llamado", MessageBoxButtons.OK);
                    }
                    else
                    {
                        MessageBox.Show("No se encontró el registro de la sala de espera.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ActualizarDataGridView();
        }
    }
}
