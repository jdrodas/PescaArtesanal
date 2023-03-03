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
            panelCrudActividades = new Panel();
            btnFormaReportesActividad = new Button();
            btnFormaBorraActividad = new Button();
            btnFormaActualizaActividad = new Button();
            btnFormaNuevaActividad = new Button();
            btnFormasActividades = new Button();
            panelCrudMetodos = new Panel();
            btnFormaReportesMetodo = new Button();
            btnFormaBorraMetodo = new Button();
            btnFormaActualizaMetodo = new Button();
            btnFormaNuevoMetodo = new Button();
            btnFormasMetodos = new Button();
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
            panelCrudActividades.SuspendLayout();
            panelCrudMetodos.SuspendLayout();
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
            panelContenedor.Size = new Size(965, 506);
            panelContenedor.TabIndex = 0;
            // 
            // panelMenu
            // 
            panelMenu.AutoScroll = true;
            panelMenu.BackColor = Color.SteelBlue;
            panelMenu.Controls.Add(panelCrudActividades);
            panelMenu.Controls.Add(btnFormasActividades);
            panelMenu.Controls.Add(panelCrudMetodos);
            panelMenu.Controls.Add(btnFormasMetodos);
            panelMenu.Controls.Add(panelCrudMunicipios);
            panelMenu.Controls.Add(btnFormasMunicipios);
            panelMenu.Controls.Add(pbxLogoPesca);
            panelMenu.Dock = DockStyle.Left;
            panelMenu.Location = new Point(0, 24);
            panelMenu.Margin = new Padding(2);
            panelMenu.Name = "panelMenu";
            panelMenu.Size = new Size(175, 482);
            panelMenu.TabIndex = 1;
            // 
            // panelCrudActividades
            // 
            panelCrudActividades.Controls.Add(btnFormaReportesActividad);
            panelCrudActividades.Controls.Add(btnFormaBorraActividad);
            panelCrudActividades.Controls.Add(btnFormaActualizaActividad);
            panelCrudActividades.Controls.Add(btnFormaNuevaActividad);
            panelCrudActividades.Dock = DockStyle.Top;
            panelCrudActividades.Location = new Point(0, 360);
            panelCrudActividades.Name = "panelCrudActividades";
            panelCrudActividades.Size = new Size(175, 100);
            panelCrudActividades.TabIndex = 5;
            panelCrudActividades.Visible = false;
            // 
            // btnFormaReportesActividad
            // 
            btnFormaReportesActividad.BackColor = Color.LightGray;
            btnFormaReportesActividad.Dock = DockStyle.Top;
            btnFormaReportesActividad.FlatAppearance.BorderSize = 0;
            btnFormaReportesActividad.FlatStyle = FlatStyle.Flat;
            btnFormaReportesActividad.Location = new Point(0, 75);
            btnFormaReportesActividad.Name = "btnFormaReportesActividad";
            btnFormaReportesActividad.Padding = new Padding(10, 0, 0, 0);
            btnFormaReportesActividad.Size = new Size(175, 25);
            btnFormaReportesActividad.TabIndex = 11;
            btnFormaReportesActividad.Text = "Reportes Actividad";
            btnFormaReportesActividad.TextAlign = ContentAlignment.MiddleLeft;
            btnFormaReportesActividad.UseVisualStyleBackColor = true;
            // 
            // btnFormaBorraActividad
            // 
            btnFormaBorraActividad.BackColor = Color.LightGray;
            btnFormaBorraActividad.Dock = DockStyle.Top;
            btnFormaBorraActividad.FlatAppearance.BorderSize = 0;
            btnFormaBorraActividad.FlatStyle = FlatStyle.Flat;
            btnFormaBorraActividad.Location = new Point(0, 50);
            btnFormaBorraActividad.Name = "btnFormaBorraActividad";
            btnFormaBorraActividad.Padding = new Padding(10, 0, 0, 0);
            btnFormaBorraActividad.Size = new Size(175, 25);
            btnFormaBorraActividad.TabIndex = 10;
            btnFormaBorraActividad.Text = "Borra Actividad";
            btnFormaBorraActividad.TextAlign = ContentAlignment.MiddleLeft;
            btnFormaBorraActividad.UseVisualStyleBackColor = true;
            // 
            // btnFormaActualizaActividad
            // 
            btnFormaActualizaActividad.BackColor = Color.LightGray;
            btnFormaActualizaActividad.Dock = DockStyle.Top;
            btnFormaActualizaActividad.FlatAppearance.BorderSize = 0;
            btnFormaActualizaActividad.FlatStyle = FlatStyle.Flat;
            btnFormaActualizaActividad.Location = new Point(0, 25);
            btnFormaActualizaActividad.Name = "btnFormaActualizaActividad";
            btnFormaActualizaActividad.Padding = new Padding(10, 0, 0, 0);
            btnFormaActualizaActividad.Size = new Size(175, 25);
            btnFormaActualizaActividad.TabIndex = 9;
            btnFormaActualizaActividad.Text = "Actualiza Actividad";
            btnFormaActualizaActividad.TextAlign = ContentAlignment.MiddleLeft;
            btnFormaActualizaActividad.UseVisualStyleBackColor = true;
            // 
            // btnFormaNuevaActividad
            // 
            btnFormaNuevaActividad.BackColor = Color.LightGray;
            btnFormaNuevaActividad.Dock = DockStyle.Top;
            btnFormaNuevaActividad.FlatAppearance.BorderSize = 0;
            btnFormaNuevaActividad.FlatStyle = FlatStyle.Flat;
            btnFormaNuevaActividad.Location = new Point(0, 0);
            btnFormaNuevaActividad.Name = "btnFormaNuevaActividad";
            btnFormaNuevaActividad.Padding = new Padding(10, 0, 0, 0);
            btnFormaNuevaActividad.Size = new Size(175, 25);
            btnFormaNuevaActividad.TabIndex = 8;
            btnFormaNuevaActividad.Text = "Nueva Actividad";
            btnFormaNuevaActividad.TextAlign = ContentAlignment.MiddleLeft;
            btnFormaNuevaActividad.UseVisualStyleBackColor = true;
            // 
            // btnFormasActividades
            // 
            btnFormasActividades.BackColor = Color.Gray;
            btnFormasActividades.Dock = DockStyle.Top;
            btnFormasActividades.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnFormasActividades.ForeColor = Color.White;
            btnFormasActividades.Location = new Point(0, 325);
            btnFormasActividades.Name = "btnFormasActividades";
            btnFormasActividades.Size = new Size(175, 35);
            btnFormasActividades.TabIndex = 4;
            btnFormasActividades.Text = "Actividades de Pesca";
            btnFormasActividades.TextAlign = ContentAlignment.MiddleLeft;
            btnFormasActividades.UseVisualStyleBackColor = false;
            btnFormasActividades.Click += btnFormasActividades_Click;
            // 
            // panelCrudMetodos
            // 
            panelCrudMetodos.Controls.Add(btnFormaReportesMetodo);
            panelCrudMetodos.Controls.Add(btnFormaBorraMetodo);
            panelCrudMetodos.Controls.Add(btnFormaActualizaMetodo);
            panelCrudMetodos.Controls.Add(btnFormaNuevoMetodo);
            panelCrudMetodos.Dock = DockStyle.Top;
            panelCrudMetodos.Location = new Point(0, 225);
            panelCrudMetodos.Name = "panelCrudMetodos";
            panelCrudMetodos.Size = new Size(175, 100);
            panelCrudMetodos.TabIndex = 3;
            panelCrudMetodos.Visible = false;
            // 
            // btnFormaReportesMetodo
            // 
            btnFormaReportesMetodo.BackColor = Color.LightGray;
            btnFormaReportesMetodo.Dock = DockStyle.Top;
            btnFormaReportesMetodo.FlatAppearance.BorderSize = 0;
            btnFormaReportesMetodo.FlatStyle = FlatStyle.Flat;
            btnFormaReportesMetodo.Location = new Point(0, 75);
            btnFormaReportesMetodo.Name = "btnFormaReportesMetodo";
            btnFormaReportesMetodo.Padding = new Padding(10, 0, 0, 0);
            btnFormaReportesMetodo.Size = new Size(175, 25);
            btnFormaReportesMetodo.TabIndex = 7;
            btnFormaReportesMetodo.Text = "Reportes Método";
            btnFormaReportesMetodo.TextAlign = ContentAlignment.MiddleLeft;
            btnFormaReportesMetodo.UseVisualStyleBackColor = true;
            // 
            // btnFormaBorraMetodo
            // 
            btnFormaBorraMetodo.BackColor = Color.LightGray;
            btnFormaBorraMetodo.Dock = DockStyle.Top;
            btnFormaBorraMetodo.FlatAppearance.BorderSize = 0;
            btnFormaBorraMetodo.FlatStyle = FlatStyle.Flat;
            btnFormaBorraMetodo.Location = new Point(0, 50);
            btnFormaBorraMetodo.Name = "btnFormaBorraMetodo";
            btnFormaBorraMetodo.Padding = new Padding(10, 0, 0, 0);
            btnFormaBorraMetodo.Size = new Size(175, 25);
            btnFormaBorraMetodo.TabIndex = 6;
            btnFormaBorraMetodo.Text = "Borra Método";
            btnFormaBorraMetodo.TextAlign = ContentAlignment.MiddleLeft;
            btnFormaBorraMetodo.UseVisualStyleBackColor = true;
            // 
            // btnFormaActualizaMetodo
            // 
            btnFormaActualizaMetodo.BackColor = Color.LightGray;
            btnFormaActualizaMetodo.Dock = DockStyle.Top;
            btnFormaActualizaMetodo.FlatAppearance.BorderSize = 0;
            btnFormaActualizaMetodo.FlatStyle = FlatStyle.Flat;
            btnFormaActualizaMetodo.Location = new Point(0, 25);
            btnFormaActualizaMetodo.Name = "btnFormaActualizaMetodo";
            btnFormaActualizaMetodo.Padding = new Padding(10, 0, 0, 0);
            btnFormaActualizaMetodo.Size = new Size(175, 25);
            btnFormaActualizaMetodo.TabIndex = 5;
            btnFormaActualizaMetodo.Text = "Actualiza Método";
            btnFormaActualizaMetodo.TextAlign = ContentAlignment.MiddleLeft;
            btnFormaActualizaMetodo.UseVisualStyleBackColor = true;
            // 
            // btnFormaNuevoMetodo
            // 
            btnFormaNuevoMetodo.BackColor = Color.LightGray;
            btnFormaNuevoMetodo.Dock = DockStyle.Top;
            btnFormaNuevoMetodo.FlatAppearance.BorderSize = 0;
            btnFormaNuevoMetodo.FlatStyle = FlatStyle.Flat;
            btnFormaNuevoMetodo.Location = new Point(0, 0);
            btnFormaNuevoMetodo.Name = "btnFormaNuevoMetodo";
            btnFormaNuevoMetodo.Padding = new Padding(10, 0, 0, 0);
            btnFormaNuevoMetodo.Size = new Size(175, 25);
            btnFormaNuevoMetodo.TabIndex = 4;
            btnFormaNuevoMetodo.Text = "Nuevo Método";
            btnFormaNuevoMetodo.TextAlign = ContentAlignment.MiddleLeft;
            btnFormaNuevoMetodo.UseVisualStyleBackColor = true;
            // 
            // btnFormasMetodos
            // 
            btnFormasMetodos.BackColor = Color.Gray;
            btnFormasMetodos.Dock = DockStyle.Top;
            btnFormasMetodos.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnFormasMetodos.ForeColor = Color.White;
            btnFormasMetodos.Location = new Point(0, 190);
            btnFormasMetodos.Name = "btnFormasMetodos";
            btnFormasMetodos.Size = new Size(175, 35);
            btnFormasMetodos.TabIndex = 2;
            btnFormasMetodos.Text = "Métodos de Pesca";
            btnFormasMetodos.TextAlign = ContentAlignment.MiddleLeft;
            btnFormasMetodos.UseVisualStyleBackColor = false;
            btnFormasMetodos.Click += btnFormasMetodos_Click;
            // 
            // panelCrudMunicipios
            // 
            panelCrudMunicipios.Controls.Add(btnFormaReportesMunicipio);
            panelCrudMunicipios.Controls.Add(btnFormaBorraMunicipio);
            panelCrudMunicipios.Controls.Add(btnFormaActualizaMunicipio);
            panelCrudMunicipios.Controls.Add(btnFormaNuevoMunicipio);
            panelCrudMunicipios.Dock = DockStyle.Top;
            panelCrudMunicipios.Location = new Point(0, 90);
            panelCrudMunicipios.Name = "panelCrudMunicipios";
            panelCrudMunicipios.Size = new Size(175, 100);
            panelCrudMunicipios.TabIndex = 1;
            panelCrudMunicipios.Visible = false;
            // 
            // btnFormaReportesMunicipio
            // 
            btnFormaReportesMunicipio.BackColor = Color.LightGray;
            btnFormaReportesMunicipio.Dock = DockStyle.Top;
            btnFormaReportesMunicipio.FlatAppearance.BorderSize = 0;
            btnFormaReportesMunicipio.FlatStyle = FlatStyle.Flat;
            btnFormaReportesMunicipio.Location = new Point(0, 75);
            btnFormaReportesMunicipio.Name = "btnFormaReportesMunicipio";
            btnFormaReportesMunicipio.Padding = new Padding(10, 0, 0, 0);
            btnFormaReportesMunicipio.Size = new Size(175, 25);
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
            btnFormaBorraMunicipio.Location = new Point(0, 50);
            btnFormaBorraMunicipio.Name = "btnFormaBorraMunicipio";
            btnFormaBorraMunicipio.Padding = new Padding(10, 0, 0, 0);
            btnFormaBorraMunicipio.Size = new Size(175, 25);
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
            btnFormaActualizaMunicipio.Location = new Point(0, 25);
            btnFormaActualizaMunicipio.Name = "btnFormaActualizaMunicipio";
            btnFormaActualizaMunicipio.Padding = new Padding(10, 0, 0, 0);
            btnFormaActualizaMunicipio.Size = new Size(175, 25);
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
            btnFormaNuevoMunicipio.Size = new Size(175, 25);
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
            btnFormasMunicipios.Size = new Size(175, 35);
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
            pbxLogoPesca.Size = new Size(175, 55);
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
            panelTitulo.Size = new Size(965, 24);
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
            panelFormularios.Size = new Size(965, 506);
            panelFormularios.TabIndex = 2;
            // 
            // Principal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(965, 506);
            Controls.Add(panelContenedor);
            Margin = new Padding(2);
            Name = "Principal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Pesca Artesanal en Colombia";
            Load += Principal_Load;
            panelContenedor.ResumeLayout(false);
            panelMenu.ResumeLayout(false);
            panelCrudActividades.ResumeLayout(false);
            panelCrudMetodos.ResumeLayout(false);
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
        private Button btnFormasMetodos;
        private Panel panelCrudMetodos;
        private Button btnFormaReportesMetodo;
        private Button btnFormaBorraMetodo;
        private Button btnFormaActualizaMetodo;
        private Button btnFormaNuevoMetodo;
        private Panel panelCrudActividades;
        private Button btnFormaReportesActividad;
        private Button btnFormaBorraActividad;
        private Button btnFormaActualizaActividad;
        private Button btnFormaNuevaActividad;
        private Button btnFormasActividades;
    }
}