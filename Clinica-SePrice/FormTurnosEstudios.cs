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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Clinica_SePrice
{
    public partial class FormTurnosEstudios : Form
    {
        private ClinicaContext dbContext;
        public FormTurnosEstudios(ClinicaContext dbContext)
        {
            this.dbContext = dbContext;
            InitializeComponent();
            CargarEspecialidades();

            InicializarDateTimePicker();
            if (cmbEspecialidad.SelectedItem is Especialidad selectedEspecialidad)
            {
                CargarEstudiosMedicosPorEspecialidad(selectedEspecialidad.Id);
            }
            ActualizarDataGridView();
        }
        private void CargarEspecialidades()
        {
            var especialidades = dbContext.Especialidades.ToList();
            cmbEspecialidad.DataSource = especialidades;
            cmbEspecialidad.DisplayMember = "Nombre";
            cmbEspecialidad.ValueMember = "Id";
        }
        private void InicializarDateTimePicker()
        {
            DateTime proximaFechaHoraDisponible = DateTime.Today.AddHours(8);

            if (proximaFechaHoraDisponible.DayOfWeek == DayOfWeek.Saturday)
            {
                proximaFechaHoraDisponible = proximaFechaHoraDisponible.AddDays(2).Date.AddHours(8);
            }
            else if (proximaFechaHoraDisponible.DayOfWeek == DayOfWeek.Sunday)
            {
                proximaFechaHoraDisponible = proximaFechaHoraDisponible.AddDays(1).Date.AddHours(8);
            }

            dateTimePicker1.Value = proximaFechaHoraDisponible;
        }
        private void cmbEspecialidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbEspecialidad.SelectedItem is Especialidad selectedEspecialidad)
            {
                CargarEstudiosMedicosPorEspecialidad(selectedEspecialidad.Id);
            }

        }
        private void CargarEstudiosMedicosPorEspecialidad(int especialidadId)
        {
            var estudios = dbContext.EspecialidadesEstudiosMedicos
                .Where(e => e.EspecialidadId == especialidadId)
                .Select(e => e.EstudioMedico)
                .ToList();

            cmbEstudioMedico.DataSource = estudios;
            cmbEstudioMedico.DisplayMember = "Nombre";
            cmbEstudioMedico.ValueMember = "Id";

            if (cmbEstudioMedico.SelectedItem != null)
            {
                EstudioMedico estudioMedicoSeleccionado = (EstudioMedico)cmbEstudioMedico.SelectedItem;
                DateTime proximaFechaHoraDisponible = CalcularProximoTurnoDisponible(estudioMedicoSeleccionado);
                dateTimePicker1.Value = proximaFechaHoraDisponible;
            }
        }
        private void LimpiarControles()
        {
            txtNombre.Clear();
            txtApellido.Clear();
            txtDni.Clear();
            textBox4.Clear();
            cmbEstudioMedico.SelectedIndex = -1;
            cmbEspecialidad.SelectedIndex = -1;


            DateTime fecha = DateTime.Today;
            if (fecha.DayOfWeek == DayOfWeek.Saturday)
            {
                fecha = fecha.AddDays(2);
            }
            else if (fecha.DayOfWeek == DayOfWeek.Sunday)
            {
                fecha = fecha.AddDays(1);
            }

            dateTimePicker1.Value = fecha;
        }
        private void button1_Click(object sender, EventArgs e) //agendar
        {
            if (string.IsNullOrEmpty(txtNombre.Text) || string.IsNullOrEmpty(txtApellido.Text) || string.IsNullOrEmpty(txtDni.Text) || string.IsNullOrEmpty(textBox4.Text) || cmbEspecialidad.SelectedItem == null)
            {
                MessageBox.Show("Por favor, complete todos los campos para agendar la cita.", "Campos Incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool sobreturno = chkSobreturno.Checked;
            string nombrePaciente = txtNombre.Text;
            string apellidoPaciente = txtApellido.Text;
            string dniPaciente = txtDni.Text;
            EstudioMedico estudioMedico = (EstudioMedico)cmbEstudioMedico.SelectedItem;
            Especialidad especialidadSeleccionada = (Especialidad)cmbEspecialidad.SelectedItem;

            DateTime fechaHoraInicio = dateTimePicker1.Value;
            DateTime fechaHoraFin = fechaHoraInicio.AddMinutes(ObtenerDuracionMinimaTurno(especialidadSeleccionada.ToString()));

            bool turnoProgramado = VerificarTurnoProgramado(especialidadSeleccionada, fechaHoraInicio, fechaHoraFin);
            if (turnoProgramado && !sobreturno)
            {
                MessageBox.Show("Ya hay un turno programado para el estudio en la fecha y hora seleccionadas.", "Turno Programado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (fechaHoraInicio.DayOfWeek >= DayOfWeek.Monday && fechaHoraInicio.DayOfWeek <= DayOfWeek.Friday && fechaHoraInicio.Hour >= 8 && fechaHoraInicio.Hour < 18)
            {
                fechaHoraInicio = fechaHoraInicio.AddTicks(-(fechaHoraInicio.Ticks % TimeSpan.TicksPerMinute));
                fechaHoraFin = fechaHoraFin.AddTicks(-(fechaHoraFin.Ticks % TimeSpan.TicksPerMinute));

                Turno nuevoTurno = new Turno
                {
                    Fecha = fechaHoraInicio,
                    Estudio = estudioMedico,
                    Duracion = ObtenerDuracionMinimaTurno(especialidadSeleccionada.ToString()),
                    Sobreturno = sobreturno,
                    Paciente = new Paciente
                    {
                        Nombre = nombrePaciente,
                        Apellido = apellidoPaciente,
                        Dni = dniPaciente,
                        EnSalaEspera = false
                    }
                };

                dbContext.Turnos.Add(nuevoTurno);
                dbContext.SaveChanges();
                LimpiarControles();
                ActualizarDataGridView();
                CargarEspecialidades();
                if (cmbEstudioMedico.SelectedItem != null)
                {
                    EstudioMedico estudioMedicoSeleccionado = (EstudioMedico)cmbEstudioMedico.SelectedItem;
                    DateTime proximaFechaHoraDisponible = CalcularProximoTurnoDisponible(estudioMedicoSeleccionado);
                    dateTimePicker1.Value = proximaFechaHoraDisponible;
                }
                else
                {
                    InicializarDateTimePicker();
                }
            }
            else
            {
                MessageBox.Show("El horario seleccionado no es válido. Por favor, seleccione un horario entre las 8:00 y las 18:00 de lunes a viernes.", "Horario Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private DateTime CalcularProximoTurnoDisponible(EstudioMedico estudioMedicoSeleccionado)
        {
            if (estudioMedicoSeleccionado == null)
            {
                throw new ArgumentNullException(nameof(estudioMedicoSeleccionado), "El estudio médico seleccionado es nulo.");
            }

            var turnos = dbContext.Turnos
                .Where(t => t.Estudio.Id == estudioMedicoSeleccionado.Id)
                .OrderBy(t => t.Fecha)
                .ToList();

            int duracionMinimaTurno = ObtenerDuracionMinimaTurno(estudioMedicoSeleccionado.Nombre);

            DateTime proximaHoraDisponible = DateTime.Now;

            if (proximaHoraDisponible.Hour < 8)
            {
                proximaHoraDisponible = proximaHoraDisponible.Date.AddHours(8);
            }
            else if (proximaHoraDisponible.Hour >= 18)
            {
                proximaHoraDisponible = proximaHoraDisponible.AddDays(1).Date.AddHours(8);
            }

            if (proximaHoraDisponible.DayOfWeek == DayOfWeek.Saturday)
            {
                proximaHoraDisponible = proximaHoraDisponible.AddDays(2).Date.AddHours(8);
            }
            else if (proximaHoraDisponible.DayOfWeek == DayOfWeek.Sunday)
            {
                proximaHoraDisponible = proximaHoraDisponible.AddDays(1).Date.AddHours(8);
            }

            if (turnos.Count != 0)
            {
                for (int i = 0; i < turnos.Count; i++)
                {
                    DateTime finTurnoActual = turnos[i].Fecha.AddMinutes(turnos[i].Duracion);

                    if (proximaHoraDisponible < turnos[i].Fecha)
                    {
                        if ((turnos[i].Fecha - proximaHoraDisponible).TotalMinutes >= duracionMinimaTurno)
                        {
                            break;
                        }
                    }

                    if (proximaHoraDisponible < finTurnoActual)
                    {
                        proximaHoraDisponible = finTurnoActual;
                    }
                }

                // Si la última hora disponible calculada está fuera del horario laboral, ajustar
                while (proximaHoraDisponible.Hour >= 18 || proximaHoraDisponible.Hour < 8 || proximaHoraDisponible.DayOfWeek == DayOfWeek.Saturday || proximaHoraDisponible.DayOfWeek == DayOfWeek.Sunday)
                {
                    if (proximaHoraDisponible.Hour >= 18)
                    {
                        proximaHoraDisponible = proximaHoraDisponible.AddDays(1).Date.AddHours(8);
                    }
                    else if (proximaHoraDisponible.Hour < 8)
                    {
                        proximaHoraDisponible = proximaHoraDisponible.Date.AddHours(8);
                    }

                    if (proximaHoraDisponible.DayOfWeek == DayOfWeek.Saturday)
                    {
                        proximaHoraDisponible = proximaHoraDisponible.AddDays(2).Date.AddHours(8);
                    }
                    else if (proximaHoraDisponible.DayOfWeek == DayOfWeek.Sunday)
                    {
                        proximaHoraDisponible = proximaHoraDisponible.AddDays(1).Date.AddHours(8);
                    }
                }
            }
            else
            {
                proximaHoraDisponible = DateTime.Today.AddHours(8);
                if (proximaHoraDisponible.DayOfWeek == DayOfWeek.Saturday)
                {
                    proximaHoraDisponible = proximaHoraDisponible.AddDays(2).Date.AddHours(8);
                }
                else if (proximaHoraDisponible.DayOfWeek == DayOfWeek.Sunday)
                {
                    proximaHoraDisponible = proximaHoraDisponible.AddDays(1).Date.AddHours(8);
                }
            }

            return proximaHoraDisponible;
        }


        private static int ObtenerDuracionMinimaTurno(String especialidad)
        {
            switch (especialidad)
            {
                case "Laboratorio":
                    return 15;
                case "Radiografia":
                    return 15;
                case "Ecografia":
                    return 20;
                case "Resonancia":
                    return 30;
                case "Tomografia":
                    return 30;
                default:
                    return 15;
            }
        }
        private bool VerificarTurnoProgramado(Especialidad especialidadSeleccionada, DateTime fechaHoraInicio, DateTime fechaHoraFin)
        {
            var turnos = dbContext.Turnos
                .Where(t => t.Estudio.Id == especialidadSeleccionada.Id && !t.Sobreturno)
                .ToList();

            foreach (var turno in turnos)
            {
                bool condicion1 = fechaHoraInicio >= turno.Fecha && fechaHoraInicio < turno.Fecha.AddMinutes(turno.Duracion);
                bool condicion2 = turno.Fecha >= fechaHoraInicio && turno.Fecha < fechaHoraFin;
                bool condicion3 = turno.Fecha <= fechaHoraInicio && turno.Fecha.AddMinutes(turno.Duracion) >= fechaHoraFin;

                if (condicion1 || condicion2 || condicion3)
                {
                    return true;
                }
            }

            return false;
        }

        private void ActualizarDataGridView()
        {
            var turnos = dbContext.Turnos
        .Where(t => t.EstudioMedicoId != null && !t.Validado)
        .Include(t => t.Estudio)
        .Include(t => t.Paciente)
        .ToList();
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("IdColumn", "ID");
            dataGridView1.Columns.Add("FechaColumn", "Fecha");
            dataGridView1.Columns.Add("HoraColumn", "Hora");
            dataGridView1.Columns.Add("EstudioColumn", "Estudio");
            dataGridView1.Columns.Add("NombrePacienteColumn", "Nombre Paciente");
            dataGridView1.Columns.Add("ApellidoPacienteColumn", "Apellido Paciente");
            dataGridView1.Columns.Add("DniPacienteColumn", "DNI Paciente");
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            foreach (var turno in turnos)
            {
                dataGridView1.Rows.Add(
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
        private bool ajusteDateTime = false;
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if (ajusteDateTime)
                return;

            DateTime fechaSeleccionada = dateTimePicker1.Value;

            if (fechaSeleccionada.DayOfWeek == DayOfWeek.Saturday || fechaSeleccionada.DayOfWeek == DayOfWeek.Sunday)
            {
                MessageBox.Show("No se pueden seleccionar turnos los sábados y domingos.", "Día no válido", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                ajusteDateTime = true;
                dateTimePicker1.Value = fechaSeleccionada.AddDays(8 - (int)fechaSeleccionada.DayOfWeek);
                ajusteDateTime = false;
            }
        }

        private int turnoSeleccionadoId;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewRow filaSeleccionada = dataGridView1.Rows[e.RowIndex];
                int idTurno = Convert.ToInt32(filaSeleccionada.Cells["IdColumn"].Value);
                turnoSeleccionadoId = idTurno;

                // Si deseas cargar los datos para edición en los controles correspondientes
                DateTime fecha = Convert.ToDateTime(filaSeleccionada.Cells["FechaColumn"].Value);
                DateTime hora = Convert.ToDateTime(filaSeleccionada.Cells["HoraColumn"].Value);
                string nombrePaciente = Convert.ToString(filaSeleccionada.Cells["NombrePacienteColumn"].Value);
                string apellidoPaciente = Convert.ToString(filaSeleccionada.Cells["ApellidoPacienteColumn"].Value);
                string dniPaciente = Convert.ToString(filaSeleccionada.Cells["DniPacienteColumn"].Value);

                DateTime fechaHora = new DateTime(
                fecha.Year, fecha.Month, fecha.Day,
                hora.Hour, hora.Minute, hora.Second
                );
                // Asigna los valores a los controles del formulario
                dateTimePicker1.Value = fechaHora;
                txtNombre.Text = nombrePaciente;
                txtApellido.Text = apellidoPaciente;
                txtDni.Text = dniPaciente;

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (turnoSeleccionadoId != 0)
            {
                var turno = dbContext.Turnos.Find(turnoSeleccionadoId);
                if (turno != null)
                {
                    turno.Fecha = dateTimePicker1.Value;
                    turno.Paciente.Nombre = txtNombre.Text;
                    turno.Paciente.Apellido = txtApellido.Text;
                    turno.Paciente.Dni = txtDni.Text;
                    dbContext.SaveChanges();
                    ActualizarDataGridView();
                    LimpiarControles();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (turnoSeleccionadoId != -1)
            {
                DialogResult confirmacion = MessageBox.Show("¿Estás seguro de que deseas borrar este turno?", "Confirmación de Borrado", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirmacion == DialogResult.Yes)
                {
                    var turno = dbContext.Turnos.Find(turnoSeleccionadoId);
                    if (turno != null)
                    {
                        dbContext.Turnos.Remove(turno);
                        dbContext.SaveChanges();
                        ActualizarDataGridView();
                    }
                    turnoSeleccionadoId = -1;
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un turno para borrar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBuscarDni_Click(object sender, EventArgs e)
        {
            string dni = txtBuscarDni.Text;
            if (string.IsNullOrEmpty(dni))
            {
                MessageBox.Show("Por favor, ingrese un DNI para buscar.", "Campo Requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Paciente paciente = dbContext.Pacientes.FirstOrDefault(p => p.Dni == dni);
            if (paciente != null)
            {
                txtNombre.Text = paciente.Nombre;
                txtApellido.Text = paciente.Apellido;
                txtDni.Text = paciente.Dni;
            }
            else
            {
                MessageBox.Show("No se encontró ningún paciente con el DNI ingresado.", "Paciente No Encontrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarControles();
            }
        }
    }
}
