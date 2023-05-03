namespace PescaArtesanal_WindowsForms.Formularios
{
    partial class CuencaNueva
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
            label4 = new Label();
            txtNombreCuenca = new TextBox();
            btnGuardarCuenca = new Button();
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
            label1.Text = "Registra Nueva Cuenca";
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
            label2.Location = new Point(236, 106);
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
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(266, 250);
            label4.Name = "label4";
            label4.Size = new Size(113, 21);
            label4.TabIndex = 6;
            label4.Text = "Nueva Cuenca:";
            // 
            // txtNombreCuenca
            // 
            txtNombreCuenca.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtNombreCuenca.Location = new Point(402, 246);
            txtNombreCuenca.Margin = new Padding(3, 2, 3, 2);
            txtNombreCuenca.Name = "txtNombreCuenca";
            txtNombreCuenca.Size = new Size(238, 29);
            txtNombreCuenca.TabIndex = 7;
            // 
            // btnGuardarCuenca
            // 
            btnGuardarCuenca.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnGuardarCuenca.Location = new Point(659, 245);
            btnGuardarCuenca.Margin = new Padding(3, 2, 3, 2);
            btnGuardarCuenca.Name = "btnGuardarCuenca";
            btnGuardarCuenca.Size = new Size(133, 30);
            btnGuardarCuenca.TabIndex = 8;
            btnGuardarCuenca.Text = "Guardar";
            btnGuardarCuenca.UseVisualStyleBackColor = true;
            btnGuardarCuenca.Click += btnGuardarCuenca_Click;
            // 
            // CuencaNueva
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(880, 463);
            Controls.Add(btnGuardarCuenca);
            Controls.Add(txtNombreCuenca);
            Controls.Add(label4);
            Controls.Add(lbxCuencas);
            Controls.Add(label2);
            Controls.Add(btnCerrarForma);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            MaximumSize = new Size(880, 463);
            MinimumSize = new Size(880, 463);
            Name = "CuencaNueva";
            Text = "Nueva Cuenca";
            Load += CuencaNueva_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button btnCerrarForma;
        private Label label2;
        private ListBox lbxCuencas;
        private Label label4;
        private TextBox txtNombreCuenca;
        private Button btnGuardarCuenca;
    }
}