namespace PescaArtesanal_NoSQL_WindowsForms.Formularios
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
            btnGuardaMunicipio = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.BackColor = Color.SteelBlue;
            label1.Dock = DockStyle.Top;
            label1.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.AliceBlue;
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(880, 32);
            label1.TabIndex = 0;
            label1.Text = "Registra Nuevo Municipio";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnCerrarForma
            // 
            btnCerrarForma.FlatStyle = FlatStyle.Flat;
            btnCerrarForma.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnCerrarForma.Location = new Point(850, 3);
            btnCerrarForma.Name = "btnCerrarForma";
            btnCerrarForma.Size = new Size(24, 24);
            btnCerrarForma.TabIndex = 1;
            btnCerrarForma.Text = "X";
            btnCerrarForma.UseVisualStyleBackColor = true;
            btnCerrarForma.Click += btnCerrarForma_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(66, 101);
            label2.Name = "label2";
            label2.Size = new Size(113, 21);
            label2.TabIndex = 2;
            label2.Text = "Departamento:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(480, 101);
            label3.Name = "label3";
            label3.Size = new Size(64, 21);
            label3.TabIndex = 3;
            label3.Text = "Cuenca:";
            // 
            // lbxDepartamentos
            // 
            lbxDepartamentos.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lbxDepartamentos.FormattingEnabled = true;
            lbxDepartamentos.ItemHeight = 21;
            lbxDepartamentos.Location = new Point(195, 101);
            lbxDepartamentos.Margin = new Padding(3, 2, 3, 2);
            lbxDepartamentos.Name = "lbxDepartamentos";
            lbxDepartamentos.Size = new Size(238, 109);
            lbxDepartamentos.TabIndex = 4;
            // 
            // lbxCuencas
            // 
            lbxCuencas.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lbxCuencas.FormattingEnabled = true;
            lbxCuencas.ItemHeight = 21;
            lbxCuencas.Location = new Point(550, 101);
            lbxCuencas.Margin = new Padding(3, 2, 3, 2);
            lbxCuencas.Name = "lbxCuencas";
            lbxCuencas.Size = new Size(242, 109);
            lbxCuencas.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(166, 250);
            label4.Name = "label4";
            label4.Size = new Size(169, 21);
            label4.TabIndex = 6;
            label4.Text = "Nombre del Municipio:";
            // 
            // txtNombreMunicipio
            // 
            txtNombreMunicipio.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtNombreMunicipio.Location = new Point(354, 246);
            txtNombreMunicipio.Margin = new Padding(3, 2, 3, 2);
            txtNombreMunicipio.Name = "txtNombreMunicipio";
            txtNombreMunicipio.Size = new Size(286, 29);
            txtNombreMunicipio.TabIndex = 7;
            // 
            // btnGuardaMunicipio
            // 
            btnGuardaMunicipio.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnGuardaMunicipio.Location = new Point(659, 245);
            btnGuardaMunicipio.Margin = new Padding(3, 2, 3, 2);
            btnGuardaMunicipio.Name = "btnGuardaMunicipio";
            btnGuardaMunicipio.Size = new Size(133, 30);
            btnGuardaMunicipio.TabIndex = 8;
            btnGuardaMunicipio.Text = "Guardar";
            btnGuardaMunicipio.UseVisualStyleBackColor = true;
            btnGuardaMunicipio.Click += btnGuardaMunicipio_Click;
            // 
            // MunicipioNuevo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(880, 463);
            Controls.Add(btnGuardaMunicipio);
            Controls.Add(txtNombreMunicipio);
            Controls.Add(label4);
            Controls.Add(lbxCuencas);
            Controls.Add(lbxDepartamentos);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(btnCerrarForma);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            MaximumSize = new Size(880, 463);
            MinimumSize = new Size(880, 463);
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
        private Button btnGuardaMunicipio;
    }
}