namespace PescaArtesanal_WindowsForms
{
    partial class Principal
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panelContenedor = new Panel();
            panelMenu = new Panel();
            panelCrudMunicipios = new Panel();
            btnFormaReportesMunicipio = new Button();
            btnFormaBorraMunicipio = new Button();
            btnFormaActualizaMunicipio = new Button();
            btnFormaNuevoMunicipio = new Button();
            btnFormasMunicipios = new Button();
            pbxLogoPesca = new PictureBox();
            panelTitulo = new Panel();
            etiquetaTituloAplicacion = new Label();
            panelFormularios = new Panel();
            panelContenedor.SuspendLayout();
            panelMenu.SuspendLayout();
            panelCrudMunicipios.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbxLogoPesca).BeginInit();
            panelTitulo.SuspendLayout();
            SuspendLayout();
            // 
            // panelContenedor
            // 
            panelContenedor.BackColor = Color.FromArgb(192, 192, 255);
            panelContenedor.Controls.Add(panelMenu);
            panelContenedor.Controls.Add(panelTitulo);
            panelContenedor.Controls.Add(panelFormularios);
            panelContenedor.Dock = DockStyle.Fill;
            panelContenedor.Location = new Point(0, 0);
            panelContenedor.Margin = new Padding(2);
            panelContenedor.Name = "panelContenedor";
            panelContenedor.Size = new Size(735, 390);
            panelContenedor.TabIndex = 0;
            // 
            // panelMenu
            // 
            panelMenu.AutoScroll = true;
            panelMenu.BackColor = Color.SteelBlue;
            panelMenu.Controls.Add(panelCrudMunicipios);
            panelMenu.Controls.Add(btnFormasMunicipios);
            panelMenu.Controls.Add(pbxLogoPesca);
            panelMenu.Dock = DockStyle.Left;
            panelMenu.Location = new Point(0, 24);
            panelMenu.Margin = new Padding(2);
            panelMenu.Name = "panelMenu";
            panelMenu.Size = new Size(132, 366);
            panelMenu.TabIndex = 1;
            // 
            // panelCrudMunicipios
            // 
            panelCrudMunicipios.Controls.Add(btnFormaReportesMunicipio);
            panelCrudMunicipios.Controls.Add(btnFormaBorraMunicipio);
            panelCrudMunicipios.Controls.Add(btnFormaActualizaMunicipio);
            panelCrudMunicipios.Controls.Add(btnFormaNuevoMunicipio);
            panelCrudMunicipios.Dock = DockStyle.Top;
            panelCrudMunicipios.Location = new Point(0, 87);
            panelCrudMunicipios.Name = "panelCrudMunicipios";
            panelCrudMunicipios.Size = new Size(132, 100);
            panelCrudMunicipios.TabIndex = 1;
            panelCrudMunicipios.Visible = false;
            // 
            // btnFormaReportesMunicipio
            // 
            btnFormaReportesMunicipio.BackColor = Color.LightGray;
            btnFormaReportesMunicipio.Dock = DockStyle.Top;
            btnFormaReportesMunicipio.FlatAppearance.BorderSize = 0;
            btnFormaReportesMunicipio.FlatStyle = FlatStyle.Flat;
            btnFormaReportesMunicipio.Location = new Point(0, 69);
            btnFormaReportesMunicipio.Name = "btnFormaReportesMunicipio";
            btnFormaReportesMunicipio.Padding = new Padding(10, 0, 0, 0);
            btnFormaReportesMunicipio.Size = new Size(132, 23);
            btnFormaReportesMunicipio.TabIndex = 3;
            btnFormaReportesMunicipio.Text = "Reportes Municipio";
            btnFormaReportesMunicipio.TextAlign = ContentAlignment.MiddleLeft;
            btnFormaReportesMunicipio.UseVisualStyleBackColor = true;
            // 
            // btnFormaBorraMunicipio
            // 
            btnFormaBorraMunicipio.BackColor = Color.LightGray;
            btnFormaBorraMunicipio.Dock = DockStyle.Top;
            btnFormaBorraMunicipio.FlatAppearance.BorderSize = 0;
            btnFormaBorraMunicipio.FlatStyle = FlatStyle.Flat;
            btnFormaBorraMunicipio.Location = new Point(0, 46);
            btnFormaBorraMunicipio.Name = "btnFormaBorraMunicipio";
            btnFormaBorraMunicipio.Padding = new Padding(10, 0, 0, 0);
            btnFormaBorraMunicipio.Size = new Size(132, 23);
            btnFormaBorraMunicipio.TabIndex = 2;
            btnFormaBorraMunicipio.Text = "Borra Municipio";
            btnFormaBorraMunicipio.TextAlign = ContentAlignment.MiddleLeft;
            btnFormaBorraMunicipio.UseVisualStyleBackColor = true;
            // 
            // btnFormaActualizaMunicipio
            // 
            btnFormaActualizaMunicipio.BackColor = Color.LightGray;
            btnFormaActualizaMunicipio.Dock = DockStyle.Top;
            btnFormaActualizaMunicipio.FlatAppearance.BorderSize = 0;
            btnFormaActualizaMunicipio.FlatStyle = FlatStyle.Flat;
            btnFormaActualizaMunicipio.Location = new Point(0, 23);
            btnFormaActualizaMunicipio.Name = "btnFormaActualizaMunicipio";
            btnFormaActualizaMunicipio.Padding = new Padding(10, 0, 0, 0);
            btnFormaActualizaMunicipio.Size = new Size(132, 23);
            btnFormaActualizaMunicipio.TabIndex = 1;
            btnFormaActualizaMunicipio.Text = "Actualiza Municipio";
            btnFormaActualizaMunicipio.TextAlign = ContentAlignment.MiddleLeft;
            btnFormaActualizaMunicipio.UseVisualStyleBackColor = true;
            // 
            // btnFormaNuevoMunicipio
            // 
            btnFormaNuevoMunicipio.BackColor = Color.LightGray;
            btnFormaNuevoMunicipio.Dock = DockStyle.Top;
            btnFormaNuevoMunicipio.FlatAppearance.BorderSize = 0;
            btnFormaNuevoMunicipio.FlatStyle = FlatStyle.Flat;
            btnFormaNuevoMunicipio.Location = new Point(0, 0);
            btnFormaNuevoMunicipio.Name = "btnFormaNuevoMunicipio";
            btnFormaNuevoMunicipio.Padding = new Padding(10, 0, 0, 0);
            btnFormaNuevoMunicipio.Size = new Size(132, 23);
            btnFormaNuevoMunicipio.TabIndex = 0;
            btnFormaNuevoMunicipio.Text = "Nuevo Municipio";
            btnFormaNuevoMunicipio.TextAlign = ContentAlignment.MiddleLeft;
            btnFormaNuevoMunicipio.UseVisualStyleBackColor = true;
            // 
            // btnFormasMunicipios
            // 
            btnFormasMunicipios.BackColor = Color.Gray;
            btnFormasMunicipios.Dock = DockStyle.Top;
            btnFormasMunicipios.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnFormasMunicipios.ForeColor = Color.White;
            btnFormasMunicipios.Location = new Point(0, 55);
            btnFormasMunicipios.Name = "btnFormasMunicipios";
            btnFormasMunicipios.Size = new Size(132, 32);
            btnFormasMunicipios.TabIndex = 0;
            btnFormasMunicipios.Text = "Municipios";
            btnFormasMunicipios.TextAlign = ContentAlignment.MiddleLeft;
            btnFormasMunicipios.UseVisualStyleBackColor = false;
            btnFormasMunicipios.Click += btnFormasMunicipios_Click;
            // 
            // pbxLogoPesca
            // 
            pbxLogoPesca.BackColor = Color.FromArgb(255, 255, 192);
            pbxLogoPesca.Dock = DockStyle.Top;
            pbxLogoPesca.Location = new Point(0, 0);
            pbxLogoPesca.Margin = new Padding(2);
            pbxLogoPesca.Name = "pbxLogoPesca";
            pbxLogoPesca.Size = new Size(132, 55);
            pbxLogoPesca.SizeMode = PictureBoxSizeMode.StretchImage;
            pbxLogoPesca.TabIndex = 0;
            pbxLogoPesca.TabStop = false;
            // 
            // panelTitulo
            // 
            panelTitulo.BackColor = Color.SteelBlue;
            panelTitulo.Controls.Add(etiquetaTituloAplicacion);
            panelTitulo.Dock = DockStyle.Top;
            panelTitulo.Location = new Point(0, 0);
            panelTitulo.Margin = new Padding(1);
            panelTitulo.Name = "panelTitulo";
            panelTitulo.Size = new Size(735, 24);
            panelTitulo.TabIndex = 3;
            // 
            // etiquetaTituloAplicacion
            // 
            etiquetaTituloAplicacion.AutoSize = true;
            etiquetaTituloAplicacion.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point);
            etiquetaTituloAplicacion.ForeColor = Color.White;
            etiquetaTituloAplicacion.Location = new Point(218, 3);
            etiquetaTituloAplicacion.Margin = new Padding(2, 0, 2, 0);
            etiquetaTituloAplicacion.Name = "etiquetaTituloAplicacion";
            etiquetaTituloAplicacion.Size = new Size(244, 20);
            etiquetaTituloAplicacion.TabIndex = 0;
            etiquetaTituloAplicacion.Text = "Pesca Artesanal en Colombia";
            // 
            // panelFormularios
            // 
            panelFormularios.BackColor = Color.FromArgb(224, 224, 224);
            panelFormularios.Dock = DockStyle.Fill;
            panelFormularios.Location = new Point(0, 0);
            panelFormularios.Margin = new Padding(2);
            panelFormularios.Name = "panelFormularios";
            panelFormularios.Size = new Size(735, 390);
            panelFormularios.TabIndex = 2;
            // 
            // Principal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(735, 390);
            Controls.Add(panelContenedor);
            Margin = new Padding(2);
            Name = "Principal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Pesca Artesanal en Colombia";
            panelContenedor.ResumeLayout(false);
            panelMenu.ResumeLayout(false);
            panelCrudMunicipios.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pbxLogoPesca).EndInit();
            panelTitulo.ResumeLayout(false);
            panelTitulo.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelContenedor;
        private Panel panelMenu;
        private Panel panelTitulo;
        private Panel panelFormularios;
        private Label etiquetaTituloAplicacion;
        private PictureBox pbxLogoPesca;
        private Button btnFormasMunicipios;
        private Panel panelCrudMunicipios;
        private Button btnFormaNuevoMunicipio;
        private Button btnFormaReportesMunicipio;
        private Button btnFormaBorraMunicipio;
        private Button btnFormaActualizaMunicipio;
    }
}