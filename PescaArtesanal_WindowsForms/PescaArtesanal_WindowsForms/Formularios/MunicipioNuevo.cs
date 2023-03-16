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
            lbxDepartamentos.DataSource = AccesoDatos.ObtenerListaNombresDepartamentos();

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
            Municipio nuevoMunicipio = new Municipio
            {
                NombreCuenca = lbxCuencas.SelectedItem!.ToString(),
                NombreDepartamento = lbxDepartamentos.SelectedItem!.ToString(),
                Nombre = txtNombreMunicipio.Text
            };

            string? mensajeInsercion;

            bool resultadoInsercion = AccesoDatos.InsertarMunicipio(nuevoMunicipio,
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
