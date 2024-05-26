namespace Clinica_SePrice
{
    partial class IngresoPacientes
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
            label1 = new Label();
            txtNombre = new TextBox();
            txtApellido = new TextBox();
            label2 = new Label();
            txtDni = new TextBox();
            labelDni = new Label();
            txtTelefono = new TextBox();
            labelTelefono = new Label();
            txtDireccion = new TextBox();
            labelDireccion = new Label();
            txtEmail = new TextBox();
            label6 = new Label();
            btnGuardar = new Button();
            btnEditar = new Button();
            btnBorrar = new Button();
            fotoPaciente = new PictureBox();
            dataGridView1 = new DataGridView();
            txtBuscar = new TextBox();
            label7 = new Label();
            btnLimpiarFiltro = new Button();
            ((System.ComponentModel.ISupportInitialize)fotoPaciente).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(17, 21);
            label1.Name = "label1";
            label1.Size = new Size(51, 15);
            label1.TabIndex = 0;
            label1.Text = "Nombre";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(72, 18);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(145, 23);
            txtNombre.TabIndex = 1;
            // 
            // txtApellido
            // 
            txtApellido.Location = new Point(331, 18);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(145, 23);
            txtApellido.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(278, 21);
            label2.Name = "label2";
            label2.Size = new Size(51, 15);
            label2.TabIndex = 2;
            label2.Text = "Apellido";
            // 
            // txtDni
            // 
            txtDni.Location = new Point(72, 57);
            txtDni.Name = "txtDni";
            txtDni.Size = new Size(145, 23);
            txtDni.TabIndex = 5;
            // 
            // labelDni
            // 
            labelDni.AutoSize = true;
            labelDni.Location = new Point(28, 60);
            labelDni.Name = "labelDni";
            labelDni.Size = new Size(25, 15);
            labelDni.TabIndex = 4;
            labelDni.Text = "Dni";
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(331, 60);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(145, 23);
            txtTelefono.TabIndex = 7;
            // 
            // labelTelefono
            // 
            labelTelefono.AutoSize = true;
            labelTelefono.Location = new Point(272, 63);
            labelTelefono.Name = "labelTelefono";
            labelTelefono.Size = new Size(52, 15);
            labelTelefono.TabIndex = 6;
            labelTelefono.Text = "Telefono";
            // 
            // txtDireccion
            // 
            txtDireccion.Location = new Point(72, 96);
            txtDireccion.Name = "txtDireccion";
            txtDireccion.Size = new Size(145, 23);
            txtDireccion.TabIndex = 9;
            // 
            // labelDireccion
            // 
            labelDireccion.AutoSize = true;
            labelDireccion.Location = new Point(12, 100);
            labelDireccion.Name = "labelDireccion";
            labelDireccion.Size = new Size(57, 15);
            labelDireccion.TabIndex = 8;
            labelDireccion.Text = "Direccion";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(329, 97);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(145, 23);
            txtEmail.TabIndex = 11;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(287, 102);
            label6.Name = "label6";
            label6.Size = new Size(36, 15);
            label6.TabIndex = 10;
            label6.Text = "Email";
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(703, 30);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(75, 23);
            btnGuardar.TabIndex = 12;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnEditar
            // 
            btnEditar.Location = new Point(703, 59);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(75, 23);
            btnEditar.TabIndex = 12;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = true;
            btnEditar.Click += btnEditar_Click;
            // 
            // btnBorrar
            // 
            btnBorrar.Location = new Point(703, 88);
            btnBorrar.Name = "btnBorrar";
            btnBorrar.Size = new Size(75, 23);
            btnBorrar.TabIndex = 12;
            btnBorrar.Text = "Borrar";
            btnBorrar.UseVisualStyleBackColor = true;
            btnBorrar.Click += btnBorrar_Click;
            // 
            // fotoPaciente
            // 
            fotoPaciente.Location = new Point(508, 12);
            fotoPaciente.Name = "fotoPaciente";
            fotoPaciente.Size = new Size(166, 151);
            fotoPaciente.TabIndex = 13;
            fotoPaciente.TabStop = false;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 228);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.Size = new Size(776, 210);
            dataGridView1.TabIndex = 14;
            dataGridView1.SelectionChanged += dataGridView1_SelectionChanged;
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(215, 199);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(327, 23);
            txtBuscar.TabIndex = 16;
            txtBuscar.TextChanged += txtBuscar_TextChanged;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(16, 202);
            label7.Name = "label7";
            label7.Size = new Size(193, 15);
            label7.TabIndex = 15;
            label7.Text = "Buscar por Nombre, Apellido o DNI";
            // 
            // btnLimpiarFiltro
            // 
            btnLimpiarFiltro.Location = new Point(548, 199);
            btnLimpiarFiltro.Name = "btnLimpiarFiltro";
            btnLimpiarFiltro.Size = new Size(92, 23);
            btnLimpiarFiltro.TabIndex = 12;
            btnLimpiarFiltro.Text = "Limpiar";
            btnLimpiarFiltro.UseVisualStyleBackColor = true;
            btnLimpiarFiltro.Click += btnLimpiarFiltro_Click;
            // 
            // IngresoPacientes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(txtBuscar);
            Controls.Add(label7);
            Controls.Add(dataGridView1);
            Controls.Add(fotoPaciente);
            Controls.Add(btnLimpiarFiltro);
            Controls.Add(btnBorrar);
            Controls.Add(btnEditar);
            Controls.Add(btnGuardar);
            Controls.Add(txtEmail);
            Controls.Add(label6);
            Controls.Add(txtDireccion);
            Controls.Add(labelDireccion);
            Controls.Add(txtTelefono);
            Controls.Add(labelTelefono);
            Controls.Add(txtDni);
            Controls.Add(labelDni);
            Controls.Add(txtApellido);
            Controls.Add(label2);
            Controls.Add(txtNombre);
            Controls.Add(label1);
            Name = "IngresoPacientes";
            Text = "IngresoPacientes";
            ((System.ComponentModel.ISupportInitialize)fotoPaciente).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtNombre;
        private TextBox txtApellido;
        private Label label2;
        private TextBox txtDni;
        private Label labelDni;
        private TextBox txtTelefono;
        private Label labelTelefono;
        private TextBox txtDireccion;
        private Label labelDireccion;
        private TextBox txtEmail;
        private Label label6;
        private Button btnGuardar;
        private Button btnEditar;
        private Button btnBorrar;
        private PictureBox fotoPaciente;
        private DataGridView dataGridView1;
        private TextBox txtBuscar;
        private Label label7;
        private Button btnLimpiarFiltro;
    }
}