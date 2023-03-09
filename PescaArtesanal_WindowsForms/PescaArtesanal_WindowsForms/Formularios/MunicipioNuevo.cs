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
    public partial class MunicipioNuevo : Form
    {
        public MunicipioNuevo()
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
            lbxDepartamentos.DataSource = AccesoDatos.ObtieneNombresDepartamentos();

            lbxDepartamentos.SelectedIndex = 0;
        }

        private void ActualizaListaCuencas()
        {
            lbxCuencas.DataSource = null;
            lbxCuencas.DataSource = AccesoDatos.ObtieneNombresCuencas();

            lbxCuencas.SelectedIndex = 0;
        }

        private void btnGuardaMunicipio_Click(object sender, EventArgs e)
        {
            string? nombreCuenca = lbxCuencas.SelectedItem!.ToString();
            string? nombreDepartamento = lbxDepartamentos.SelectedItem!.ToString();
            string? nombreMunicipio = txtNombreMunicipio.Text;
            string? mensajeInsercion;

            bool resultadoInsercion = AccesoDatos.InsertaNuevoMunicipio(nombreMunicipio,
                                        nombreDepartamento!,
                                        nombreCuenca!,
                                        out mensajeInsercion);

            if (resultadoInsercion)
            {
                MessageBox.Show(mensajeInsercion,
                    "Se logró guardar el nuevo municipio",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                txtNombreMunicipio.Text = string.Empty;
            }
            else
            {
                MessageBox.Show(mensajeInsercion,
                "Inserción Fallida",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }
    }
}
