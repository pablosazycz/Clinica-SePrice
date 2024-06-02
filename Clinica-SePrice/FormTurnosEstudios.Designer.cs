namespace Clinica_SePrice
{
    partial class FormTurnosEstudios
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
            label3 = new Label();
            label4 = new Label();
            cmbEspecialidad = new ComboBox();
            dataGridView1 = new DataGridView();
            label5 = new Label();
            dateTimePicker1 = new DateTimePicker();
            label6 = new Label();
            textBox4 = new TextBox();
            button3 = new Button();
            button2 = new Button();
            button1 = new Button();
            cmbEstudioMedico = new ComboBox();
            label7 = new Label();
            btnBuscarDni = new Button();
            txtBuscarDni = new TextBox();
            label8 = new Label();
            chkSobreturno = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(15, 46);
            label1.Name = "label1";
            label1.Size = new Size(51, 15);
            label1.TabIndex = 0;
            label1.Text = "Nombre";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(72, 43);
            txtNombre.Name = "txtNombre";
            txtNombre.ReadOnly = true;
            txtNombre.Size = new Size(100, 23);
            txtNombre.TabIndex = 3;
            // 
            // txtApellido
            // 
            txtApellido.Location = new Point(72, 72);
            txtApellido.Name = "txtApellido";
            txtApellido.ReadOnly = true;
            txtApellido.Size = new Size(100, 23);
            txtApellido.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(15, 76);
            label2.Name = "label2";
            label2.Size = new Size(51, 15);
            label2.TabIndex = 2;
            label2.Text = "Apellido";
            // 
            // txtDni
            // 
            txtDni.Location = new Point(72, 101);
            txtDni.Name = "txtDni";
            txtDni.ReadOnly = true;
            txtDni.Size = new Size(100, 23);
            txtDni.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(28, 104);
            label3.Name = "label3";
            label3.Size = new Size(25, 15);
            label3.TabIndex = 4;
            label3.Text = "Dni";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(206, 104);
            label4.Name = "label4";
            label4.Size = new Size(72, 15);
            label4.TabIndex = 6;
            label4.Text = "Especialidad";
            // 
            // cmbEspecialidad
            // 
            cmbEspecialidad.FormattingEnabled = true;
            cmbEspecialidad.Location = new Point(284, 101);
            cmbEspecialidad.Name = "cmbEspecialidad";
            cmbEspecialidad.Size = new Size(164, 23);
            cmbEspecialidad.TabIndex = 7;
            cmbEspecialidad.SelectedIndexChanged += cmbEspecialidad_SelectedIndexChanged;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.BorderStyle = BorderStyle.Fixed3D;
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.Raised;
            dataGridView1.Location = new Point(9, 177);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(779, 232);
            dataGridView1.TabIndex = 8;
            dataGridView1.CellDoubleClick += dataGridView1_CellClick;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(15, 153);
            label5.Name = "label5";
            label5.Size = new Size(38, 15);
            label5.TabIndex = 9;
            label5.Text = "Fecha";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.CustomFormat = "dddd dd/MM/yyyy   HH:mm";
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.Location = new Point(72, 147);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(194, 23);
            dateTimePicker1.TabIndex = 10;
            dateTimePicker1.ValueChanged += dateTimePicker1_ValueChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(472, 73);
            label6.Name = "label6";
            label6.Size = new Size(48, 15);
            label6.TabIndex = 11;
            label6.Text = "Detalles";
            // 
            // textBox4
            // 
            textBox4.Location = new Point(536, 65);
            textBox4.Multiline = true;
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(198, 59);
            textBox4.TabIndex = 12;
            // 
            // button3
            // 
            button3.Location = new Point(191, 415);
            button3.Name = "button3";
            button3.Size = new Size(75, 23);
            button3.TabIndex = 15;
            button3.Text = "Borrar";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button2
            // 
            button2.Location = new Point(97, 415);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 14;
            button2.Text = "Editar";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.Location = new Point(12, 415);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 13;
            button1.Text = "Agendar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // cmbEstudioMedico
            // 
            cmbEstudioMedico.FormattingEnabled = true;
            cmbEstudioMedico.Location = new Point(284, 68);
            cmbEstudioMedico.Name = "cmbEstudioMedico";
            cmbEstudioMedico.Size = new Size(164, 23);
            cmbEstudioMedico.TabIndex = 17;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(219, 63);
            label7.Name = "label7";
            label7.Size = new Size(47, 30);
            label7.TabIndex = 16;
            label7.Text = "Estudio\r\nMedico";
            // 
            // btnBuscarDni
            // 
            btnBuscarDni.Location = new Point(354, 5);
            btnBuscarDni.Name = "btnBuscarDni";
            btnBuscarDni.Size = new Size(75, 23);
            btnBuscarDni.TabIndex = 2;
            btnBuscarDni.Text = "Buscar";
            btnBuscarDni.UseVisualStyleBackColor = true;
            btnBuscarDni.Click += btnBuscarDni_Click;
            // 
            // txtBuscarDni
            // 
            txtBuscarDni.Location = new Point(155, 6);
            txtBuscarDni.Name = "txtBuscarDni";
            txtBuscarDni.Size = new Size(182, 23);
            txtBuscarDni.TabIndex = 1;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(15, 9);
            label8.Name = "label8";
            label8.Size = new Size(134, 15);
            label8.TabIndex = 24;
            label8.Text = "Buscar Paciente por DNI";
            // 
            // chkSobreturno
            // 
            chkSobreturno.AutoSize = true;
            chkSobreturno.Location = new Point(302, 149);
            chkSobreturno.Name = "chkSobreturno";
            chkSobreturno.Size = new Size(327, 19);
            chkSobreturno.TabIndex = 27;
            chkSobreturno.Text = " Marcar si el estudio proviene de la guardia o internación.";
            chkSobreturno.UseVisualStyleBackColor = true;
            // 
            // FormTurnosEstudios
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(chkSobreturno);
            Controls.Add(btnBuscarDni);
            Controls.Add(txtBuscarDni);
            Controls.Add(label8);
            Controls.Add(cmbEstudioMedico);
            Controls.Add(label7);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(textBox4);
            Controls.Add(label6);
            Controls.Add(dateTimePicker1);
            Controls.Add(label5);
            Controls.Add(dataGridView1);
            Controls.Add(cmbEspecialidad);
            Controls.Add(label4);
            Controls.Add(txtDni);
            Controls.Add(label3);
            Controls.Add(txtApellido);
            Controls.Add(label2);
            Controls.Add(txtNombre);
            Controls.Add(label1);
            Name = "FormTurnosEstudios";
            Text = "FormTurnosEstudios";
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
        private Label label3;
        private Label label4;
        private ComboBox cmbEspecialidad;
        private DataGridView dataGridView1;
        private Label label5;
        private DateTimePicker dateTimePicker1;
        private Label label6;
        private TextBox textBox4;
        private Button button3;
        private Button button2;
        private Button button1;
        private ComboBox cmbEstudioMedico;
        private Label label7;
        private Button btnBuscarDni;
        private TextBox txtBuscarDni;
        private Label label8;
        private CheckBox chkSobreturno;
    }
}