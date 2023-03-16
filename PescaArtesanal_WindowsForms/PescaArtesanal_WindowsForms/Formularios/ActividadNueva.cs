using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PescaArtesanal_WindowsForms.Formularios
{
    public partial class ActividadNueva : Form
    {
        public ActividadNueva()
        {
            InitializeComponent();
        }

        private void btnCerrarForma_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MunicipioNuevo_Load(object sender, EventArgs e)
        {
            ActualizaListaDepartamentos();
            ActualizaListaCuencas();
        }

        private void ActualizaListaDepartamentos()
        {
            lbxDepartamentos.DataSource = null;
            lbxDepartamentos.DataSource = AccesoDatos.ObtieneListaNombresDepartamentos();

            lbxDepartamentos.SelectedIndex = 0;
        }

        private void ActualizaListaCuencas()
        {
            lbxCuencas.DataSource = null;
            lbxCuencas.DataSource = AccesoDatos.ObtieneListaNombresCuencas();

            lbxCuencas.SelectedIndex = 0;
        }

        private void btnGuardaMunicipio_Click(object sender, EventArgs e)
        {
            
        }
    }
}
