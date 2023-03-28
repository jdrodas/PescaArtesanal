using PescaArtesanal_WindowsForms.Modelos;
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
    public partial class MetodoReportes : Form
    {
        public MetodoReportes()
        {
            InitializeComponent();
        }

        private void btnCerrarForma_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MetodoReportes_Load(object sender, EventArgs e)
        {
            ActualizarListaMetodosPesca();
        }

        private void ActualizarListaMetodosPesca()
        {
            lbxMetodosPesca.DataSource = null;
            lbxMetodosPesca.DataSource = AccesoDatos.ObtenerListaNombresMetodos();
            lbxMetodosPesca.DisplayMember = "Nombre";

            lbxMetodosPesca.SelectedIndex = 0;
        }

        private void lbxMetodosPesca_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbxMetodosPesca.DataSource != null)
            {
                string nombreMetodo = lbxMetodosPesca.SelectedItem!.ToString()!;
                int codigoMetodo = AccesoDatos.ObtenerCodigoMetodo(nombreMetodo);
                txtCodigoMetodo.Text = codigoMetodo.ToString();

                int cantidadActividadesMetodo = AccesoDatos.ObtenerCantidadActividadesPorMetodo(codigoMetodo);
                txtCantidadActividades.Text = cantidadActividadesMetodo.ToString();

                if (cantidadActividadesMetodo > 0)
                {
                    txtActividadesJSON.Text = AccesoDatos.ObtenerJsonActividadesPorMetodo(codigoMetodo);
                    txtActividadesXML.Text = AccesoDatos.ObtenerXMLActividadesPorMetodo(codigoMetodo);
                    txtActividadTextoPlano.Text = AccesoDatos.ObtenerTextoPlanoActividadesPorMetodo(codigoMetodo);
                }
                else
                {
                    txtActividadesJSON.Text = string.Empty;
                    txtActividadesXML.Text = string.Empty;
                    txtActividadTextoPlano.Text = string.Empty;
                }
            }
        }
    }
}
