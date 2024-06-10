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
               
        public FormVerTurnos(ClinicaContext dbContext)
        {
            this.dbContext = dbContext;
            InitializeComponent();
            ActualizarDataGridView();

        }

        private void ActualizarDataGridView()
        {
            var turnosNoValidados = dbContext.Turnos
                                .Include(t => t.Medico)
                                .Include(t => t.Paciente)
                                .Where(t => !t.Validado && t.MedicoId != null)
                                .ToList();

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
                    turno.Lugar ?? "N/A",
                    turno.Medico?.NombreCompleto ?? "N/A",
                    turno.Paciente?.Nombre ?? "N/A",
                    turno.Paciente?.Apellido ?? "N/A",
                    turno.Paciente?.Dni ?? "N/A"
                );
            }

            var turnosNoValidadosEstudios = dbContext.Turnos
                                .Include(t => t.Estudio)
                                .Include(t => t.Paciente)
                                .Where(t => !t.Validado && t.EstudioMedicoId != 0 && t.EstudioMedicoId != null)
                                .ToList();

            dataGridView2.Columns.Clear();
            dataGridView2.Columns.Add("IdColumn", "ID");
            dataGridView2.Columns.Add("FechaColumn", "Fecha");
            dataGridView2.Columns.Add("HoraColumn", "Hora");
            dataGridView2.Columns.Add("EstudioColumn", "Estudio Médico");
            dataGridView2.Columns.Add("NombrePacienteColumn", "Nombre Paciente");
            dataGridView2.Columns.Add("ApellidoPacienteColumn", "Apellido Paciente");
            dataGridView2.Columns.Add("DniPacienteColumn", "DNI Paciente");

            DataGridViewButtonColumn columnaBoton2 = new DataGridViewButtonColumn();
            columnaBoton2.Name = "Verificar Llegada";
            columnaBoton2.HeaderText = "Verificar Llegada";
            columnaBoton2.Text = "Verificar";
            columnaBoton2.UseColumnTextForButtonValue = true;
            dataGridView2.Columns.Add(columnaBoton2);
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            foreach (var turno in turnosNoValidadosEstudios)
            {
                dataGridView2.Rows.Add(
                    turno.Id,
                    turno.Fecha.ToShortDateString(),
                    turno.Fecha.ToShortTimeString(),
                    turno.Estudio?.Nombre ?? "N/A",
                    turno.Paciente?.Nombre ?? "N/A",
                    turno.Paciente?.Apellido ?? "N/A",
                    turno.Paciente?.Dni ?? "N/A"
                );
            }
        }

        private void FiltroPaciente(string filtro)
        {
            var turnosMedicosFiltrados = dbContext.Turnos
                .Include(t => t.Medico)
                .Include(t => t.Paciente)
                .Where(t => t.MedicoId != null && !t.Validado &&
                            (t.Paciente.Nombre.Contains(filtro) ||
                             t.Paciente.Apellido.Contains(filtro) ||
                             t.Paciente.Dni.Contains(filtro)))
                .ToList();

            var turnosEstudiosFiltrados = dbContext.Turnos
                .Include(t => t.Estudio)
                .Include(t => t.Paciente)
                .Where(t => t.EstudioMedicoId != null && !t.Validado &&
                            (t.Paciente.Nombre.Contains(filtro) ||
                             t.Paciente.Apellido.Contains(filtro) ||
                             t.Paciente.Dni.Contains(filtro)))
                .ToList();

          
            ActualizarDataGridView(dataGridView1, turnosMedicosFiltrados, isMedico: true);
            ActualizarDataGridView(dataGridView2, turnosEstudiosFiltrados, isMedico: false);
        }

        private void ActualizarDataGridView(DataGridView dgv, List<Turno> turnos, bool isMedico)
        {
            dgv.Rows.Clear();
            foreach (var turno in turnos)
            {
                if (isMedico)
                {
                    dgv.Rows.Add(
                        turno.Id,
                        turno.Fecha.ToShortDateString(),
                        turno.Fecha.ToShortTimeString(),
                        turno.Lugar ?? "N/A",
                        turno.Medico?.NombreCompleto ?? "N/A",
                        turno.Paciente?.Nombre ?? "N/A",
                        turno.Paciente?.Apellido ?? "N/A",
                        turno.Paciente?.Dni ?? "N/A"
                    );
                }
                else
                {
                    dgv.Rows.Add(
                        turno.Id,
                        turno.Fecha.ToShortDateString(),
                        turno.Fecha.ToShortTimeString(),
                        turno.Estudio?.Nombre ?? "N/A",
                        turno.Paciente?.Nombre ?? "N/A",
                        turno.Paciente?.Apellido ?? "N/A",
                        turno.Paciente?.Dni ?? "N/A"
                    );
                }
            }

            // Agregar mensaje de no hay turnos si no hay datos
            if (dgv.Rows.Count == 0)
            {
                dgv.Rows.Add("No hay turnos sin validar");
            }
        }

        private void txtBuscarTurnos_TextChanged(object sender, EventArgs e)
        {
            string filtro = txtBuscarTurnos.Text;
            FiltroPaciente(filtro);
        }
 
        private void VerificarLlegada(DataGridView dataGridView, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dataGridView.Columns["Verificar Llegada"].Index)
            {
                int indiceTurno = e.RowIndex;
                int idTurno = Convert.ToInt32(dataGridView.Rows[indiceTurno].Cells["IdColumn"].Value);

                FormPago formPago = new FormPago(this, idTurno, dbContext);
                DialogResult pagoResult = formPago.ShowDialog();

                if (pagoResult == DialogResult.OK)
                {
                    DialogResult result = MessageBox.Show("¿Desea marcar el turno como verificado?", "Verificar Llegada", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        var turno = dbContext.Turnos.Find(idTurno);

                        if (turno != null)
                        {
                            turno.Validado = true;
                            dbContext.SaveChanges();

                            SalaEspera salaEspera = new SalaEspera
                            {
                                HoraEntrada = DateTime.Now,
                                TurnoId = turno.Id
                            };

                            dbContext.SalaEspera.Add(salaEspera);
                            dbContext.SaveChanges();

                            int idSalaEspera = salaEspera.Id;
                            turno.SalaEsperaId = idSalaEspera;
                            dbContext.SaveChanges();
                            //dataGridView.Rows.RemoveAt(indiceTurno);
                        }
                        else
                        {
                            MessageBox.Show("No se pudo encontrar el turno correspondiente en la base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                
            }
        }

        public void MarcarLlegada(int turnoId)
        {
            var turno = dbContext.Turnos.Find(turnoId);
            if (turno != null)
            {
                turno.Validado = true;
                dbContext.SaveChanges();
                ActualizarDataGridView();
            }
        }


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            VerificarLlegada(dataGridView1, e);
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            VerificarLlegada(dataGridView2, e);
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            txtBuscarTurnos.Text = "";
        }

        public void GenerarRecibo(int idTurno)
        {
            var turno = dbContext.Turnos.Include(t => t.Paciente).Include(t => t.Estudio).FirstOrDefault(t => t.Id == idTurno);

            if (turno != null && turno.Estudio != null)
            {
                Recibo recibo = new Recibo(turno);
            }
            else
            {
                throw new InvalidOperationException("El recibo solo puede generarse para turnos de estudios médicos.");
            }
        }




    }
}

