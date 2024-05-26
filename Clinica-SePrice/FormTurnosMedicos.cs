using Clinica_SePrice.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Clinica_SePrice
{
    public partial class FormTurnosMedicos : Form
    {
        private ClinicaContext dbContext;

        public FormTurnosMedicos(ClinicaContext dbContext)
        {
            this.dbContext = dbContext;
            InitializeComponent();
            CargarEspecialidades();
            ActualizarDataGridView();
        }
        private void CargarEspecialidades()
        {
            var especialidades = dbContext.Medicos.Select(m => m.Especialidad).Distinct().ToList();
            comboBox1.DataSource = especialidades;
        }
        private void CargarMedicosPorEspecialidad(string especialidad)
        {
            var medicos = dbContext.Medicos.Where(m => m.Especialidad == especialidad).ToList();
            comboBox2.DataSource = medicos;
            comboBox2.DisplayMember = "NombreCompleto";
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                string especialidadSeleccionada = comboBox1.SelectedItem.ToString();
                CargarMedicosPorEspecialidad(especialidadSeleccionada);
                if (comboBox2.SelectedItem != null)
                {
                    Medico medicoSeleccionado = (Medico)comboBox2.SelectedItem;
                    DateTime proximaFechaHoraDisponible = CalcularProximoTurnoDisponible(medicoSeleccionado);
                    dateTimePicker1.Value = proximaFechaHoraDisponible;
                }
            }
        }


        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DateTime fechaSeleccionada = dateTimePicker1.Value;

            if (fechaSeleccionada.DayOfWeek == DayOfWeek.Saturday || fechaSeleccionada.DayOfWeek == DayOfWeek.Sunday)
            {
                MessageBox.Show("No se pueden seleccionar turnos los sábados y domingos.", "Día no válido", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                // Ajusta la fecha al próximo lunes
                while (fechaSeleccionada.DayOfWeek == DayOfWeek.Saturday || fechaSeleccionada.DayOfWeek == DayOfWeek.Sunday)
                {
                    fechaSeleccionada = fechaSeleccionada.AddDays(1);
                }

                dateTimePicker1.Value = fechaSeleccionada;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox2.SelectedItem == null || string.IsNullOrEmpty(txtNombre.Text) || string.IsNullOrEmpty(txtApellido.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos para agendar la cita.", "Campos Incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string nombrePaciente = txtNombre.Text;
            string apellidoPaciente = txtApellido.Text;
            string dniPaciente = txtDni.Text;
            string consultorio = textBox4.Text;
            string especialidadSeleccionada = comboBox1.SelectedItem.ToString();
            Medico medicoSeleccionado = (Medico)comboBox2.SelectedItem;

            DateTime fechaHoraInicio = dateTimePicker1.Value;
            DateTime fechaHoraFin = fechaHoraInicio.AddMinutes(ObtenerDuracionMinimaTurno(medicoSeleccionado.Especialidad));

            bool turnoProgramado = VerificarTurnoProgramado(medicoSeleccionado, fechaHoraInicio, fechaHoraFin);
            if (turnoProgramado)
            {
                MessageBox.Show("Ya hay un turno programado para el médico en la fecha y hora seleccionadas.", "Turno Programado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (fechaHoraInicio.DayOfWeek >= DayOfWeek.Monday && fechaHoraInicio.DayOfWeek <= DayOfWeek.Friday && fechaHoraInicio.Hour >= 8 && fechaHoraInicio.Hour < 18)
            {

                fechaHoraInicio = fechaHoraInicio.AddTicks(-(fechaHoraInicio.Ticks % TimeSpan.TicksPerMinute));
                fechaHoraFin = fechaHoraFin.AddTicks(-(fechaHoraFin.Ticks % TimeSpan.TicksPerMinute));

                Turno nuevoTurno = new Turno
                {
                    Fecha = fechaHoraInicio,
                    Lugar = consultorio,
                    Medico = medicoSeleccionado,
                    Duracion = ObtenerDuracionMinimaTurno(medicoSeleccionado.Especialidad),
                    EstudioMedicoId = null,
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
            }
            else
            {
                MessageBox.Show("El horario seleccionado no es válido. Por favor, seleccione un horario entre las 8:00 y las 18:00 de lunes a viernes.", "Horario Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }


        private int ObtenerDuracionMinimaTurno(string especialidad)
        {
            switch (especialidad)
            {
                case "Salud Mental":
                    return 30;
                case "Fisio-Kinesiologia":
                    return 25;
                default:
                    return 15;
            }
        }

        private bool VerificarTurnoProgramado(Medico medicoSeleccionado, DateTime fechaHoraInicio, DateTime fechaHoraFin)
        {
            var turnos = dbContext.Turnos.Where(t => t.Medico.Id == medicoSeleccionado.Id).ToList();

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
        private DateTime CalcularProximoTurnoDisponible(Medico medicoSeleccionado)
        {
            if (medicoSeleccionado == null)
            {
                throw new ArgumentNullException(nameof(medicoSeleccionado), "El médico seleccionado es nulo.");
            }

            var ultimoTurno = dbContext.Turnos
                .Where(t => t.Medico.Id == medicoSeleccionado.Id)
                .OrderByDescending(t => t.Fecha)
                .FirstOrDefault();

            DateTime proximaHoraDisponible;

            if (ultimoTurno != null)
            {
                proximaHoraDisponible = ultimoTurno.Fecha.AddMinutes(ultimoTurno.Duracion);
            }
            else
            {
                proximaHoraDisponible = DateTime.Now;
            }

            // Ajustar la fecha si cae en fin de semana
            if (proximaHoraDisponible.DayOfWeek == DayOfWeek.Saturday)
            {
                proximaHoraDisponible = proximaHoraDisponible.AddDays(2); // Pasar al lunes
                proximaHoraDisponible = proximaHoraDisponible.Date.AddHours(8);
            }
            else if (proximaHoraDisponible.DayOfWeek == DayOfWeek.Sunday)
            {
                proximaHoraDisponible = proximaHoraDisponible.AddDays(1); // Pasar al lunes
                proximaHoraDisponible = proximaHoraDisponible.Date.AddHours(8);
            }
            else if (proximaHoraDisponible.Hour >= 18)
            {
                proximaHoraDisponible = proximaHoraDisponible.Date.AddDays(1).AddHours(8);
            }
            else if (proximaHoraDisponible.Hour < 8)
            {
                proximaHoraDisponible = proximaHoraDisponible.Date.AddHours(8);
            }

            // Verificar que la fecha ajustada no caiga en fin de semana después de ajustar la hora
            if (proximaHoraDisponible.DayOfWeek == DayOfWeek.Saturday)
            {
                proximaHoraDisponible = proximaHoraDisponible.AddDays(2); // Pasar al lunes
            }
            else if (proximaHoraDisponible.DayOfWeek == DayOfWeek.Sunday)
            {
                proximaHoraDisponible = proximaHoraDisponible.AddDays(1); // Pasar al lunes
            }

            return proximaHoraDisponible;
        }

        private void ActualizarDataGridView()
        {
            var turnos = dbContext.Turnos
        .Where(t => t.MedicoId != null && !t.Validado)
        .Include(t => t.Medico)
        .Include(t => t.Paciente)
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
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dataGridView1.Rows.Clear();

            foreach (var turno in turnos)
            {
                dataGridView1.Rows.Add(
                    turno.Id,
                    turno.Fecha.ToShortDateString(),
                    turno.Fecha.ToShortTimeString(),
                    turno.Lugar ?? "N/A",
                    turno.Medico?.NombreCompleto ?? "N/A",
                    turno.Paciente.Nombre,
                    turno.Paciente.Apellido,
                    turno.Paciente.Dni
                );
            }


            if (dataGridView1.Rows.Count == 0)
            {
                dataGridView1.Rows.Add("No hay turnos", "", "", "", "", "", "", "");
                dataGridView1.Rows[0].DefaultCellStyle.Font = new Font(dataGridView1.Font, FontStyle.Italic);
                dataGridView1.Rows[0].DefaultCellStyle.ForeColor = Color.Gray;
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
                string lugar = Convert.ToString(filaSeleccionada.Cells["LugarColumn"].Value);
                string nombreMedico = Convert.ToString(filaSeleccionada.Cells["MedicoColumn"].Value);
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
                textBox4.Text = lugar;

            }
        }

        private void buttonEditar_Click(object sender, EventArgs e)
        {
            if (turnoSeleccionadoId != 0)
            {
                var turno = dbContext.Turnos.Find(turnoSeleccionadoId);
                if (turno != null)
                {
                    turno.Fecha = dateTimePicker1.Value;
                    turno.Lugar = textBox4.Text;
                    turno.Paciente.Nombre = txtNombre.Text;
                    turno.Paciente.Apellido = txtApellido.Text;
                    turno.Paciente.Dni = txtDni.Text;
                    dbContext.SaveChanges();
                    ActualizarDataGridView();
                    LimpiarControles();
                }
            }
        }

        private void buttonBorrar_Click(object sender, EventArgs e)
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

        private void LimpiarControles()
        {
            txtNombre.Clear();
            txtApellido.Clear();
            txtDni.Clear();
            textBox4.Clear();
            comboBox2.SelectedIndex = -1;

            // Establecer la fecha del dateTimePicker al próximo día hábil si es fin de semana
            DateTime fecha = DateTime.Today;
            if (fecha.DayOfWeek == DayOfWeek.Saturday)
            {
                fecha = fecha.AddDays(2); // Mueve al próximo lunes
            }
            else if (fecha.DayOfWeek == DayOfWeek.Sunday)
            {
                fecha = fecha.AddDays(1); // Mueve al próximo lunes
            }

            dateTimePicker1.Value = fecha;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedItem != null)
            {
                var medicoSeleccionado = (Medico)comboBox2.SelectedItem;
                dateTimePicker1.Value = CalcularProximoTurnoDisponible(medicoSeleccionado);
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
