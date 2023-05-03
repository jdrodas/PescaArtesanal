namespace PescaArtesanal_WindowsForms.Formularios
{
    partial class CuencaBorrada
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
            lbxCuencas = new ListBox();
            txtCodigoCuenca = new TextBox();
            label3 = new Label();
            btnBorrarCuenca = new Button();
            txtNombreCuenca = new TextBox();
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
            label1.Text = "Borrar Cuenca";
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
            label2.Location = new Point(236, 101);
            label2.Name = "label2";
            label2.Size = new Size(143, 21);
            label2.TabIndex = 2;
            label2.Text = "Cuencas existentes:";
            // 
            // lbxCuencas
            // 
            lbxCuencas.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lbxCuencas.FormattingEnabled = true;
            lbxCuencas.ItemHeight = 21;
            lbxCuencas.Location = new Point(402, 101);
            lbxCuencas.Margin = new Padding(3, 2, 3, 2);
            lbxCuencas.Name = "lbxCuencas";
            lbxCuencas.Size = new Size(238, 109);
            lbxCuencas.TabIndex = 4;
            lbxCuencas.SelectedIndexChanged += lbxCuencas_SelectedIndexChanged;
            // 
            // txtCodigoCuenca
            // 
            txtCodigoCuenca.Enabled = false;
            txtCodigoCuenca.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtCodigoCuenca.Location = new Point(402, 237);
            txtCodigoCuenca.Margin = new Padding(3, 2, 3, 2);
            txtCodigoCuenca.Name = "txtCodigoCuenca";
            txtCodigoCuenca.Size = new Size(238, 29);
            txtCodigoCuenca.TabIndex = 15;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(316, 240);
            label3.Name = "label3";
            label3.Size = new Size(63, 21);
            label3.TabIndex = 14;
            label3.Text = "Código:";
            // 
            // btnBorrarCuenca
            // 
            btnBorrarCuenca.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnBorrarCuenca.Location = new Point(674, 284);
            btnBorrarCuenca.Margin = new Padding(3, 2, 3, 2);
            btnBorrarCuenca.Name = "btnBorrarCuenca";
            btnBorrarCuenca.Size = new Size(133, 30);
            btnBorrarCuenca.TabIndex = 13;
            btnBorrarCuenca.Text = "Borrar";
            btnBorrarCuenca.UseVisualStyleBackColor = true;
            btnBorrarCuenca.Click += btnBorrarCuenca_Click;
            // 
            // txtNombreCuenca
            // 
            txtNombreCuenca.Enabled = false;
            txtNombreCuenca.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtNombreCuenca.Location = new Point(402, 286);
            txtNombreCuenca.Margin = new Padding(3, 2, 3, 2);
            txtNombreCuenca.Name = "txtNombreCuenca";
            txtNombreCuenca.Size = new Size(238, 29);
            txtNombreCuenca.TabIndex = 12;
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
            // CuencaBorrada
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(880, 463);
            Controls.Add(txtCodigoCuenca);
            Controls.Add(label3);
            Controls.Add(btnBorrarCuenca);
            Controls.Add(txtNombreCuenca);
            Controls.Add(label5);
            Controls.Add(lbxCuencas);
            Controls.Add(label2);
            Controls.Add(btnCerrarForma);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            MaximumSize = new Size(880, 463);
            MinimumSize = new Size(880, 463);
            Name = "CuencaBorrada";
            Text = "Nuevo Municipio";
            Load += CuencaBorrada_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button btnCerrarForma;
        private Label label2;
        private ListBox lbxCuencas;
        private TextBox txtCodigoCuenca;
        private Label label3;
        private Button btnBorrarCuenca;
        private TextBox txtNombreCuenca;
        private Label label5;
    }
}