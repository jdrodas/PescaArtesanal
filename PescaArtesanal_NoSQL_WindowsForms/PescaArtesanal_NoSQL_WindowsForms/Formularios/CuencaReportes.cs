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
    public partial class CuencaReportes : Form
    {
        public CuencaReportes()
        {
            InitializeComponent();
        }

        private void btnCerrarForma_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CuencaReportes_Load(object sender, EventArgs e)
        {
            ActualizarListaCuencas();
        }

        private void ActualizarListaCuencas()
        {
            lbxCuencas.DataSource = null;
            lbxCuencas.DataSource = AccesoDatos.ObtenerListaNombresCuencas();
            lbxCuencas.DisplayMember = "Nombre";

            lbxCuencas.SelectedIndex = 0;
        }

        private void lbxCuencas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbxCuencas.DataSource != null)
            {
                string nombreCuenca = lbxCuencas.SelectedItem!.ToString()!;

                //Actualizamos el dataSource del DataGridView de actividades asociadas a la cuenca
                dgvActividades.DataSource = null;
                int totalActividadesCuenca = AccesoDatos.ObtenerCantidadActividadesPorCuenca(nombreCuenca);

                if (totalActividadesCuenca == 0)
                    gbxActividades.Visible = false;
                else
                {
                    dgvActividades.DataSource = AccesoDatos.ObtenerTablaActividadesPorCuenca(nombreCuenca);
                    txtTotalActividades.Text = totalActividadesCuenca.ToString();
                    gbxActividades.Visible = true;
                }
            }
        }
    }
}
