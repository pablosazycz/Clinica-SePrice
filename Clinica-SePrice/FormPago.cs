using Clinica_SePrice.Entidades;
using Clinica_SePrice.Migrations;
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
    public partial class FormPago : Form
    {
        private FormVerTurnos formVerTurnos;
        private int turnoId;
        private ClinicaContext dbContext;

        public FormPago(FormVerTurnos formVerTurnos, int turnoId, ClinicaContext dbContext)
        {
            this.formVerTurnos = formVerTurnos;
            this.turnoId = turnoId;
            this.dbContext = dbContext;
            InitializeComponent();
            label3.Visible = false;
            EstudioMedico estudio = dbContext.Turnos.Include(t => t.Estudio).FirstOrDefault(t => t.Id == turnoId).Estudio;
            if (estudio != null && estudio.Precio != null)
            {
                label5.Text = '$' + estudio.Precio.Value.ToString("F2");
            }
            else
            {
                label5.Text = "Precio no disponible";
            }
        }

        private void btnConfirmarPago_Click(object sender, EventArgs e)
        {
            string metodoPago = ObtenerMetodoPago();

            if (string.IsNullOrEmpty(metodoPago))
            {
                MessageBox.Show("Por favor seleccione un método de pago.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (metodoPago == "Obra Social" && !ValidarDatosObraSocial())
            {
                MessageBox.Show("Por favor ingrese los datos de la obra social.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                RegistrarPago(metodoPago);

                var turno = dbContext.Turnos.Include(t => t.Paciente).Include(t => t.Estudio).FirstOrDefault(t => t.Id == turnoId);
                if (turno != null && turno.Estudio != null)
                {
                    Recibo reciboForm = new Recibo(turno);
                    reciboForm.ShowDialog();
                    MessageBox.Show("Recibo generado exitosamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                formVerTurnos.MarcarLlegada(turnoId);
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al registrar el pago: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.Cancel;
            }
            finally
            {
                this.Close();
            }
        }


        private string ObtenerMetodoPago()
        {
            if (rbEfectivo.Checked)
            {
                return "Efectivo";
            }
            if (rbTarjeta.Checked)
            {
                return "Tarjeta";
            }
            if (rbObraSocial.Checked)
            {
                return "Obra Social";
            }
            return null;
        }

        private bool ValidarDatosObraSocial()
        {
            return !string.IsNullOrEmpty(txtNumeroObraSocial.Text) && !string.IsNullOrEmpty(txtNombreObraSocial.Text);
        }

        private void RegistrarPago(string metodoPago)
        {
            Pago pago = new Pago
            {
                TurnoId = turnoId,
                MetodoPago = metodoPago,
                NombreObraSocial = metodoPago == "Obra Social" ? txtNombreObraSocial.Text : null,
                NumeroObraSocial = metodoPago == "Obra Social" ? txtNumeroObraSocial.Text : null,
                FechaPago = DateTime.Now
            };

            dbContext.Pagos.Add(pago);
            dbContext.SaveChanges();
        }

        private void rbTarjeta_CheckedChanged(object sender, EventArgs e)
        {
            if (rbTarjeta.Checked)
            {
                label3.Visible = true;
            }
            else
            {
                label3.Visible = false;
            }
        }
    }
}
