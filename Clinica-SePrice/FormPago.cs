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
        }

        private void btnConfirmarPago_Click(object sender, EventArgs e)
        {
            // Lógica para verificar el pago y registrar el pago
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

            RegistrarPago(metodoPago);
            formVerTurnos.MarcarLlegada(turnoId);
            this.Close();
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
