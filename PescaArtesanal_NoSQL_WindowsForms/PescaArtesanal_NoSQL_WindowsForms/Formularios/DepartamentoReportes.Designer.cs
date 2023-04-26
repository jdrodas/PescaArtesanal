namespace PescaArtesanal_NoSQL_WindowsForms.Formularios
{
    partial class DepartamentoReportes
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
            dgvActividades = new DataGridView();
            lbxDepartamentos = new ListBox();
            label2 = new Label();
            gbxActividades = new GroupBox();
            txtTotalActividades = new TextBox();
            label4 = new Label();
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
            label1.Size = new Size(881, 31);
            label1.TabIndex = 0;
            label1.Text = "Actividades de Pesca por Departamento";
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
            // dgvActividades
            // 
            dgvActividades.AllowUserToAddRows = false;
            dgvActividades.AllowUserToDeleteRows = false;
            dgvActividades.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvActividades.Location = new Point(18, 25);
            dgvActividades.Margin = new Padding(3, 1, 3, 1);
            dgvActividades.Name = "dgvActividades";
            dgvActividades.ReadOnly = true;
            dgvActividades.RowHeadersWidth = 51;
            dgvActividades.RowTemplate.Height = 29;
            dgvActividades.Size = new Size(735, 160);
            dgvActividades.TabIndex = 10;
            // 
            // lbxDepartamentos
            // 
            lbxDepartamentos.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lbxDepartamentos.FormattingEnabled = true;
            lbxDepartamentos.ItemHeight = 21;
            lbxDepartamentos.Location = new Point(164, 61);
            lbxDepartamentos.Name = "lbxDepartamentos";
            lbxDepartamentos.Size = new Size(271, 67);
            lbxDepartamentos.TabIndex = 13;
            lbxDepartamentos.SelectedIndexChanged += lbxDepartamentos_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(36, 61);
            label2.Name = "label2";
            label2.Size = new Size(113, 21);
            label2.TabIndex = 12;
            label2.Text = "Departamento:";
            // 
            // gbxActividades
            // 
            gbxActividades.Controls.Add(txtTotalActividades);
            gbxActividades.Controls.Add(label4);
            gbxActividades.Controls.Add(dgvActividades);
            gbxActividades.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            gbxActividades.Location = new Point(42, 157);
            gbxActividades.Margin = new Padding(3, 1, 3, 1);
            gbxActividades.Name = "gbxActividades";
            gbxActividades.Padding = new Padding(3, 2, 3, 2);
            gbxActividades.Size = new Size(778, 266);
            gbxActividades.TabIndex = 16;
            gbxActividades.TabStop = false;
            gbxActividades.Text = "Actividades de pesca en el departamento:";
            // 
            // txtTotalActividades
            // 
            txtTotalActividades.Enabled = false;
            txtTotalActividades.Location = new Point(163, 207);
            txtTotalActividades.Margin = new Padding(3, 1, 3, 1);
            txtTotalActividades.Name = "txtTotalActividades";
            txtTotalActividades.Size = new Size(110, 29);
            txtTotalActividades.TabIndex = 12;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(18, 209);
            label4.Name = "label4";
            label4.Size = new Size(126, 21);
            label4.TabIndex = 11;
            label4.Text = "Total actividades:";
            // 
            // DepartamentoReportes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(881, 463);
            Controls.Add(gbxActividades);
            Controls.Add(lbxDepartamentos);
            Controls.Add(label2);
            Controls.Add(btnCerrarForma);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            MaximumSize = new Size(881, 463);
            MinimumSize = new Size(881, 463);
            Name = "DepartamentoReportes";
            Text = "Reportes Departamento";
            Load += DepartamentoReportes_Load;
            ((System.ComponentModel.ISupportInitialize)dgvActividades).EndInit();
            gbxActividades.ResumeLayout(false);
            gbxActividades.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button btnCerrarForma;
        private DataGridView dgvActividades;
        private ListBox lbxDepartamentos;
        private Label label2;
        private GroupBox gbxActividades;
        private TextBox txtTotalActividades;
        private Label label4;
    }
}