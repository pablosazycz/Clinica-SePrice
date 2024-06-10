namespace Clinica_SePrice
{
    partial class FormPago
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            groupBox1 = new GroupBox();
            btnConfirmarPago = new Button();
            groupBox2 = new GroupBox();
            panel1 = new Panel();
            rbTarjeta = new RadioButton();
            rbEfectivo = new RadioButton();
            txtNombreObraSocial = new TextBox();
            label2 = new Label();
            txtNumeroObraSocial = new TextBox();
            label1 = new Label();
            rbObraSocial = new RadioButton();
            label3 = new Label();
            radioButton1 = new RadioButton();
            label4 = new Label();
            label5 = new Label();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnConfirmarPago);
            groupBox1.Controls.Add(groupBox2);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(292, 426);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Metodo de Pago";
            // 
            // btnConfirmarPago
            // 
            btnConfirmarPago.Location = new Point(33, 397);
            btnConfirmarPago.Name = "btnConfirmarPago";
            btnConfirmarPago.Size = new Size(220, 23);
            btnConfirmarPago.TabIndex = 1;
            btnConfirmarPago.Text = "Confirmar Pago";
            btnConfirmarPago.UseVisualStyleBackColor = true;
            btnConfirmarPago.Click += btnConfirmarPago_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(txtNombreObraSocial);
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(txtNumeroObraSocial);
            groupBox2.Controls.Add(label1);
            groupBox2.Controls.Add(rbObraSocial);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(radioButton1);
            groupBox2.Controls.Add(panel1);
            groupBox2.Location = new Point(6, 22);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(269, 358);
            groupBox2.TabIndex = 0;
            groupBox2.TabStop = false;
            // 
            // panel1
            // 
            panel1.Controls.Add(rbTarjeta);
            panel1.Controls.Add(rbEfectivo);
            panel1.Location = new Point(11, 88);
            panel1.Name = "panel1";
            panel1.Size = new Size(127, 53);
            panel1.TabIndex = 10;
            // 
            // rbTarjeta
            // 
            rbTarjeta.AutoSize = true;
            rbTarjeta.Location = new Point(16, 28);
            rbTarjeta.Name = "rbTarjeta";
            rbTarjeta.Size = new Size(59, 19);
            rbTarjeta.TabIndex = 2;
            rbTarjeta.TabStop = true;
            rbTarjeta.Text = "Tarjeta";
            rbTarjeta.UseVisualStyleBackColor = true;
            rbTarjeta.CheckedChanged += rbTarjeta_CheckedChanged;
            // 
            // rbEfectivo
            // 
            rbEfectivo.AutoSize = true;
            rbEfectivo.Location = new Point(16, 3);
            rbEfectivo.Name = "rbEfectivo";
            rbEfectivo.Size = new Size(67, 19);
            rbEfectivo.TabIndex = 1;
            rbEfectivo.TabStop = true;
            rbEfectivo.Text = "Efectivo";
            rbEfectivo.UseVisualStyleBackColor = true;
            // 
            // txtNombreObraSocial
            // 
            txtNombreObraSocial.Location = new Point(27, 249);
            txtNombreObraSocial.Name = "txtNombreObraSocial";
            txtNombreObraSocial.Size = new Size(200, 23);
            txtNombreObraSocial.TabIndex = 9;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(27, 231);
            label2.Name = "label2";
            label2.Size = new Size(113, 15);
            label2.TabIndex = 8;
            label2.Text = "Nombre de Prepaga";
            // 
            // txtNumeroObraSocial
            // 
            txtNumeroObraSocial.Location = new Point(27, 293);
            txtNumeroObraSocial.Name = "txtNumeroObraSocial";
            txtNumeroObraSocial.Size = new Size(200, 23);
            txtNumeroObraSocial.TabIndex = 7;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(27, 275);
            label1.Name = "label1";
            label1.Size = new Size(111, 15);
            label1.TabIndex = 6;
            label1.Text = "Numero de Afiliado";
            // 
            // rbObraSocial
            // 
            rbObraSocial.AutoSize = true;
            rbObraSocial.Location = new Point(6, 195);
            rbObraSocial.Name = "rbObraSocial";
            rbObraSocial.Size = new Size(68, 19);
            rbObraSocial.TabIndex = 5;
            rbObraSocial.TabStop = true;
            rbObraSocial.Text = "Prepaga";
            rbObraSocial.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(27, 150);
            label3.Name = "label3";
            label3.Size = new Size(232, 30);
            label3.TabIndex = 3;
            label3.Text = "Selecciono la opción de tarjeta, \r\npor favor, siga las indicaciones del PostNet";
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Location = new Point(11, 63);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(75, 19);
            radioButton1.TabIndex = 0;
            radioButton1.TabStop = true;
            radioButton1.Text = "Particular";
            radioButton1.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(11, 32);
            label4.Name = "label4";
            label4.Size = new Size(46, 15);
            label4.TabIndex = 11;
            label4.Text = "Precio :";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(80, 32);
            label5.Name = "label5";
            label5.Size = new Size(38, 15);
            label5.TabIndex = 12;
            label5.Text = "label5";
            // 
            // FormPago
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(321, 450);
            Controls.Add(groupBox1);
            Name = "FormPago";
            Text = "FormPago";
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private RadioButton rbTarjeta;
        private RadioButton rbEfectivo;
        private RadioButton radioButton1;
        private Button btnConfirmarPago;
        private Label label3;
        private TextBox txtNombreObraSocial;
        private Label label2;
        private TextBox txtNumeroObraSocial;
        private Label label1;
        private RadioButton rbObraSocial;
        private Panel panel1;
        private Label label5;
        private Label label4;
    }
}