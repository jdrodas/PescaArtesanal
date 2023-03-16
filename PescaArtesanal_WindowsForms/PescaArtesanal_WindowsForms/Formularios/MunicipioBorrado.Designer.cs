namespace PescaArtesanal_WindowsForms.Formularios
{
    partial class MunicipioBorrado
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
            lbxInfoMunicipios = new ListBox();
            label2 = new Label();
            txtNombreMunicipio = new TextBox();
            label6 = new Label();
            txtCodigoMunicipio = new TextBox();
            label3 = new Label();
            btnBorraMunicipio = new Button();
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
            label1.Text = "Borrar Municipio existente";
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
            // lbxInfoMunicipios
            // 
            lbxInfoMunicipios.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lbxInfoMunicipios.FormattingEnabled = true;
            lbxInfoMunicipios.ItemHeight = 21;
            lbxInfoMunicipios.Location = new Point(247, 102);
            lbxInfoMunicipios.Margin = new Padding(2);
            lbxInfoMunicipios.Name = "lbxInfoMunicipios";
            lbxInfoMunicipios.Size = new Size(578, 67);
            lbxInfoMunicipios.TabIndex = 5;
            lbxInfoMunicipios.SelectedIndexChanged += lbxInfoMunicipios_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(61, 102);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(171, 21);
            label2.TabIndex = 4;
            label2.Text = "Municipios registrados:";
            // 
            // txtNombreMunicipio
            // 
            txtNombreMunicipio.Enabled = false;
            txtNombreMunicipio.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtNombreMunicipio.Location = new Point(550, 218);
            txtNombreMunicipio.Margin = new Padding(3, 2, 3, 2);
            txtNombreMunicipio.Name = "txtNombreMunicipio";
            txtNombreMunicipio.Size = new Size(276, 29);
            txtNombreMunicipio.TabIndex = 15;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(346, 221);
            label6.Name = "label6";
            label6.Size = new Size(169, 21);
            label6.TabIndex = 14;
            label6.Text = "Nombre del Municipio:";
            // 
            // txtCodigoMunicipio
            // 
            txtCodigoMunicipio.BackColor = Color.White;
            txtCodigoMunicipio.Enabled = false;
            txtCodigoMunicipio.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtCodigoMunicipio.Location = new Point(247, 218);
            txtCodigoMunicipio.Margin = new Padding(2);
            txtCodigoMunicipio.Name = "txtCodigoMunicipio";
            txtCodigoMunicipio.Size = new Size(60, 29);
            txtCodigoMunicipio.TabIndex = 13;
            txtCodigoMunicipio.TextAlign = HorizontalAlignment.Right;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(76, 221);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(156, 21);
            label3.TabIndex = 12;
            label3.Text = "Código seleccionado:";
            label3.TextAlign = ContentAlignment.MiddleRight;
            // 
            // btnBorraMunicipio
            // 
            btnBorraMunicipio.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnBorraMunicipio.Location = new Point(332, 292);
            btnBorraMunicipio.Margin = new Padding(3, 2, 3, 2);
            btnBorraMunicipio.Name = "btnBorraMunicipio";
            btnBorraMunicipio.Size = new Size(221, 30);
            btnBorraMunicipio.TabIndex = 17;
            btnBorraMunicipio.Text = "Borrar este municipio";
            btnBorraMunicipio.UseVisualStyleBackColor = true;
            btnBorraMunicipio.Click += btnBorraMunicipio_Click;
            // 
            // MunicipioBorrado
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(880, 463);
            Controls.Add(btnBorraMunicipio);
            Controls.Add(txtNombreMunicipio);
            Controls.Add(label6);
            Controls.Add(txtCodigoMunicipio);
            Controls.Add(label3);
            Controls.Add(lbxInfoMunicipios);
            Controls.Add(label2);
            Controls.Add(btnCerrarForma);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4);
            Name = "MunicipioBorrado";
            Text = "Borra Municipio";
            Load += MunicipioBorrado_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button btnCerrarForma;
        private ListBox lbxInfoMunicipios;
        private Label label2;
        private TextBox txtNombreMunicipio;
        private Label label6;
        private TextBox txtCodigoMunicipio;
        private Label label3;
        private Button btnBorraMunicipio;
    }
}