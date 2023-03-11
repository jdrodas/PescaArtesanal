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
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(1406, 53);
            label1.TabIndex = 0;
            label1.Text = "Borrar Municipio existente";
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
            // lbxInfoMunicipios
            // 
            lbxInfoMunicipios.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lbxInfoMunicipios.FormattingEnabled = true;
            lbxInfoMunicipios.ItemHeight = 32;
            lbxInfoMunicipios.Location = new Point(413, 93);
            lbxInfoMunicipios.Name = "lbxInfoMunicipios";
            lbxInfoMunicipios.Size = new Size(824, 132);
            lbxInfoMunicipios.TabIndex = 5;
            lbxInfoMunicipios.SelectedIndexChanged += lbxInfoMunicipios_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(147, 93);
            label2.Name = "label2";
            label2.Size = new Size(260, 32);
            label2.TabIndex = 4;
            label2.Text = "Municipios registrados:";
            // 
            // txtNombreMunicipio
            // 
            txtNombreMunicipio.Enabled = false;
            txtNombreMunicipio.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtNombreMunicipio.Location = new Point(845, 287);
            txtNombreMunicipio.Margin = new Padding(4, 3, 4, 3);
            txtNombreMunicipio.Name = "txtNombreMunicipio";
            txtNombreMunicipio.Size = new Size(392, 39);
            txtNombreMunicipio.TabIndex = 15;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(555, 292);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(261, 32);
            label6.TabIndex = 14;
            label6.Text = "Nombre del Municipio:";
            // 
            // txtCodigoMunicipio
            // 
            txtCodigoMunicipio.BackColor = Color.White;
            txtCodigoMunicipio.Enabled = false;
            txtCodigoMunicipio.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtCodigoMunicipio.Location = new Point(413, 287);
            txtCodigoMunicipio.Name = "txtCodigoMunicipio";
            txtCodigoMunicipio.Size = new Size(84, 39);
            txtCodigoMunicipio.TabIndex = 13;
            txtCodigoMunicipio.TextAlign = HorizontalAlignment.Right;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(169, 292);
            label3.Name = "label3";
            label3.Size = new Size(241, 32);
            label3.TabIndex = 12;
            label3.Text = "Código seleccionado:";
            label3.TextAlign = ContentAlignment.MiddleRight;
            // 
            // btnBorraMunicipio
            // 
            btnBorraMunicipio.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnBorraMunicipio.Location = new Point(535, 410);
            btnBorraMunicipio.Margin = new Padding(4, 3, 4, 3);
            btnBorraMunicipio.Name = "btnBorraMunicipio";
            btnBorraMunicipio.Size = new Size(316, 50);
            btnBorraMunicipio.TabIndex = 17;
            btnBorraMunicipio.Text = "Borrar este municipio";
            btnBorraMunicipio.UseVisualStyleBackColor = true;
            btnBorraMunicipio.Click += btnBorraMunicipio_Click;
            // 
            // MunicipioBorrado
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1406, 933);
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
            Margin = new Padding(6, 7, 6, 7);
            Name = "MunicipioBorrado";
            Text = "Borra Municipio";
            Load += MunicipioBorrado_Load;
            Paint += MunicipioBorrado_Paint;
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