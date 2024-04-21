namespace Clinica_SePrice
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblTitulo = new Label();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Arial", 16F, FontStyle.Bold);
            lblTitulo.Location = new Point(241, 19);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(257, 26);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Agenda de Consultorios";
            // 
            // button1
            // 
            button1.Location = new Point(45, 108);
            button1.Name = "button1";
            button1.Size = new Size(96, 42);
            button1.TabIndex = 1;
            button1.Text = "Turnos Médicos";
            button1.UseVisualStyleBackColor = true;
            button1.Click += Button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(193, 108);
            button2.Name = "button2";
            button2.Size = new Size(88, 42);
            button2.TabIndex = 2;
            button2.Text = "Turnos Estudios";
            button2.UseVisualStyleBackColor = true;
            button2.Click += Button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(344, 111);
            button3.Name = "button3";
            button3.Size = new Size(101, 52);
            button3.TabIndex = 3;
            button3.Text = "Ver Turnos";
            button3.UseVisualStyleBackColor = true;
            button3.Click += Button3_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(lblTitulo);
            Name = "Form1";
            Text = "Agenda de Consultorio Médicos";
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Label lblTitulo;
        private Button button1;
        private Button button2;
        private Button button3;
    }
}
