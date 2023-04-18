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

namespace PescaArtesanal_WindowsForms.Formularios
{
    public partial class MunicipioReportes : Form
    {
        public MunicipioReportes()
        {
            InitializeComponent();
        }

        private void btnCerrarForma_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MunicipioReportes_Load(object sender, EventArgs e)
        {
            ActualizarListaDepartamentos();
        }

        private void ActualizarListaDepartamentos()
        {
            lbxDepartamentos.DataSource = null;
            lbxDepartamentos.DataSource = AccesoDatos.ObtenerListaNombresDepartamentos();
            lbxDepartamentos.DisplayMember = "Nombre";

            lbxDepartamentos.SelectedIndex = 0;
        }

        private void ActualizarListaMunicipios()
        {
            //Se hace esta actualización si hay un departamento seleccionado
            if (lbxDepartamentos.SelectedItems.Count > 0)
            {
                string nombreDepartamento = lbxDepartamentos.SelectedItem!.ToString()!;
                lbxMunicipios.DataSource = null;
                lbxMunicipios.DataSource = AccesoDatos.ObtenerListaNombresMunicipios(nombreDepartamento);
                lbxMunicipios.DisplayMember = "nombre";

                lbxMunicipios.SelectedIndex = 0;
            }
        }

        private void lbxDepartamentos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbxDepartamentos.DataSource != null)
                ActualizarListaMunicipios();
        }

        private void lbxMunicipios_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbxMunicipios.DataSource != null)
            {
                string nombreDepartamento = lbxDepartamentos.SelectedItem!.ToString()!;
                string nombreMunicipio = lbxMunicipios.SelectedItem!.ToString()!;
                int codigoMunicipio = AccesoDatos.ObtenerCodigoMunicipio(nombreMunicipio, nombreDepartamento);
                txtCodigoMunicipio.Text = codigoMunicipio.ToString();

                //Actualizamos el dataSource del DataGridView de actividades asociadas al municipio
                dgvActividades.DataSource = null;
                int totalActividadesMunicipio = AccesoDatos.ObtenerCantidadActividadesPorMunicipio(codigoMunicipio);

                if (totalActividadesMunicipio == 0)
                    gbxActividades.Visible = false;
                else
                {
                    dgvActividades.DataSource = AccesoDatos.ObtenerTablaActividadesPorMunicipio(codigoMunicipio);
                    txtTotalActividades.Text = totalActividadesMunicipio.ToString();
                    gbxActividades.Visible = true;
                }
            }
        }
    }
}
