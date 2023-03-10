using PescaArtesanal_WindowsForms.Formularios;

namespace PescaArtesanal_WindowsForms
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
        }

        private void btnFormasCuencas_Click(object sender, EventArgs e)
        {
            VisualizaPanelCrud(panelCrudCuencas, btnFormasCuencas);
        }

        private void btnFormasDepartamentos_Click(object sender, EventArgs e)
        {
            VisualizaPanelCrud(panelCrudDepartamentos, btnFormasDepartamentos);
        }

        private void btnFormasMunicipios_Click(object sender, EventArgs e)
        {
            VisualizaPanelCrud(panelCrudMunicipios, btnFormasMunicipios);
        }

        private void btnFormasMetodos_Click(object sender, EventArgs e)
        {
            VisualizaPanelCrud(panelCrudMetodos, btnFormasMetodos);
        }

        private void btnFormasActividades_Click(object sender, EventArgs e)
        {
            VisualizaPanelCrud(panelCrudActividades, btnFormasActividades);
        }

        private void AbrirFormulario<unFormulario>() where unFormulario : Form, new()
        {
            Form formulario;
            //Busca en la colecion el formulario
            formulario = panelFormularios.Controls.OfType<unFormulario>().FirstOrDefault()!;

            //si el formulario/instancia no existe
            if (formulario == null)
            {
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
            else
            {
                //si el formulario/instancia existe
                formulario.BringToFront();
            }
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

        private void Principal_Load(object sender, EventArgs e)
        {
            OcultaPanelesCrud();
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
    }
}