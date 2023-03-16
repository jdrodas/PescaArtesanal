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
            panelFormularios = new Panel();
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
            panelCrudDepartamentos = new Panel();
            btnFormaReportesDepartamento = new Button();
            btnFormaBorraDepartamento = new Button();
            btnFormaActualizaDepartamento = new Button();
            btnFormaNuevoDepartamento = new Button();
            btnFormasDepartamentos = new Button();
            panelCrudCuencas = new Panel();
            btnFormaReportesCuenca = new Button();
            btnFormaBorraCuenca = new Button();
            btnFormaActualizaCuenca = new Button();
            btnFormaNuevaCuenca = new Button();
            btnFormasCuencas = new Button();
            pbxLogoPesca = new PictureBox();
            panelTitulo = new Panel();
            etiquetaTituloAplicacion = new Label();
            panelContenedor.SuspendLayout();
            panelMenu.SuspendLayout();
            panelCrudActividades.SuspendLayout();
            panelCrudMetodos.SuspendLayout();
            panelCrudMunicipios.SuspendLayout();
            panelCrudDepartamentos.SuspendLayout();
            panelCrudCuencas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbxLogoPesca).BeginInit();
            panelTitulo.SuspendLayout();
            SuspendLayout();
            // 
            // panelContenedor
            // 
            panelContenedor.BackColor = Color.FromArgb(192, 192, 255);
            panelContenedor.Controls.Add(panelFormularios);
            panelContenedor.Controls.Add(panelMenu);
            panelContenedor.Controls.Add(panelTitulo);
            panelContenedor.Dock = DockStyle.Fill;
            panelContenedor.Location = new Point(0, 0);
            panelContenedor.Margin = new Padding(2, 2, 2, 2);
            panelContenedor.Name = "panelContenedor";
            panelContenedor.Size = new Size(1080, 513);
            panelContenedor.TabIndex = 0;
            // 
            // panelFormularios
            // 
            panelFormularios.BackColor = Color.FromArgb(224, 224, 224);
            panelFormularios.Dock = DockStyle.Fill;
            panelFormularios.Location = new Point(200, 50);
            panelFormularios.Margin = new Padding(2, 2, 2, 2);
            panelFormularios.MaximumSize = new Size(880, 463);
            panelFormularios.MinimumSize = new Size(880, 463);
            panelFormularios.Name = "panelFormularios";
            panelFormularios.Size = new Size(880, 463);
            panelFormularios.TabIndex = 2;
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
            panelMenu.Controls.Add(panelCrudDepartamentos);
            panelMenu.Controls.Add(btnFormasDepartamentos);
            panelMenu.Controls.Add(panelCrudCuencas);
            panelMenu.Controls.Add(btnFormasCuencas);
            panelMenu.Controls.Add(pbxLogoPesca);
            panelMenu.Dock = DockStyle.Left;
            panelMenu.Location = new Point(0, 50);
            panelMenu.Margin = new Padding(2, 2, 2, 2);
            panelMenu.Name = "panelMenu";
            panelMenu.Size = new Size(200, 463);
            panelMenu.TabIndex = 1;
            // 
            // panelCrudActividades
            // 
            panelCrudActividades.Controls.Add(btnFormaReportesActividad);
            panelCrudActividades.Controls.Add(btnFormaBorraActividad);
            panelCrudActividades.Controls.Add(btnFormaActualizaActividad);
            panelCrudActividades.Controls.Add(btnFormaNuevaActividad);
            panelCrudActividades.Dock = DockStyle.Top;
            panelCrudActividades.Location = new Point(0, 630);
            panelCrudActividades.Name = "panelCrudActividades";
            panelCrudActividades.Size = new Size(183, 100);
            panelCrudActividades.TabIndex = 5;
            panelCrudActividades.Visible = false;
            // 
            // btnFormaReportesActividad
            // 
            btnFormaReportesActividad.BackColor = Color.LightGray;
            btnFormaReportesActividad.Dock = DockStyle.Top;
            btnFormaReportesActividad.FlatAppearance.BorderSize = 0;
            btnFormaReportesActividad.FlatStyle = FlatStyle.Flat;
            btnFormaReportesActividad.ForeColor = Color.Black;
            btnFormaReportesActividad.Location = new Point(0, 75);
            btnFormaReportesActividad.Name = "btnFormaReportesActividad";
            btnFormaReportesActividad.Padding = new Padding(10, 0, 0, 0);
            btnFormaReportesActividad.Size = new Size(183, 25);
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
            btnFormaBorraActividad.ForeColor = Color.Black;
            btnFormaBorraActividad.Location = new Point(0, 50);
            btnFormaBorraActividad.Name = "btnFormaBorraActividad";
            btnFormaBorraActividad.Padding = new Padding(10, 0, 0, 0);
            btnFormaBorraActividad.Size = new Size(183, 25);
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
            btnFormaActualizaActividad.ForeColor = Color.Black;
            btnFormaActualizaActividad.Location = new Point(0, 25);
            btnFormaActualizaActividad.Name = "btnFormaActualizaActividad";
            btnFormaActualizaActividad.Padding = new Padding(10, 0, 0, 0);
            btnFormaActualizaActividad.Size = new Size(183, 25);
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
            btnFormaNuevaActividad.ForeColor = Color.Black;
            btnFormaNuevaActividad.Location = new Point(0, 0);
            btnFormaNuevaActividad.Name = "btnFormaNuevaActividad";
            btnFormaNuevaActividad.Padding = new Padding(10, 0, 0, 0);
            btnFormaNuevaActividad.Size = new Size(183, 25);
            btnFormaNuevaActividad.TabIndex = 8;
            btnFormaNuevaActividad.Text = "Nueva Actividad";
            btnFormaNuevaActividad.TextAlign = ContentAlignment.MiddleLeft;
            btnFormaNuevaActividad.UseVisualStyleBackColor = true;
            btnFormaNuevaActividad.Click += btnFormaNuevaActividad_Click;
            // 
            // btnFormasActividades
            // 
            btnFormasActividades.BackColor = Color.Gray;
            btnFormasActividades.Dock = DockStyle.Top;
            btnFormasActividades.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnFormasActividades.ForeColor = Color.White;
            btnFormasActividades.Location = new Point(0, 595);
            btnFormasActividades.Name = "btnFormasActividades";
            btnFormasActividades.Size = new Size(183, 35);
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
            panelCrudMetodos.Location = new Point(0, 495);
            panelCrudMetodos.Name = "panelCrudMetodos";
            panelCrudMetodos.Size = new Size(183, 100);
            panelCrudMetodos.TabIndex = 3;
            panelCrudMetodos.Visible = false;
            // 
            // btnFormaReportesMetodo
            // 
            btnFormaReportesMetodo.BackColor = Color.LightGray;
            btnFormaReportesMetodo.Dock = DockStyle.Top;
            btnFormaReportesMetodo.FlatAppearance.BorderSize = 0;
            btnFormaReportesMetodo.FlatStyle = FlatStyle.Flat;
            btnFormaReportesMetodo.ForeColor = Color.Black;
            btnFormaReportesMetodo.Location = new Point(0, 75);
            btnFormaReportesMetodo.Name = "btnFormaReportesMetodo";
            btnFormaReportesMetodo.Padding = new Padding(10, 0, 0, 0);
            btnFormaReportesMetodo.Size = new Size(183, 25);
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
            btnFormaBorraMetodo.ForeColor = Color.Black;
            btnFormaBorraMetodo.Location = new Point(0, 50);
            btnFormaBorraMetodo.Name = "btnFormaBorraMetodo";
            btnFormaBorraMetodo.Padding = new Padding(10, 0, 0, 0);
            btnFormaBorraMetodo.Size = new Size(183, 25);
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
            btnFormaActualizaMetodo.ForeColor = Color.Black;
            btnFormaActualizaMetodo.Location = new Point(0, 25);
            btnFormaActualizaMetodo.Name = "btnFormaActualizaMetodo";
            btnFormaActualizaMetodo.Padding = new Padding(10, 0, 0, 0);
            btnFormaActualizaMetodo.Size = new Size(183, 25);
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
            btnFormaNuevoMetodo.ForeColor = Color.Black;
            btnFormaNuevoMetodo.Location = new Point(0, 0);
            btnFormaNuevoMetodo.Name = "btnFormaNuevoMetodo";
            btnFormaNuevoMetodo.Padding = new Padding(10, 0, 0, 0);
            btnFormaNuevoMetodo.Size = new Size(183, 25);
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
            btnFormasMetodos.Location = new Point(0, 460);
            btnFormasMetodos.Name = "btnFormasMetodos";
            btnFormasMetodos.Size = new Size(183, 35);
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
            panelCrudMunicipios.Location = new Point(0, 360);
            panelCrudMunicipios.Name = "panelCrudMunicipios";
            panelCrudMunicipios.Size = new Size(183, 100);
            panelCrudMunicipios.TabIndex = 1;
            panelCrudMunicipios.Visible = false;
            // 
            // btnFormaReportesMunicipio
            // 
            btnFormaReportesMunicipio.BackColor = Color.LightGray;
            btnFormaReportesMunicipio.Dock = DockStyle.Top;
            btnFormaReportesMunicipio.FlatAppearance.BorderSize = 0;
            btnFormaReportesMunicipio.FlatStyle = FlatStyle.Flat;
            btnFormaReportesMunicipio.ForeColor = Color.Black;
            btnFormaReportesMunicipio.Location = new Point(0, 75);
            btnFormaReportesMunicipio.Name = "btnFormaReportesMunicipio";
            btnFormaReportesMunicipio.Padding = new Padding(10, 0, 0, 0);
            btnFormaReportesMunicipio.Size = new Size(183, 25);
            btnFormaReportesMunicipio.TabIndex = 3;
            btnFormaReportesMunicipio.Text = "Reportes Municipio";
            btnFormaReportesMunicipio.TextAlign = ContentAlignment.MiddleLeft;
            btnFormaReportesMunicipio.UseVisualStyleBackColor = true;
            btnFormaReportesMunicipio.Click += btnFormaReportesMunicipio_Click;
            // 
            // btnFormaBorraMunicipio
            // 
            btnFormaBorraMunicipio.BackColor = Color.LightGray;
            btnFormaBorraMunicipio.Dock = DockStyle.Top;
            btnFormaBorraMunicipio.FlatAppearance.BorderSize = 0;
            btnFormaBorraMunicipio.FlatStyle = FlatStyle.Flat;
            btnFormaBorraMunicipio.ForeColor = Color.Black;
            btnFormaBorraMunicipio.Location = new Point(0, 50);
            btnFormaBorraMunicipio.Name = "btnFormaBorraMunicipio";
            btnFormaBorraMunicipio.Padding = new Padding(10, 0, 0, 0);
            btnFormaBorraMunicipio.Size = new Size(183, 25);
            btnFormaBorraMunicipio.TabIndex = 2;
            btnFormaBorraMunicipio.Text = "Borra Municipio";
            btnFormaBorraMunicipio.TextAlign = ContentAlignment.MiddleLeft;
            btnFormaBorraMunicipio.UseVisualStyleBackColor = true;
            btnFormaBorraMunicipio.Click += btnFormaBorraMunicipio_Click;
            // 
            // btnFormaActualizaMunicipio
            // 
            btnFormaActualizaMunicipio.BackColor = Color.LightGray;
            btnFormaActualizaMunicipio.Dock = DockStyle.Top;
            btnFormaActualizaMunicipio.FlatAppearance.BorderSize = 0;
            btnFormaActualizaMunicipio.FlatStyle = FlatStyle.Flat;
            btnFormaActualizaMunicipio.ForeColor = Color.Black;
            btnFormaActualizaMunicipio.Location = new Point(0, 25);
            btnFormaActualizaMunicipio.Name = "btnFormaActualizaMunicipio";
            btnFormaActualizaMunicipio.Padding = new Padding(10, 0, 0, 0);
            btnFormaActualizaMunicipio.Size = new Size(183, 25);
            btnFormaActualizaMunicipio.TabIndex = 1;
            btnFormaActualizaMunicipio.Text = "Actualiza Municipio";
            btnFormaActualizaMunicipio.TextAlign = ContentAlignment.MiddleLeft;
            btnFormaActualizaMunicipio.UseVisualStyleBackColor = true;
            btnFormaActualizaMunicipio.Click += btnFormaActualizaMunicipio_Click;
            // 
            // btnFormaNuevoMunicipio
            // 
            btnFormaNuevoMunicipio.BackColor = Color.LightGray;
            btnFormaNuevoMunicipio.Dock = DockStyle.Top;
            btnFormaNuevoMunicipio.FlatAppearance.BorderSize = 0;
            btnFormaNuevoMunicipio.FlatStyle = FlatStyle.Flat;
            btnFormaNuevoMunicipio.ForeColor = Color.Black;
            btnFormaNuevoMunicipio.Location = new Point(0, 0);
            btnFormaNuevoMunicipio.Name = "btnFormaNuevoMunicipio";
            btnFormaNuevoMunicipio.Padding = new Padding(10, 0, 0, 0);
            btnFormaNuevoMunicipio.Size = new Size(183, 25);
            btnFormaNuevoMunicipio.TabIndex = 0;
            btnFormaNuevoMunicipio.Text = "Nuevo Municipio";
            btnFormaNuevoMunicipio.TextAlign = ContentAlignment.MiddleLeft;
            btnFormaNuevoMunicipio.UseVisualStyleBackColor = true;
            btnFormaNuevoMunicipio.Click += btnFormaNuevoMunicipio_Click;
            // 
            // btnFormasMunicipios
            // 
            btnFormasMunicipios.BackColor = Color.Gray;
            btnFormasMunicipios.Dock = DockStyle.Top;
            btnFormasMunicipios.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnFormasMunicipios.ForeColor = Color.White;
            btnFormasMunicipios.Location = new Point(0, 325);
            btnFormasMunicipios.Name = "btnFormasMunicipios";
            btnFormasMunicipios.Size = new Size(183, 35);
            btnFormasMunicipios.TabIndex = 0;
            btnFormasMunicipios.Text = "Municipios";
            btnFormasMunicipios.TextAlign = ContentAlignment.MiddleLeft;
            btnFormasMunicipios.UseVisualStyleBackColor = false;
            btnFormasMunicipios.Click += btnFormasMunicipios_Click;
            // 
            // panelCrudDepartamentos
            // 
            panelCrudDepartamentos.Controls.Add(btnFormaReportesDepartamento);
            panelCrudDepartamentos.Controls.Add(btnFormaBorraDepartamento);
            panelCrudDepartamentos.Controls.Add(btnFormaActualizaDepartamento);
            panelCrudDepartamentos.Controls.Add(btnFormaNuevoDepartamento);
            panelCrudDepartamentos.Dock = DockStyle.Top;
            panelCrudDepartamentos.Location = new Point(0, 225);
            panelCrudDepartamentos.Name = "panelCrudDepartamentos";
            panelCrudDepartamentos.Size = new Size(183, 100);
            panelCrudDepartamentos.TabIndex = 6;
            panelCrudDepartamentos.Visible = false;
            // 
            // btnFormaReportesDepartamento
            // 
            btnFormaReportesDepartamento.BackColor = Color.LightGray;
            btnFormaReportesDepartamento.Dock = DockStyle.Top;
            btnFormaReportesDepartamento.FlatAppearance.BorderSize = 0;
            btnFormaReportesDepartamento.FlatStyle = FlatStyle.Flat;
            btnFormaReportesDepartamento.ForeColor = Color.Black;
            btnFormaReportesDepartamento.Location = new Point(0, 75);
            btnFormaReportesDepartamento.Name = "btnFormaReportesDepartamento";
            btnFormaReportesDepartamento.Padding = new Padding(10, 0, 0, 0);
            btnFormaReportesDepartamento.Size = new Size(183, 25);
            btnFormaReportesDepartamento.TabIndex = 7;
            btnFormaReportesDepartamento.Text = "Reportes Departamento";
            btnFormaReportesDepartamento.TextAlign = ContentAlignment.MiddleLeft;
            btnFormaReportesDepartamento.UseVisualStyleBackColor = true;
            // 
            // btnFormaBorraDepartamento
            // 
            btnFormaBorraDepartamento.BackColor = Color.LightGray;
            btnFormaBorraDepartamento.Dock = DockStyle.Top;
            btnFormaBorraDepartamento.FlatAppearance.BorderSize = 0;
            btnFormaBorraDepartamento.FlatStyle = FlatStyle.Flat;
            btnFormaBorraDepartamento.ForeColor = Color.Black;
            btnFormaBorraDepartamento.Location = new Point(0, 50);
            btnFormaBorraDepartamento.Name = "btnFormaBorraDepartamento";
            btnFormaBorraDepartamento.Padding = new Padding(10, 0, 0, 0);
            btnFormaBorraDepartamento.Size = new Size(183, 25);
            btnFormaBorraDepartamento.TabIndex = 6;
            btnFormaBorraDepartamento.Text = "Borra Departamento";
            btnFormaBorraDepartamento.TextAlign = ContentAlignment.MiddleLeft;
            btnFormaBorraDepartamento.UseVisualStyleBackColor = true;
            // 
            // btnFormaActualizaDepartamento
            // 
            btnFormaActualizaDepartamento.BackColor = Color.LightGray;
            btnFormaActualizaDepartamento.Dock = DockStyle.Top;
            btnFormaActualizaDepartamento.FlatAppearance.BorderSize = 0;
            btnFormaActualizaDepartamento.FlatStyle = FlatStyle.Flat;
            btnFormaActualizaDepartamento.ForeColor = Color.Black;
            btnFormaActualizaDepartamento.Location = new Point(0, 25);
            btnFormaActualizaDepartamento.Name = "btnFormaActualizaDepartamento";
            btnFormaActualizaDepartamento.Padding = new Padding(10, 0, 0, 0);
            btnFormaActualizaDepartamento.Size = new Size(183, 25);
            btnFormaActualizaDepartamento.TabIndex = 5;
            btnFormaActualizaDepartamento.Text = "Actualiza Departamento";
            btnFormaActualizaDepartamento.TextAlign = ContentAlignment.MiddleLeft;
            btnFormaActualizaDepartamento.UseVisualStyleBackColor = true;
            // 
            // btnFormaNuevoDepartamento
            // 
            btnFormaNuevoDepartamento.BackColor = Color.LightGray;
            btnFormaNuevoDepartamento.Dock = DockStyle.Top;
            btnFormaNuevoDepartamento.FlatAppearance.BorderSize = 0;
            btnFormaNuevoDepartamento.FlatStyle = FlatStyle.Flat;
            btnFormaNuevoDepartamento.ForeColor = Color.Black;
            btnFormaNuevoDepartamento.Location = new Point(0, 0);
            btnFormaNuevoDepartamento.Name = "btnFormaNuevoDepartamento";
            btnFormaNuevoDepartamento.Padding = new Padding(10, 0, 0, 0);
            btnFormaNuevoDepartamento.Size = new Size(183, 25);
            btnFormaNuevoDepartamento.TabIndex = 4;
            btnFormaNuevoDepartamento.Text = "Nuevo Departamento";
            btnFormaNuevoDepartamento.TextAlign = ContentAlignment.MiddleLeft;
            btnFormaNuevoDepartamento.UseVisualStyleBackColor = true;
            // 
            // btnFormasDepartamentos
            // 
            btnFormasDepartamentos.BackColor = Color.Gray;
            btnFormasDepartamentos.Dock = DockStyle.Top;
            btnFormasDepartamentos.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnFormasDepartamentos.ForeColor = Color.White;
            btnFormasDepartamentos.Location = new Point(0, 190);
            btnFormasDepartamentos.Name = "btnFormasDepartamentos";
            btnFormasDepartamentos.Size = new Size(183, 35);
            btnFormasDepartamentos.TabIndex = 2;
            btnFormasDepartamentos.Text = "Departamentos";
            btnFormasDepartamentos.TextAlign = ContentAlignment.MiddleLeft;
            btnFormasDepartamentos.UseVisualStyleBackColor = false;
            btnFormasDepartamentos.Click += btnFormasDepartamentos_Click;
            // 
            // panelCrudCuencas
            // 
            panelCrudCuencas.Controls.Add(btnFormaReportesCuenca);
            panelCrudCuencas.Controls.Add(btnFormaBorraCuenca);
            panelCrudCuencas.Controls.Add(btnFormaActualizaCuenca);
            panelCrudCuencas.Controls.Add(btnFormaNuevaCuenca);
            panelCrudCuencas.Dock = DockStyle.Top;
            panelCrudCuencas.Location = new Point(0, 90);
            panelCrudCuencas.Name = "panelCrudCuencas";
            panelCrudCuencas.Size = new Size(183, 100);
            panelCrudCuencas.TabIndex = 1;
            panelCrudCuencas.Visible = false;
            // 
            // btnFormaReportesCuenca
            // 
            btnFormaReportesCuenca.BackColor = Color.LightGray;
            btnFormaReportesCuenca.Dock = DockStyle.Top;
            btnFormaReportesCuenca.FlatAppearance.BorderSize = 0;
            btnFormaReportesCuenca.FlatStyle = FlatStyle.Flat;
            btnFormaReportesCuenca.ForeColor = Color.Black;
            btnFormaReportesCuenca.Location = new Point(0, 75);
            btnFormaReportesCuenca.Name = "btnFormaReportesCuenca";
            btnFormaReportesCuenca.Padding = new Padding(10, 0, 0, 0);
            btnFormaReportesCuenca.Size = new Size(183, 25);
            btnFormaReportesCuenca.TabIndex = 11;
            btnFormaReportesCuenca.Text = "Reportes Cuenca";
            btnFormaReportesCuenca.TextAlign = ContentAlignment.MiddleLeft;
            btnFormaReportesCuenca.UseVisualStyleBackColor = true;
            // 
            // btnFormaBorraCuenca
            // 
            btnFormaBorraCuenca.BackColor = Color.LightGray;
            btnFormaBorraCuenca.Dock = DockStyle.Top;
            btnFormaBorraCuenca.FlatAppearance.BorderSize = 0;
            btnFormaBorraCuenca.FlatStyle = FlatStyle.Flat;
            btnFormaBorraCuenca.ForeColor = Color.Black;
            btnFormaBorraCuenca.Location = new Point(0, 50);
            btnFormaBorraCuenca.Name = "btnFormaBorraCuenca";
            btnFormaBorraCuenca.Padding = new Padding(10, 0, 0, 0);
            btnFormaBorraCuenca.Size = new Size(183, 25);
            btnFormaBorraCuenca.TabIndex = 10;
            btnFormaBorraCuenca.Text = "Borra Cuenca";
            btnFormaBorraCuenca.TextAlign = ContentAlignment.MiddleLeft;
            btnFormaBorraCuenca.UseVisualStyleBackColor = true;
            // 
            // btnFormaActualizaCuenca
            // 
            btnFormaActualizaCuenca.BackColor = Color.LightGray;
            btnFormaActualizaCuenca.Dock = DockStyle.Top;
            btnFormaActualizaCuenca.FlatAppearance.BorderSize = 0;
            btnFormaActualizaCuenca.FlatStyle = FlatStyle.Flat;
            btnFormaActualizaCuenca.ForeColor = Color.Black;
            btnFormaActualizaCuenca.Location = new Point(0, 25);
            btnFormaActualizaCuenca.Name = "btnFormaActualizaCuenca";
            btnFormaActualizaCuenca.Padding = new Padding(10, 0, 0, 0);
            btnFormaActualizaCuenca.Size = new Size(183, 25);
            btnFormaActualizaCuenca.TabIndex = 9;
            btnFormaActualizaCuenca.Text = "Actualiza Cuenca";
            btnFormaActualizaCuenca.TextAlign = ContentAlignment.MiddleLeft;
            btnFormaActualizaCuenca.UseVisualStyleBackColor = true;
            // 
            // btnFormaNuevaCuenca
            // 
            btnFormaNuevaCuenca.BackColor = Color.LightGray;
            btnFormaNuevaCuenca.Dock = DockStyle.Top;
            btnFormaNuevaCuenca.FlatAppearance.BorderSize = 0;
            btnFormaNuevaCuenca.FlatStyle = FlatStyle.Flat;
            btnFormaNuevaCuenca.ForeColor = Color.Black;
            btnFormaNuevaCuenca.Location = new Point(0, 0);
            btnFormaNuevaCuenca.Name = "btnFormaNuevaCuenca";
            btnFormaNuevaCuenca.Padding = new Padding(10, 0, 0, 0);
            btnFormaNuevaCuenca.Size = new Size(183, 25);
            btnFormaNuevaCuenca.TabIndex = 8;
            btnFormaNuevaCuenca.Text = "Nueva Cuenca";
            btnFormaNuevaCuenca.TextAlign = ContentAlignment.MiddleLeft;
            btnFormaNuevaCuenca.UseVisualStyleBackColor = true;
            // 
            // btnFormasCuencas
            // 
            btnFormasCuencas.BackColor = Color.Gray;
            btnFormasCuencas.Dock = DockStyle.Top;
            btnFormasCuencas.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnFormasCuencas.ForeColor = Color.White;
            btnFormasCuencas.Location = new Point(0, 55);
            btnFormasCuencas.Name = "btnFormasCuencas";
            btnFormasCuencas.Size = new Size(183, 35);
            btnFormasCuencas.TabIndex = 0;
            btnFormasCuencas.Text = "Cuencas";
            btnFormasCuencas.TextAlign = ContentAlignment.MiddleLeft;
            btnFormasCuencas.UseVisualStyleBackColor = false;
            btnFormasCuencas.Click += btnFormasCuencas_Click;
            // 
            // pbxLogoPesca
            // 
            pbxLogoPesca.BackColor = Color.FromArgb(255, 255, 192);
            pbxLogoPesca.Dock = DockStyle.Top;
            pbxLogoPesca.Location = new Point(0, 0);
            pbxLogoPesca.Margin = new Padding(2, 2, 2, 2);
            pbxLogoPesca.Name = "pbxLogoPesca";
            pbxLogoPesca.Size = new Size(183, 55);
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
            panelTitulo.Size = new Size(1080, 50);
            panelTitulo.TabIndex = 3;
            // 
            // etiquetaTituloAplicacion
            // 
            etiquetaTituloAplicacion.Dock = DockStyle.Top;
            etiquetaTituloAplicacion.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point);
            etiquetaTituloAplicacion.ForeColor = Color.White;
            etiquetaTituloAplicacion.Location = new Point(0, 0);
            etiquetaTituloAplicacion.Margin = new Padding(2, 0, 2, 0);
            etiquetaTituloAplicacion.Name = "etiquetaTituloAplicacion";
            etiquetaTituloAplicacion.Size = new Size(1080, 50);
            etiquetaTituloAplicacion.TabIndex = 0;
            etiquetaTituloAplicacion.Text = "Pesca Artesanal en Colombia";
            etiquetaTituloAplicacion.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Principal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1080, 513);
            Controls.Add(panelContenedor);
            Margin = new Padding(2, 2, 2, 2);
            MaximumSize = new Size(1096, 552);
            MinimumSize = new Size(1096, 552);
            Name = "Principal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Pesca Artesanal en Colombia";
            Load += Principal_Load;
            panelContenedor.ResumeLayout(false);
            panelMenu.ResumeLayout(false);
            panelCrudActividades.ResumeLayout(false);
            panelCrudMetodos.ResumeLayout(false);
            panelCrudMunicipios.ResumeLayout(false);
            panelCrudDepartamentos.ResumeLayout(false);
            panelCrudCuencas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pbxLogoPesca).EndInit();
            panelTitulo.ResumeLayout(false);
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
        private Button btnFormasDepartamentos;
        private Panel panelCrudDepartamentos;
        private Button btnFormaReportesDepartamento;
        private Button btnFormaBorraDepartamento;
        private Button btnFormaActualizaDepartamento;
        private Button btnFormaNuevoDepartamento;
        private Panel panelCrudCuencas;
        private Button btnFormasCuencas;
        private Button btnFormaReportesCuenca;
        private Button btnFormaBorraCuenca;
        private Button btnFormaActualizaCuenca;
        private Button btnFormaNuevaCuenca;
    }
}