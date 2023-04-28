namespace PescaArtesanal_NoSQL_WindowsForms.Formularios
{
    partial class DepartamentoBorrado
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
            lbxDepartamentos = new ListBox();
            txtIdDepartamento = new TextBox();
            label3 = new Label();
            btnBorrarDepartamento = new Button();
            txtNombreDepartamento = new TextBox();
            label5 = new Label();
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
            label1.Text = "Borrar Departamento";
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
            label2.Location = new Point(187, 101);
            label2.Name = "label2";
            label2.Size = new Size(192, 21);
            label2.TabIndex = 2;
            label2.Text = "Departamentos existentes:";
            // 
            // lbxDepartamentos
            // 
            lbxDepartamentos.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lbxDepartamentos.FormattingEnabled = true;
            lbxDepartamentos.ItemHeight = 21;
            lbxDepartamentos.Location = new Point(402, 101);
            lbxDepartamentos.Margin = new Padding(3, 2, 3, 2);
            lbxDepartamentos.Name = "lbxDepartamentos";
            lbxDepartamentos.Size = new Size(238, 109);
            lbxDepartamentos.TabIndex = 4;
            lbxDepartamentos.SelectedIndexChanged += lbxDepartamentos_SelectedIndexChanged;
            // 
            // txtIdDepartamento
            // 
            txtIdDepartamento.Enabled = false;
            txtIdDepartamento.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtIdDepartamento.Location = new Point(402, 237);
            txtIdDepartamento.Margin = new Padding(3, 2, 3, 2);
            txtIdDepartamento.Name = "txtIdDepartamento";
            txtIdDepartamento.Size = new Size(238, 29);
            txtIdDepartamento.TabIndex = 15;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(353, 241);
            label3.Name = "label3";
            label3.Size = new Size(26, 21);
            label3.TabIndex = 14;
            label3.Text = "Id:";
            // 
            // btnBorrarDepartamento
            // 
            btnBorrarDepartamento.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnBorrarDepartamento.Location = new Point(674, 284);
            btnBorrarDepartamento.Margin = new Padding(3, 2, 3, 2);
            btnBorrarDepartamento.Name = "btnBorrarDepartamento";
            btnBorrarDepartamento.Size = new Size(133, 30);
            btnBorrarDepartamento.TabIndex = 13;
            btnBorrarDepartamento.Text = "Borrar";
            btnBorrarDepartamento.UseVisualStyleBackColor = true;
            btnBorrarDepartamento.Click += btnBorrarDepartamento_Click;
            // 
            // txtNombreDepartamento
            // 
            txtNombreDepartamento.Enabled = false;
            txtNombreDepartamento.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtNombreDepartamento.Location = new Point(402, 286);
            txtNombreDepartamento.Margin = new Padding(3, 2, 3, 2);
            txtNombreDepartamento.Name = "txtNombreDepartamento";
            txtNombreDepartamento.Size = new Size(238, 29);
            txtNombreDepartamento.TabIndex = 12;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(308, 289);
            label5.Name = "label5";
            label5.Size = new Size(71, 21);
            label5.TabIndex = 11;
            label5.Text = "Nombre:";
            // 
            // DepartamentoBorrado
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(880, 463);
            Controls.Add(txtIdDepartamento);
            Controls.Add(label3);
            Controls.Add(btnBorrarDepartamento);
            Controls.Add(txtNombreDepartamento);
            Controls.Add(label5);
            Controls.Add(lbxDepartamentos);
            Controls.Add(label2);
            Controls.Add(btnCerrarForma);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            MaximumSize = new Size(880, 463);
            MinimumSize = new Size(880, 463);
            Name = "DepartamentoBorrado";
            Text = "Nuevo Municipio";
            Load += DepartamentoBorrado_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button btnCerrarForma;
        private Label label2;
        private ListBox lbxDepartamentos;
        private TextBox txtIdDepartamento;
        private Label label3;
        private Button btnBorrarDepartamento;
        private TextBox txtNombreDepartamento;
        private Label label5;
    }
}