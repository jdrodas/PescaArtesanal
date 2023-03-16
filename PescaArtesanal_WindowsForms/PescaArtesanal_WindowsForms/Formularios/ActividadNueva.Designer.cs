namespace PescaArtesanal_WindowsForms.Formularios
{
    partial class ActividadNueva
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
            label1.Size = new Size(1125, 42);
            label1.TabIndex = 0;
            label1.Text = "Registra Nueva Actividad de Pesca";
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
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(135, 132);
            label2.Name = "label2";
            label2.Size = new Size(143, 28);
            label2.TabIndex = 2;
            label2.Text = "Departamento:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(608, 132);
            label3.Name = "label3";
            label3.Size = new Size(79, 28);
            label3.TabIndex = 3;
            label3.Text = "Cuenca:";
            // 
            // lbxDepartamentos
            // 
            lbxDepartamentos.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lbxDepartamentos.FormattingEnabled = true;
            lbxDepartamentos.ItemHeight = 28;
            lbxDepartamentos.Location = new Point(282, 132);
            lbxDepartamentos.Margin = new Padding(3, 2, 3, 2);
            lbxDepartamentos.Name = "lbxDepartamentos";
            lbxDepartamentos.Size = new Size(271, 144);
            lbxDepartamentos.TabIndex = 4;
            // 
            // lbxCuencas
            // 
            lbxCuencas.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lbxCuencas.FormattingEnabled = true;
            lbxCuencas.ItemHeight = 28;
            lbxCuencas.Location = new Point(688, 132);
            lbxCuencas.Margin = new Padding(3, 2, 3, 2);
            lbxCuencas.Name = "lbxCuencas";
            lbxCuencas.Size = new Size(276, 144);
            lbxCuencas.TabIndex = 5;
            // 
            // btnGuardaMunicipio
            // 
            btnGuardaMunicipio.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnGuardaMunicipio.Location = new Point(813, 324);
            btnGuardaMunicipio.Margin = new Padding(3, 2, 3, 2);
            btnGuardaMunicipio.Name = "btnGuardaMunicipio";
            btnGuardaMunicipio.Size = new Size(152, 40);
            btnGuardaMunicipio.TabIndex = 8;
            btnGuardaMunicipio.Text = "Guardar";
            btnGuardaMunicipio.UseVisualStyleBackColor = true;
            btnGuardaMunicipio.Click += btnGuardaMunicipio_Click;
            // 
            // ActividadNueva
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1125, 746);
            Controls.Add(btnGuardaMunicipio);
            Controls.Add(lbxCuencas);
            Controls.Add(lbxDepartamentos);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(btnCerrarForma);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            Name = "ActividadNueva";
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
        private Button btnGuardaMunicipio;
    }
}