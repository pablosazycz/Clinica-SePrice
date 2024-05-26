namespace Clinica_SePrice
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
            dataGridView2 = new DataGridView();
            label1 = new Label();
            btnBorrar = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
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
            dataGridView1.Size = new Size(859, 197);
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
            // dataGridView2
            // 
            dataGridView2.AllowUserToAddRows = false;
            dataGridView2.AllowUserToDeleteRows = false;
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Location = new Point(12, 293);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.Size = new Size(859, 182);
            dataGridView2.TabIndex = 3;
            dataGridView2.CellContentClick += dataGridView2_CellClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(15, 269);
            label1.Name = "label1";
            label1.Size = new Size(154, 15);
            label1.TabIndex = 4;
            label1.Text = "Turnos de estudios medicos";
            // 
            // btnBorrar
            // 
            btnBorrar.Location = new Point(633, 21);
            btnBorrar.Name = "btnBorrar";
            btnBorrar.Size = new Size(75, 23);
            btnBorrar.TabIndex = 5;
            btnBorrar.Text = "Borrar";
            btnBorrar.UseVisualStyleBackColor = true;
            btnBorrar.Click += btnBorrar_Click;
            // 
            // FormVerTurnos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(883, 487);
            Controls.Add(btnBorrar);
            Controls.Add(label1);
            Controls.Add(dataGridView2);
            Controls.Add(DniBuscar);
            Controls.Add(txtBuscarTurnos);
            Controls.Add(dataGridView1);
            Name = "FormVerTurnos";
            Text = "FormVerTurnos";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private TextBox txtBuscarTurnos;
        private Label DniBuscar;
        private Button button1;
        private DataGridView dataGridView2;
        private Label label1;
        private Button btnBorrar;
    }
}