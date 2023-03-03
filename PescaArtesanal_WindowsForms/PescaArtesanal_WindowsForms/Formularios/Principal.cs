namespace PescaArtesanal_WindowsForms
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
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
                panelCrudMunicipios,
                panelCrudMetodos,
                panelCrudActividades

            };

            foreach (Panel unPanel in panelesCrud)
                unPanel.Visible = false;

            Button[] botonesCrud =
            {
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
    }
}