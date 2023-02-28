using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PescaArtesanal_WindowsForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InicializaLstDepartamentos();
            InicializaLstMunicipios();
        }

        /// <summary>
        /// Inicializa la lista de los departamentos
        /// </summary>
        public void InicializaLstDepartamentos()
        {
            lstDepartamentos.DataSource = null;
            lstDepartamentos.DataSource = AccesoDatos.ObtieneListaNombreDepartamentos();
            lstDepartamentos.DisplayMember = "nombre";

            //Seleccionamos el primer departamento de la lista
            lstDepartamentos.SelectedIndex = 0;
        }

        /// <summary>
        /// Inicializa la lista de los municipios
        /// </summary>
        public void InicializaLstMunicipios()
        {
            lstMunicipios.DataSource = null;
            lstMunicipios.DataSource = AccesoDatos.ObtieneListaNombreMuincipios();
            lstMunicipios.DisplayMember = "nombre";

            //Seleccionamos el primer departamento de la lista
            lstMunicipios.SelectedIndex = 0;
        }
    }
}
