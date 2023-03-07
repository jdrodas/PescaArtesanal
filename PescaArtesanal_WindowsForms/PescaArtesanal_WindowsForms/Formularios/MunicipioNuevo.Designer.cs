namespace PescaArtesanal_WindowsForms.Formularios
{
    partial class MunicipioNuevo
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
            btnCerrarForma = new Button();
            label2 = new Label();
            label3 = new Label();
            lbxDepartamentos = new ListBox();
            lbxCuencas = new ListBox();
            label4 = new Label();
            txtNombreMunicipio = new TextBox();
            btnGuardarMunicipio = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.BackColor = Color.SteelBlue;
            label1.Dock = DockStyle.Top;
            label1.Font = new Font("Comic Sans MS", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.AliceBlue;
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(1125, 41);
            label1.TabIndex = 0;
            label1.Text = "Registra Nuevo Municipio";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnCerrarForma
            // 
            btnCerrarForma.FlatStyle = FlatStyle.Flat;
            btnCerrarForma.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnCerrarForma.Location = new Point(1091, 4);
            btnCerrarForma.Margin = new Padding(3, 4, 3, 4);
            btnCerrarForma.Name = "btnCerrarForma";
            btnCerrarForma.Size = new Size(27, 32);
            btnCerrarForma.TabIndex = 1;
            btnCerrarForma.Text = "X";
            btnCerrarForma.UseVisualStyleBackColor = true;
            btnCerrarForma.Click += btnCerrarForma_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(142, 132);
            label2.Name = "label2";
            label2.Size = new Size(109, 20);
            label2.TabIndex = 2;
            label2.Text = "Departamento:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(503, 132);
            label3.Name = "label3";
            label3.Size = new Size(60, 20);
            label3.TabIndex = 3;
            label3.Text = "Cuenca:";
            // 
            // lbxDepartamentos
            // 
            lbxDepartamentos.FormattingEnabled = true;
            lbxDepartamentos.ItemHeight = 20;
            lbxDepartamentos.Location = new Point(257, 132);
            lbxDepartamentos.Name = "lbxDepartamentos";
            lbxDepartamentos.Size = new Size(207, 104);
            lbxDepartamentos.TabIndex = 4;
            // 
            // lbxCuencas
            // 
            lbxCuencas.FormattingEnabled = true;
            lbxCuencas.ItemHeight = 20;
            lbxCuencas.Location = new Point(569, 132);
            lbxCuencas.Name = "lbxCuencas";
            lbxCuencas.Size = new Size(196, 104);
            lbxCuencas.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(203, 347);
            label4.Name = "label4";
            label4.Size = new Size(162, 20);
            label4.TabIndex = 6;
            label4.Text = "Nombre del Municipio:";
            // 
            // txtNombreMunicipio
            // 
            txtNombreMunicipio.Location = new Point(371, 343);
            txtNombreMunicipio.Name = "txtNombreMunicipio";
            txtNombreMunicipio.Size = new Size(125, 27);
            txtNombreMunicipio.TabIndex = 7;
            // 
            // btnGuardarMunicipio
            // 
            btnGuardarMunicipio.Location = new Point(604, 343);
            btnGuardarMunicipio.Name = "btnGuardarMunicipio";
            btnGuardarMunicipio.Size = new Size(94, 29);
            btnGuardarMunicipio.TabIndex = 8;
            btnGuardarMunicipio.Text = "Guardar";
            btnGuardarMunicipio.UseVisualStyleBackColor = true;
            btnGuardarMunicipio.Click += btnGuardarMunicipio_Click;
            // 
            // MunicipioNuevo
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1125, 747);
            Controls.Add(btnGuardarMunicipio);
            Controls.Add(txtNombreMunicipio);
            Controls.Add(label4);
            Controls.Add(lbxCuencas);
            Controls.Add(lbxDepartamentos);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(btnCerrarForma);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            Name = "MunicipioNuevo";
            Text = "Nuevo Municipio";
            Load += MunicipioNuevo_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button btnCerrarForma;
        private Label label2;
        private Label label3;
        private ListBox lbxDepartamentos;
        private ListBox lbxCuencas;
        private Label label4;
        private TextBox txtNombreMunicipio;
        private Button btnGuardarMunicipio;
    }
}