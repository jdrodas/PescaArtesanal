using PescaArtesanal_WindowsForms.Formularios;

namespace PescaArtesanal_WindowsForms
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
        }
        private void Principal_Load(object sender, EventArgs e)
        {
            OcultaPanelesCrud();
        }

        private void AbrirFormulario<unFormulario>() where unFormulario : Form, new()
        {
            Form formulario = panelFormularios.Controls.OfType<unFormulario>().FirstOrDefault()!;

            //Si el formulario existe, se cierra
            if (formulario != null)
                formulario.Close();

            formulario = new unFormulario();
            formulario.TopLevel = false;
            formulario.FormBorderStyle = FormBorderStyle.None;
            formulario.Dock = DockStyle.Fill;
            panelFormularios.Controls.Add(formulario);
            panelFormularios.Tag = formulario;
            formulario.Show();
            formulario.BringToFront();
            formulario.FormClosed += new FormClosedEventHandler(CerrarFormulario!);
        }

        private void CerrarFormulario(object sender, FormClosedEventArgs e)
        {
            if (Application.OpenForms["MunicipioNuevo"] == null)
            {
                btnFormaNuevoMunicipio.BackColor = Color.LightGray;
                btnFormaNuevoMunicipio.ForeColor = Color.Black;
            }

            if (Application.OpenForms["MunicipioActualizado"] == null)
            {
                btnFormaActualizaMunicipio.BackColor = Color.LightGray;
                btnFormaActualizaMunicipio.ForeColor = Color.Black;
            }

            if (Application.OpenForms["MunicipioBorrado"] == null)
            {
                btnFormaBorraMunicipio.BackColor = Color.LightGray;
                btnFormaBorraMunicipio.ForeColor = Color.Black;
            }

            if (Application.OpenForms["MunicipioReportes"] == null)
            {
                btnFormaReportesMunicipio.BackColor = Color.LightGray;
                btnFormaReportesMunicipio.ForeColor = Color.Black;
            }

            if (Application.OpenForms["ActividadNueva"] == null)
            {
                btnFormaNuevaActividad.BackColor = Color.LightGray;
                btnFormaNuevaActividad.ForeColor = Color.Black;
            }
        }

        private void VisualizaPanelCrud(Panel elPanel, Button botonCrud)
        {
            if (!elPanel.Visible)
            {
                OcultaPanelesCrud();
                elPanel.Visible = true;
                botonCrud.BackColor = Color.Azure;
                botonCrud.ForeColor = Color.Black;
            }
            else
            {
                elPanel.Visible = false;
                botonCrud.BackColor = Color.Gray;
                botonCrud.ForeColor = Color.White;
            }
        }

        private void OcultaPanelesCrud()
        {
            Panel[] panelesCrud =
            {
                panelCrudCuencas,
                panelCrudDepartamentos,
                panelCrudMunicipios,
                panelCrudMetodos,
                panelCrudActividades
            };

            foreach (Panel unPanel in panelesCrud)
                unPanel.Visible = false;

            Button[] botonesCrud =
            {
                btnFormasCuencas,
                btnFormasDepartamentos,
                btnFormasMunicipios,
                btnFormasMetodos,
                btnFormasActividades
            };

            foreach (Button unBoton in botonesCrud)
            {
                unBoton.BackColor = Color.Gray;
                unBoton.ForeColor = Color.White;
            }
        }

        #region Botones Municipios

        private void btnFormasMunicipios_Click(object sender, EventArgs e)
        {
            VisualizaPanelCrud(panelCrudMunicipios, btnFormasMunicipios);
        }

        private void btnFormaNuevoMunicipio_Click(object sender, EventArgs e)
        {
            AbrirFormulario<MunicipioNuevo>();
            btnFormaNuevoMunicipio.BackColor = Color.SteelBlue;
            btnFormaNuevoMunicipio.ForeColor = Color.White;
        }

        private void btnFormaActualizaMunicipio_Click(object sender, EventArgs e)
        {
            AbrirFormulario<MunicipioActualizado>();
            btnFormaActualizaMunicipio.BackColor = Color.SteelBlue;
            btnFormaActualizaMunicipio.ForeColor = Color.White;
        }

        private void btnFormaBorraMunicipio_Click(object sender, EventArgs e)
        {
            AbrirFormulario<MunicipioBorrado>();
            btnFormaBorraMunicipio.BackColor = Color.SteelBlue;
            btnFormaBorraMunicipio.ForeColor = Color.White;
        }

        private void btnFormaReportesMunicipio_Click(object sender, EventArgs e)
        {
            AbrirFormulario<MunicipioReportes>();
            btnFormaReportesMunicipio.BackColor = Color.SteelBlue;
            btnFormaReportesMunicipio.ForeColor = Color.White;
        }

        #endregion Botones Municipios

        #region Botones Cuencas

        private void btnFormasCuencas_Click(object sender, EventArgs e)
        {
            VisualizaPanelCrud(panelCrudCuencas, btnFormasCuencas);
        }

        // TODO Implementar el formulario para insertar cuenca
        private void btnFormaNuevaCuenca_Click(object sender, EventArgs e)
        {

        }

        // TODO Implementar el formulario para actualizar cuenca
        private void btnFormaActualizaCuenca_Click(object sender, EventArgs e)
        {

        }

        // TODO Implementar el formulario para borrar cuenca
        private void btnFormaBorraCuenca_Click(object sender, EventArgs e)
        {

        }

        // TODO Implementar el formulario para generar reportes sobre cuenca
        private void btnFormaReportesCuenca_Click(object sender, EventArgs e)
        {

        }

        #endregion Botones Cuencas

        #region Botones Departamento

        private void btnFormasDepartamentos_Click(object sender, EventArgs e)
        {
            VisualizaPanelCrud(panelCrudDepartamentos, btnFormasDepartamentos);
        }

        // TODO Implementar el formulario para inserción de Departamentos
        private void btnFormaNuevoDepartamento_Click(object sender, EventArgs e)
        {

        }

        // TODO Implementar el formulario para actualizar Departamentos
        private void btnFormaActualizaDepartamento_Click(object sender, EventArgs e)
        {

        }

        // TODO Implementar el formulario para borrar Departamentos
        private void btnFormaBorraDepartamento_Click(object sender, EventArgs e)
        {

        }

        // TODO Implementar el formulario para generar reportes de Departamentos
        private void btnFormaReportesDepartamento_Click(object sender, EventArgs e)
        {

        }

        #endregion Botones Departamentos

        #region Botones Métodos

        private void btnFormasMetodos_Click(object sender, EventArgs e)
        {
            VisualizaPanelCrud(panelCrudMetodos, btnFormasMetodos);
        }

        // TODO Implementar el formulario para inserción de método de pesca
        private void btnFormaNuevoMetodo_Click(object sender, EventArgs e)
        {

        }

        // TODO Implementar el formulario para actualizar método de pesca
        private void btnFormaActualizaMetodo_Click(object sender, EventArgs e)
        {

        }

        // TODO Implementar el formulario para borrar método de pesca
        private void btnFormaBorraMetodo_Click(object sender, EventArgs e)
        {

        }

        // TODO Implementar el formulario para generar reportes de método de pesca
        private void btnFormaReportesMetodo_Click(object sender, EventArgs e)
        {

        }

        #endregion Botones Métodos

        #region Botones Actividades
        private void btnFormasActividades_Click(object sender, EventArgs e)
        {
            VisualizaPanelCrud(panelCrudActividades, btnFormasActividades);
        }

        private void btnFormaNuevaActividad_Click(object sender, EventArgs e)
        {
            AbrirFormulario<ActividadNueva>();
            btnFormaNuevaActividad.BackColor = Color.SteelBlue;
            btnFormaNuevaActividad.ForeColor = Color.White;
        }

        // TODO Implementar el formulario para actualizar actividad de pesca
        private void btnFormaActualizaActividad_Click(object sender, EventArgs e)
        {

        }

        // TODO Implementar el formulario para borrar actividad de pesca
        private void btnFormaBorraActividad_Click(object sender, EventArgs e)
        {

        }

        // TODO Implementar el formulario para generar reportes de actividad de pesca
        private void btnFormaReportesActividad_Click(object sender, EventArgs e)
        {

        }

        #endregion Botones Actividades
    }
}