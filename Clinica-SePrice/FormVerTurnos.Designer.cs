﻿namespace Clinica_SePrice
{
    partial class FormVerTurnos
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
            dataGridView1 = new DataGridView();
            txtBuscarTurnos = new TextBox();
            DniBuscar = new Label();
            btnSalirTurnos = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 62);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.Size = new Size(859, 364);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellContentClick += dataGridView1_CellClick;
            // 
            // txtBuscarTurnos
            // 
            txtBuscarTurnos.Location = new Point(211, 21);
            txtBuscarTurnos.Name = "txtBuscarTurnos";
            txtBuscarTurnos.Size = new Size(407, 23);
            txtBuscarTurnos.TabIndex = 1;
            txtBuscarTurnos.TextChanged += txtBuscarTurnos_TextChanged;
            // 
            // DniBuscar
            // 
            DniBuscar.AutoSize = true;
            DniBuscar.Location = new Point(12, 24);
            DniBuscar.Name = "DniBuscar";
            DniBuscar.Size = new Size(193, 15);
            DniBuscar.TabIndex = 2;
            DniBuscar.Text = "Buscar por Nombre, Apellido o DNI";
            // 
            // btnSalirTurnos
            // 
            btnSalirTurnos.Location = new Point(796, 452);
            btnSalirTurnos.Name = "btnSalirTurnos";
            btnSalirTurnos.Size = new Size(75, 23);
            btnSalirTurnos.TabIndex = 4;
            btnSalirTurnos.Text = "Salir";
            btnSalirTurnos.UseVisualStyleBackColor = true;
            // 
            // FormVerTurnos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(883, 487);
            Controls.Add(btnSalirTurnos);
            Controls.Add(DniBuscar);
            Controls.Add(txtBuscarTurnos);
            Controls.Add(dataGridView1);
            Name = "FormVerTurnos";
            Text = "FormVerTurnos";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private TextBox txtBuscarTurnos;
        private Label DniBuscar;
        private Button button1;
        private Button btnSalirTurnos;
    }
}