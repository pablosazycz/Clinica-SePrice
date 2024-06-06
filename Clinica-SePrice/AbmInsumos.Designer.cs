namespace Clinica_SePrice
{
    partial class AbmInsumos
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
            btnBuscar = new Button();
            txtBoxIdTurno = new TextBox();
            label1 = new Label();
            groupBox1 = new GroupBox();
            txtNombreMedico = new TextBox();
            txtBoxEspecialidadMedico = new TextBox();
            txtBoxEspecialidadEstudio = new TextBox();
            txtBoxNombreEstudio = new TextBox();
            label6 = new Label();
            label8 = new Label();
            label7 = new Label();
            label4 = new Label();
            txtDni = new TextBox();
            txtNombre = new TextBox();
            label3 = new Label();
            label5 = new Label();
            txtApellido = new TextBox();
            label2 = new Label();
            btnAgregarRenglon = new Button();
            btnGuardar = new Button();
            BtnSalir = new Button();
            dataGridView1 = new DataGridView();
            btnReponerStock = new Button();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(232, 22);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(75, 23);
            btnBuscar.TabIndex = 2;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // txtBoxIdTurno
            // 
            txtBoxIdTurno.Location = new Point(70, 22);
            txtBoxIdTurno.Name = "txtBoxIdTurno";
            txtBoxIdTurno.Size = new Size(138, 23);
            txtBoxIdTurno.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(17, 26);
            label1.Name = "label1";
            label1.Size = new Size(38, 15);
            label1.TabIndex = 3;
            label1.Text = "Turno";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtNombreMedico);
            groupBox1.Controls.Add(txtBoxEspecialidadMedico);
            groupBox1.Controls.Add(txtBoxEspecialidadEstudio);
            groupBox1.Controls.Add(txtBoxNombreEstudio);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(txtBoxIdTurno);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(btnBuscar);
            groupBox1.Controls.Add(txtDni);
            groupBox1.Controls.Add(txtNombre);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(txtApellido);
            groupBox1.Controls.Add(label2);
            groupBox1.Location = new Point(5, 2);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(791, 156);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            groupBox1.Text = "Buscar Turno";
            // 
            // txtNombreMedico
            // 
            txtNombreMedico.Location = new Point(583, 118);
            txtNombreMedico.Name = "txtNombreMedico";
            txtNombreMedico.ReadOnly = true;
            txtNombreMedico.Size = new Size(164, 23);
            txtNombreMedico.TabIndex = 34;
            // 
            // txtBoxEspecialidadMedico
            // 
            txtBoxEspecialidadMedico.Location = new Point(583, 85);
            txtBoxEspecialidadMedico.Name = "txtBoxEspecialidadMedico";
            txtBoxEspecialidadMedico.ReadOnly = true;
            txtBoxEspecialidadMedico.Size = new Size(164, 23);
            txtBoxEspecialidadMedico.TabIndex = 33;
            // 
            // txtBoxEspecialidadEstudio
            // 
            txtBoxEspecialidadEstudio.Location = new Point(297, 115);
            txtBoxEspecialidadEstudio.Name = "txtBoxEspecialidadEstudio";
            txtBoxEspecialidadEstudio.ReadOnly = true;
            txtBoxEspecialidadEstudio.Size = new Size(153, 23);
            txtBoxEspecialidadEstudio.TabIndex = 32;
            // 
            // txtBoxNombreEstudio
            // 
            txtBoxNombreEstudio.Location = new Point(297, 85);
            txtBoxNombreEstudio.Name = "txtBoxNombreEstudio";
            txtBoxNombreEstudio.ReadOnly = true;
            txtBoxNombreEstudio.Size = new Size(153, 23);
            txtBoxNombreEstudio.TabIndex = 31;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(498, 123);
            label6.Name = "label6";
            label6.Size = new Size(43, 15);
            label6.TabIndex = 30;
            label6.Text = "Doctor";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(492, 88);
            label8.Name = "label8";
            label8.Size = new Size(72, 15);
            label8.TabIndex = 29;
            label8.Text = "Especialidad";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(217, 80);
            label7.Name = "label7";
            label7.Size = new Size(47, 30);
            label7.TabIndex = 26;
            label7.Text = "Estudio\r\nMedico";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(204, 121);
            label4.Name = "label4";
            label4.Size = new Size(72, 15);
            label4.TabIndex = 24;
            label4.Text = "Especialidad";
            // 
            // txtDni
            // 
            txtDni.Location = new Point(70, 118);
            txtDni.Name = "txtDni";
            txtDni.ReadOnly = true;
            txtDni.Size = new Size(100, 23);
            txtDni.TabIndex = 23;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(70, 60);
            txtNombre.Name = "txtNombre";
            txtNombre.ReadOnly = true;
            txtNombre.Size = new Size(100, 23);
            txtNombre.TabIndex = 20;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(26, 121);
            label3.Name = "label3";
            label3.Size = new Size(25, 15);
            label3.TabIndex = 21;
            label3.Text = "Dni";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(13, 63);
            label5.Name = "label5";
            label5.Size = new Size(51, 15);
            label5.TabIndex = 18;
            label5.Text = "Nombre";
            // 
            // txtApellido
            // 
            txtApellido.Location = new Point(70, 89);
            txtApellido.Name = "txtApellido";
            txtApellido.ReadOnly = true;
            txtApellido.Size = new Size(100, 23);
            txtApellido.TabIndex = 22;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(13, 93);
            label2.Name = "label2";
            label2.Size = new Size(51, 15);
            label2.TabIndex = 19;
            label2.Text = "Apellido";
            // 
            // btnAgregarRenglon
            // 
            btnAgregarRenglon.Location = new Point(12, 177);
            btnAgregarRenglon.Name = "btnAgregarRenglon";
            btnAgregarRenglon.Size = new Size(88, 24);
            btnAgregarRenglon.TabIndex = 2;
            btnAgregarRenglon.Text = "+";
            btnAgregarRenglon.TextAlign = ContentAlignment.TopCenter;
            btnAgregarRenglon.UseVisualStyleBackColor = true;
            btnAgregarRenglon.Click += btnAgregarRenglon_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(22, 415);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(75, 23);
            btnGuardar.TabIndex = 6;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // BtnSalir
            // 
            BtnSalir.Location = new Point(138, 415);
            BtnSalir.Name = "BtnSalir";
            BtnSalir.Size = new Size(75, 23);
            BtnSalir.TabIndex = 7;
            BtnSalir.Text = "Salir";
            BtnSalir.UseVisualStyleBackColor = true;
            BtnSalir.Click += BtnSalir_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(11, 207);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(785, 202);
            dataGridView1.TabIndex = 8;
            dataGridView1.EditingControlShowing += dataGridView1_EditingControlShowing;
            // 
            // btnReponerStock
            // 
            btnReponerStock.Location = new Point(677, 415);
            btnReponerStock.Name = "btnReponerStock";
            btnReponerStock.Size = new Size(111, 23);
            btnReponerStock.TabIndex = 9;
            btnReponerStock.Text = "Reponer Stock";
            btnReponerStock.UseVisualStyleBackColor = true;
            btnReponerStock.Click += btnReponerStock_Click;
            // 
            // AbmInsumos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnReponerStock);
            Controls.Add(dataGridView1);
            Controls.Add(BtnSalir);
            Controls.Add(btnGuardar);
            Controls.Add(groupBox1);
            Controls.Add(btnAgregarRenglon);
            Name = "AbmInsumos";
            Text = "AbmInsumos";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Button btnBuscar;
        private TextBox txtBoxIdTurno;
        private Label label1;
        private GroupBox groupBox1;
        private Button btnGuardar;
        private Button BtnSalir;
        private Button btnAgregarRenglon;
        private DataGridView dataGridView1;
        private Label label7;
        private Label label4;
        private TextBox txtDni;
        private TextBox txtNombre;
        private Label label3;
        private Label label5;
        private TextBox txtApellido;
        private Label label2;
        private TextBox txtNombreMedico;
        private TextBox txtBoxEspecialidadMedico;
        private TextBox txtBoxEspecialidadEstudio;
        private TextBox txtBoxNombreEstudio;
        private Label label6;
        private Label label8;
        private Button btnReponerStock;
    }
}