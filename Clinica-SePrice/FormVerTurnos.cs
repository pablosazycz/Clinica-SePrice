using Clinica_SePrice.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using Org.BouncyCastle.Tls;
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
    public partial class FormVerTurnos : Form
    {
        private ClinicaContext dbContext;

        public FormVerTurnos()
        {
        }

        public FormVerTurnos(ClinicaContext dbContext)
        {
            this.dbContext = dbContext;
            InitializeComponent();
            ActualizarDataGridView();

        }

        private void ActualizarDataGridView()
        {
            var turnosNoValidados = dbContext.Turnos.Where(t => !t.Validado).ToList();

            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("IdColumn", "ID");
            dataGridView1.Columns.Add("FechaColumn", "Fecha");
            dataGridView1.Columns.Add("HoraColumn", "Hora");
            dataGridView1.Columns.Add("LugarColumn", "Consultorio");
            dataGridView1.Columns.Add("MedicoColumn", "Médico");
            dataGridView1.Columns.Add("NombrePacienteColumn", "Nombre Paciente");
            dataGridView1.Columns.Add("ApellidoPacienteColumn", "Apellido Paciente");
            dataGridView1.Columns.Add("DniPacienteColumn", "DNI Paciente");

            DataGridViewButtonColumn columnaBoton = new DataGridViewButtonColumn();
            columnaBoton.Name = "Verificar Llegada";
            columnaBoton.HeaderText = "Verificar Llegada";
            columnaBoton.Text = "Verificar";
            columnaBoton.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(columnaBoton);
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            foreach (var turno in turnosNoValidados)
            {
                dataGridView1.Rows.Add(
                    turno.Id,
                    turno.Fecha.ToShortDateString(),
                    turno.Fecha.ToShortTimeString(),
                    turno.Lugar,
                    turno.Medico.NombreCompleto,
                    turno.Paciente.Nombre,
                    turno.Paciente.Apellido,
                    turno.Paciente.Dni
                );
            }
        }

        private void FiltroPaciente(string filtro)
        {
            var turnosFiltrados = dbContext.Turnos
                                    .Include("Medico")
                                    .Include("Paciente")
                                    .Where(t => !t.Validado && (t.Paciente.Nombre.Contains(filtro) || t.Paciente.Apellido.Contains(filtro) || t.Paciente.Dni.Contains(filtro)))
                                    .ToList();


            dataGridView1.Rows.Clear();

            foreach (var turno in turnosFiltrados)
            {
                dataGridView1.Rows.Add(
                    turno.Id,
                    turno.Fecha.ToShortDateString(),
                    turno.Fecha.ToShortTimeString(),
                    turno.Lugar,
                    turno.Medico.NombreCompleto,
                    turno.Paciente.Nombre,
                    turno.Paciente.Apellido,
                    turno.Paciente.Dni
                );
            }
        }

        private void txtBuscarTurnos_TextChanged(object sender, EventArgs e)
        {
            string filtro = txtBuscarTurnos.Text;
            FiltroPaciente(filtro);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dataGridView1.Columns["Verificar Llegada"].Index)
            {
                int indiceTurno = e.RowIndex;
                int idTurno = Convert.ToInt32(dataGridView1.Rows[indiceTurno].Cells["IdColumn"].Value);

                DialogResult result = MessageBox.Show("¿Desea marcar el turno como verificado?", "Verificar Llegada", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    var turno = dbContext.Turnos.Find(idTurno);

                    if (turno != null)
                    {
                        // Actualizar el campo "Validado" a true
                        turno.Validado = true;

                        // Guardar los cambios en la base de datos
                        dbContext.SaveChanges();

                        // Crear la sala de espera
                        SalaEspera salaEspera = new SalaEspera
                        {
                            HoraEntrada = DateTime.Now,
                            TurnoId = turno.Id
                        };

                        // Agregar la sala de espera a la base de datos
                        dbContext.SalaEspera.Add(salaEspera);
                        dbContext.SaveChanges();

                        // Obtener el id de la sala de espera recién creada
                        int idSalaEspera = salaEspera.Id;

                        // Actualizar el turno con el id de la sala de espera
                        turno.SalaEsperaId = idSalaEspera;
                        dbContext.SaveChanges();
                        dataGridView1.Rows.RemoveAt(indiceTurno);
                        // Resto del código para actualizar la interfaz de usuario
                    }
                    else
                    {
                        MessageBox.Show("No se pudo encontrar el turno correspondiente en la base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }




    }
}

