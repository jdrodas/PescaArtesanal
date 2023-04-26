using PescaArtesanal_NoSQL_WindowsForms.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PescaArtesanal_NoSQL_WindowsForms.Formularios
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
            ActualizarListaMetodos();
        }

        private void ActualizarListaMetodos()
        {
            lbxMetodos.DataSource = null;
            lbxMetodos.DataSource = AccesoDatos.ObtenerListaNombresMetodos();
            lbxMetodos.DisplayMember = "Nombre";

            lbxMetodos.SelectedIndex = 0;
        }

        private void lbxMetodos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbxMetodos.DataSource != null)
            {
                string nombreMetodo = lbxMetodos.SelectedItem!.ToString()!;

                //Actualizamos el dataSource del DataGridView de actividades asociadas al método
                dgvActividades.DataSource = null;
                int totalActividadesMetodo = AccesoDatos.ObtenerCantidadActividadesPorMetodo(nombreMetodo);

                if (totalActividadesMetodo == 0)
                    gbxActividades.Visible = false;
                else
                {
                    dgvActividades.DataSource = AccesoDatos.ObtenerTablaActividadesPorMetodo(nombreMetodo);
                    txtTotalActividades.Text = totalActividadesMetodo.ToString();
                    gbxActividades.Visible = true;
                }
            }
        }
    }
}
