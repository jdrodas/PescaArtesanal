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
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(1406, 52);
            label1.TabIndex = 0;
            label1.Text = "Actualiza Municipio existente";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnCerrarForma
            // 
            btnCerrarForma.FlatStyle = FlatStyle.Flat;
            btnCerrarForma.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnCerrarForma.Location = new Point(1364, 5);
            btnCerrarForma.Margin = new Padding(4, 5, 4, 5);
            btnCerrarForma.Name = "btnCerrarForma";
            btnCerrarForma.Size = new Size(34, 40);
            btnCerrarForma.TabIndex = 1;
            btnCerrarForma.Text = "X";
            btnCerrarForma.UseVisualStyleBackColor = true;
            btnCerrarForma.Click += btnCerrarForma_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(128, 140);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(260, 32);
            label2.TabIndex = 2;
            label2.Text = "Municipios registrados:";
            // 
            // lbxInfoMunicipios
            // 
            lbxInfoMunicipios.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lbxInfoMunicipios.FormattingEnabled = true;
            lbxInfoMunicipios.ItemHeight = 32;
            lbxInfoMunicipios.Location = new Point(410, 140);
            lbxInfoMunicipios.Margin = new Padding(2);
            lbxInfoMunicipios.Name = "lbxInfoMunicipios";
            lbxInfoMunicipios.Size = new Size(742, 132);
            lbxInfoMunicipios.TabIndex = 3;
            lbxInfoMunicipios.SelectedIndexChanged += lbxInfoMunicipios_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(146, 312);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(241, 32);
            label3.TabIndex = 4;
            label3.Text = "Código seleccionado:";
            label3.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtCodigoMunicipio
            // 
            txtCodigoMunicipio.BackColor = Color.White;
            txtCodigoMunicipio.Enabled = false;
            txtCodigoMunicipio.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtCodigoMunicipio.Location = new Point(410, 305);
            txtCodigoMunicipio.Margin = new Padding(2);
            txtCodigoMunicipio.Name = "txtCodigoMunicipio";
            txtCodigoMunicipio.Size = new Size(150, 39);
            txtCodigoMunicipio.TabIndex = 5;
            txtCodigoMunicipio.TextAlign = HorizontalAlignment.Right;
            // 
            // lbxDepartamentos
            // 
            lbxDepartamentos.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lbxDepartamentos.FormattingEnabled = true;
            lbxDepartamentos.ItemHeight = 32;
            lbxDepartamentos.Location = new Point(330, 406);
            lbxDepartamentos.Margin = new Padding(4, 2, 4, 2);
            lbxDepartamentos.Name = "lbxDepartamentos";
            lbxDepartamentos.Size = new Size(338, 132);
            lbxDepartamentos.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(146, 406);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(173, 32);
            label4.TabIndex = 6;
            label4.Text = "Departamento:";
            // 
            // lbxCuencas
            // 
            lbxCuencas.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lbxCuencas.FormattingEnabled = true;
            lbxCuencas.ItemHeight = 32;
            lbxCuencas.Location = new Point(802, 406);
            lbxCuencas.Margin = new Padding(4, 2, 4, 2);
            lbxCuencas.Name = "lbxCuencas";
            lbxCuencas.Size = new Size(344, 132);
            lbxCuencas.TabIndex = 9;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(702, 406);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(98, 32);
            label5.TabIndex = 8;
            label5.Text = "Cuenca:";
            // 
            // txtNombreMunicipio
            // 
            txtNombreMunicipio.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtNombreMunicipio.Location = new Point(410, 605);
            txtNombreMunicipio.Margin = new Padding(4, 2, 4, 2);
            txtNombreMunicipio.Name = "txtNombreMunicipio";
            txtNombreMunicipio.Size = new Size(406, 39);
            txtNombreMunicipio.TabIndex = 11;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(126, 612);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(261, 32);
            label6.TabIndex = 10;
            label6.Text = "Nombre del Municipio:";
            label6.TextAlign = ContentAlignment.MiddleRight;
            // 
            // btnActualizaMunicipio
            // 
            btnActualizaMunicipio.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnActualizaMunicipio.Location = new Point(861, 602);
            btnActualizaMunicipio.Margin = new Padding(4, 2, 4, 2);
            btnActualizaMunicipio.Name = "btnActualizaMunicipio";
            btnActualizaMunicipio.Size = new Size(190, 50);
            btnActualizaMunicipio.TabIndex = 12;
            btnActualizaMunicipio.Text = "Actualizar";
            btnActualizaMunicipio.UseVisualStyleBackColor = true;
            btnActualizaMunicipio.Click += btnActualizaMunicipio_Click;
            // 
            // MunicipioActualizado
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1406, 932);
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
            Margin = new Padding(6, 8, 6, 8);
            Name = "MunicipioActualizado";
            Text = "Actualiza Municipio";
            Load += MunicipioActualizado_Load;
            Paint += MunicipioActualizado_Paint;
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