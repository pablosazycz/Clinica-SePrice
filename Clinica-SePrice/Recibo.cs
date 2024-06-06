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
    public partial class Recibo : Form
    {
        private Turno turno;

        public Recibo(Turno turno)
        {
            InitializeComponent();
            this.turno = turno;
            GenerarRecibo(turno);
        }

        public void GenerarRecibo(Turno turno)
        {
            if (turno.Estudio == null)
            {
                throw new InvalidOperationException("El recibo solo puede generarse para turnos de estudios médicos.");
            }

            StringBuilder contenidoRecibo = new StringBuilder();

            contenidoRecibo.AppendLine("Recibo de Retiro del Estudio Médico");
            contenidoRecibo.AppendLine($"Fecha: {DateTime.Now.AddDays(7).ToShortDateString()}");
            contenidoRecibo.AppendLine($"Paciente: {turno.Paciente.Nombre} {turno.Paciente.Apellido}");
            contenidoRecibo.AppendLine($"DNI: {turno.Paciente.Dni}");
            contenidoRecibo.AppendLine($"Estudio médico: {turno.Estudio.Nombre}");
            contenidoRecibo.AppendLine($"Fecha del turno: {turno.Fecha.ToShortDateString()}");
            contenidoRecibo.AppendLine($"Hora del turno: {turno.Fecha.ToShortTimeString()}");
            contenidoRecibo.AppendLine("________________________________________");
            contenidoRecibo.AppendLine("Firma del Responsable");

            GuardarRecibo(contenidoRecibo.ToString(), turno.Id);
            MostrarRecibo(contenidoRecibo.ToString());
        }

        private void GuardarRecibo(string contenido, int turnoId)
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string folderPath = Path.Combine(desktopPath, "RecibosClinica");

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            string rutaRecibo = Path.Combine(folderPath, $"Recibo_{turnoId}.txt");
            File.WriteAllText(rutaRecibo, contenido);
        }


        private void MostrarRecibo(string contenido)
        {
            richTextBox1.Text = contenido;
           
        }
    }
}
