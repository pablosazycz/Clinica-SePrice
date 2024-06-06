using Clinica_SePrice.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Windows.Forms;

namespace Clinica_SePrice
{
    public partial class Form1 : Form
    {
        private ClinicaContext dbContext;

        public Form1(ClinicaContext dbContext)
        {
            this.dbContext = dbContext;
            InitializeComponent();
            ConectarBaseDatos();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            // Abre el formulario de Turnos Médicos usando el contexto existente
            if (dbContext != null)
            {
                FormTurnosMedicos formTurnosMedicos = new FormTurnosMedicos(dbContext);
                formTurnosMedicos.Show();
            }
            else
            {
                MessageBox.Show("No se ha podido establecer conexión con la base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            // Abre el formulario de Turnos de Estudios
            FormTurnosEstudios formTurnosEstudios = new FormTurnosEstudios(dbContext);
            formTurnosEstudios.Show();
        }

        private void Button3_Click(object sender, EventArgs e)
        {

            FormVerTurnos formVerTurnos = new FormVerTurnos(dbContext);
            formVerTurnos.Show();
        }

        private void btnVerSalaEspera_Click(object sender, EventArgs e)
        {
            // Abre el formulario de Sala de Espera
            FormSalaEspera formSalaEspera = new FormSalaEspera(dbContext);
            formSalaEspera.Show();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            IngresoPacientes formPaciente = new IngresoPacientes(dbContext);
            formPaciente.Show();

        }

        private void ConectarBaseDatos()
        {
            try
            {
                string connectionString = "Server=127.0.0.1;Port=3306;Database=clinicaseprice;Uid=root;Pwd=Belgrano1132;";
                var optionsBuilder = new DbContextOptionsBuilder<ClinicaContext>();
                // Especificar la versión del servidor MySQL
                var serverVersion = new MySqlServerVersion(new Version(8, 0, 26));

                // Usar la cadena de conexión y la versión del servidor MySQL
                optionsBuilder.UseMySql(connectionString, serverVersion);

                dbContext = new ClinicaContext(optionsBuilder.Options);

                // Intentar abrir la conexión
                dbContext.Database.OpenConnection();

                MessageBox.Show("Conexión exitosa a la base de datos.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al conectar a la base de datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            AbmInsumos formInsumos = new AbmInsumos(dbContext);
            formInsumos.Show();
        }
    }
}
