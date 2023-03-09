namespace PescaArtesanal_WindowsForms.Formularios
{
    partial class MunicipioActualizado
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
            lbxInfoMunicipios = new ListBox();
            label3 = new Label();
            txtCodigoMunicipio = new TextBox();
            lbxDepartamentos = new ListBox();
            label4 = new Label();
            lbxCuencas = new ListBox();
            label5 = new Label();
            txtNombreMunicipio = new TextBox();
            label6 = new Label();
            btnActualizaMunicipio = new Button();
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
            label1.Text = "Actualiza Municipio existente";
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
            label2.Location = new Point(102, 112);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(215, 28);
            label2.TabIndex = 2;
            label2.Text = "Municipios registrados:";
            // 
            // lbxInfoMunicipios
            // 
            lbxInfoMunicipios.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lbxInfoMunicipios.FormattingEnabled = true;
            lbxInfoMunicipios.ItemHeight = 28;
            lbxInfoMunicipios.Location = new Point(328, 112);
            lbxInfoMunicipios.Margin = new Padding(2);
            lbxInfoMunicipios.Name = "lbxInfoMunicipios";
            lbxInfoMunicipios.Size = new Size(594, 88);
            lbxInfoMunicipios.TabIndex = 3;
            lbxInfoMunicipios.SelectedIndexChanged += lbxInfoMunicipios_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(117, 250);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(199, 28);
            label3.TabIndex = 4;
            label3.Text = "Código seleccionado:";
            label3.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtCodigoMunicipio
            // 
            txtCodigoMunicipio.BackColor = Color.White;
            txtCodigoMunicipio.Enabled = false;
            txtCodigoMunicipio.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtCodigoMunicipio.Location = new Point(328, 245);
            txtCodigoMunicipio.Margin = new Padding(2);
            txtCodigoMunicipio.Name = "txtCodigoMunicipio";
            txtCodigoMunicipio.Size = new Size(121, 34);
            txtCodigoMunicipio.TabIndex = 5;
            // 
            // lbxDepartamentos
            // 
            lbxDepartamentos.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lbxDepartamentos.FormattingEnabled = true;
            lbxDepartamentos.ItemHeight = 28;
            lbxDepartamentos.Location = new Point(264, 325);
            lbxDepartamentos.Margin = new Padding(3, 2, 3, 2);
            lbxDepartamentos.Name = "lbxDepartamentos";
            lbxDepartamentos.Size = new Size(271, 116);
            lbxDepartamentos.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(117, 325);
            label4.Name = "label4";
            label4.Size = new Size(143, 28);
            label4.TabIndex = 6;
            label4.Text = "Departamento:";
            // 
            // lbxCuencas
            // 
            lbxCuencas.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lbxCuencas.FormattingEnabled = true;
            lbxCuencas.ItemHeight = 28;
            lbxCuencas.Location = new Point(642, 325);
            lbxCuencas.Margin = new Padding(3, 2, 3, 2);
            lbxCuencas.Name = "lbxCuencas";
            lbxCuencas.Size = new Size(276, 116);
            lbxCuencas.TabIndex = 9;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(562, 325);
            label5.Name = "label5";
            label5.Size = new Size(79, 28);
            label5.TabIndex = 8;
            label5.Text = "Cuenca:";
            // 
            // txtNombreMunicipio
            // 
            txtNombreMunicipio.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtNombreMunicipio.Location = new Point(334, 487);
            txtNombreMunicipio.Margin = new Padding(3, 2, 3, 2);
            txtNombreMunicipio.Name = "txtNombreMunicipio";
            txtNombreMunicipio.Size = new Size(326, 34);
            txtNombreMunicipio.TabIndex = 11;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(119, 492);
            label6.Name = "label6";
            label6.Size = new Size(214, 28);
            label6.TabIndex = 10;
            label6.Text = "Nombre del Municipio:";
            // 
            // btnActualizaMunicipio
            // 
            btnActualizaMunicipio.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnActualizaMunicipio.Location = new Point(689, 482);
            btnActualizaMunicipio.Margin = new Padding(3, 2, 3, 2);
            btnActualizaMunicipio.Name = "btnActualizaMunicipio";
            btnActualizaMunicipio.Size = new Size(152, 40);
            btnActualizaMunicipio.TabIndex = 12;
            btnActualizaMunicipio.Text = "Actualizar";
            btnActualizaMunicipio.UseVisualStyleBackColor = true;
            btnActualizaMunicipio.Click += btnActualizaMunicipio_Click;
            // 
            // MunicipioActualizado
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1125, 746);
            Controls.Add(btnActualizaMunicipio);
            Controls.Add(txtNombreMunicipio);
            Controls.Add(label6);
            Controls.Add(lbxCuencas);
            Controls.Add(label5);
            Controls.Add(lbxDepartamentos);
            Controls.Add(label4);
            Controls.Add(txtCodigoMunicipio);
            Controls.Add(label3);
            Controls.Add(lbxInfoMunicipios);
            Controls.Add(label2);
            Controls.Add(btnCerrarForma);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(5, 6, 5, 6);
            Name = "MunicipioActualizado";
            Text = "Actualiza Municipio";
            Load += MunicipioActualizado_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button btnCerrarForma;
        private Label label2;
        private ListBox lbxInfoMunicipios;
        private Label label3;
        private TextBox txtCodigoMunicipio;
        private ListBox lbxDepartamentos;
        private Label label4;
        private ListBox lbxCuencas;
        private Label label5;
        private TextBox txtNombreMunicipio;
        private Label label6;
        private Button btnActualizaMunicipio;
    }
}