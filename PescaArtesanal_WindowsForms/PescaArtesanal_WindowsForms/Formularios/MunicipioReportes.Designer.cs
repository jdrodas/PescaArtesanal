namespace PescaArtesanal_WindowsForms.Formularios
{
    partial class MunicipioReportes
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
            txtCodigoMunicipio = new TextBox();
            label3 = new Label();
            dgvActividades = new DataGridView();
            lbxDepartamentos = new ListBox();
            label2 = new Label();
            lbxMunicipios = new ListBox();
            label5 = new Label();
            gbxActividades = new GroupBox();
            label4 = new Label();
            txtTotalActividades = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgvActividades).BeginInit();
            gbxActividades.SuspendLayout();
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
            label1.Size = new Size(1006, 41);
            label1.TabIndex = 0;
            label1.Text = "Actividades de Pesca por Municipio";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnCerrarForma
            // 
            btnCerrarForma.FlatStyle = FlatStyle.Flat;
            btnCerrarForma.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnCerrarForma.Location = new Point(971, 4);
            btnCerrarForma.Margin = new Padding(3, 4, 3, 4);
            btnCerrarForma.Name = "btnCerrarForma";
            btnCerrarForma.Size = new Size(27, 32);
            btnCerrarForma.TabIndex = 1;
            btnCerrarForma.Text = "X";
            btnCerrarForma.UseVisualStyleBackColor = true;
            btnCerrarForma.Click += btnCerrarForma_Click;
            // 
            // txtCodigoMunicipio
            // 
            txtCodigoMunicipio.BackColor = Color.White;
            txtCodigoMunicipio.Enabled = false;
            txtCodigoMunicipio.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtCodigoMunicipio.Location = new Point(359, 244);
            txtCodigoMunicipio.Margin = new Padding(1);
            txtCodigoMunicipio.Name = "txtCodigoMunicipio";
            txtCodigoMunicipio.Size = new Size(138, 34);
            txtCodigoMunicipio.TabIndex = 9;
            txtCodigoMunicipio.TextAlign = HorizontalAlignment.Right;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(48, 250);
            label3.Margin = new Padding(1, 0, 1, 0);
            label3.Name = "label3";
            label3.Size = new Size(295, 28);
            label3.TabIndex = 8;
            label3.Text = "Código Municipio Seleccionado:";
            label3.TextAlign = ContentAlignment.MiddleRight;
            // 
            // dgvActividades
            // 
            dgvActividades.AllowUserToAddRows = false;
            dgvActividades.AllowUserToDeleteRows = false;
            dgvActividades.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvActividades.Location = new Point(20, 33);
            dgvActividades.Margin = new Padding(3, 2, 3, 2);
            dgvActividades.Name = "dgvActividades";
            dgvActividades.ReadOnly = true;
            dgvActividades.RowHeadersWidth = 51;
            dgvActividades.RowTemplate.Height = 29;
            dgvActividades.Size = new Size(840, 144);
            dgvActividades.TabIndex = 10;
            // 
            // lbxDepartamentos
            // 
            lbxDepartamentos.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lbxDepartamentos.FormattingEnabled = true;
            lbxDepartamentos.ItemHeight = 28;
            lbxDepartamentos.Location = new Point(188, 82);
            lbxDepartamentos.Margin = new Padding(3, 4, 3, 4);
            lbxDepartamentos.Name = "lbxDepartamentos";
            lbxDepartamentos.Size = new Size(309, 116);
            lbxDepartamentos.TabIndex = 13;
            lbxDepartamentos.SelectedIndexChanged += lbxDepartamentos_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(42, 82);
            label2.Name = "label2";
            label2.Size = new Size(143, 28);
            label2.TabIndex = 12;
            label2.Text = "Departamento:";
            // 
            // lbxMunicipios
            // 
            lbxMunicipios.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lbxMunicipios.FormattingEnabled = true;
            lbxMunicipios.ItemHeight = 28;
            lbxMunicipios.Location = new Point(629, 82);
            lbxMunicipios.Margin = new Padding(3, 4, 3, 4);
            lbxMunicipios.Name = "lbxMunicipios";
            lbxMunicipios.Size = new Size(309, 116);
            lbxMunicipios.TabIndex = 15;
            lbxMunicipios.SelectedIndexChanged += lbxMunicipios_SelectedIndexChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(518, 82);
            label5.Name = "label5";
            label5.Size = new Size(104, 28);
            label5.TabIndex = 14;
            label5.Text = "Municipio:";
            // 
            // gbxActividades
            // 
            gbxActividades.Controls.Add(txtTotalActividades);
            gbxActividades.Controls.Add(label4);
            gbxActividades.Controls.Add(dgvActividades);
            gbxActividades.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            gbxActividades.Location = new Point(48, 317);
            gbxActividades.Margin = new Padding(3, 2, 3, 2);
            gbxActividades.Name = "gbxActividades";
            gbxActividades.Size = new Size(875, 252);
            gbxActividades.Size = new Size(766, 189);
            gbxActividades.TabIndex = 16;
            gbxActividades.TabStop = false;
            gbxActividades.Text = "Actividades de pesca en el municipio:";
            // 
            // txtTotalActividades
            // 
            txtTotalActividades.Location = new Point(165, 143);
            txtTotalActividades.Margin = new Padding(3, 2, 3, 2);
            txtTotalActividades.Name = "txtTotalActividades";
            txtTotalActividades.Size = new Size(110, 29);
            txtTotalActividades.TabIndex = 12;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(22, 194);
            label4.Name = "label4";
            label4.Size = new Size(161, 28);
            label4.TabIndex = 11;
            label4.Text = "Total actividades:";
            // 
            txtTotalActividades.Location = new Point(189, 191);
            txtTotalActividades.Name = "txtTotalActividades";
            txtTotalActividades.Size = new Size(125, 34);
            txtTotalActividades.TabIndex = 12;
            // MunicipioReportes
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1006, 617);
            Controls.Add(gbxActividades);
            Controls.Add(lbxMunicipios);
            Controls.Add(label5);
            Controls.Add(lbxDepartamentos);
            Controls.Add(label2);
            Controls.Add(txtCodigoMunicipio);
            Controls.Add(label3);
            Controls.Add(btnCerrarForma);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            MaximumSize = new Size(1006, 617);
            MinimumSize = new Size(1006, 617);
            Name = "MunicipioReportes";
            Text = "Reportes Municipio";
            Load += MunicipioReportes_Load;
            ((System.ComponentModel.ISupportInitialize)dgvActividades).EndInit();
            gbxActividades.ResumeLayout(false);
            gbxActividades.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button btnCerrarForma;
        private TextBox txtCodigoMunicipio;
        private Label label3;
        private DataGridView dgvActividades;
        private ListBox lbxDepartamentos;
        private Label label2;
        private ListBox lbxMunicipios;
        private Label label5;
        private GroupBox gbxActividades;
        private TextBox txtTotalActividades;
        private Label label4;
    }
}