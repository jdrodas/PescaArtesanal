using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PescaArtesanal_WindowsForms.Modelos;

namespace PescaArtesanal_WindowsForms.Formularios
{
    public partial class MunicipioActualizado : Form
    {
        public MunicipioActualizado()
        {
            InitializeComponent();
        }

        private void MunicipioActualizado_Load(object sender, EventArgs e)
        {
            InicializaLbxInfoMunicipios();
        }

        private void btnCerrarForma_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void InicializaLbxInfoMunicipios()
        {

            lbxInfoMunicipios.DataSource = null;
            lbxInfoMunicipios.DataSource = AccesoDatos.ObtieneListaInfoMunicipios();
            lbxInfoMunicipios.DisplayMember = "infoMunicipio";

            //Seleccionamos el primer municipio de la lista
            lbxInfoMunicipios.SelectedIndex = 0;
        }

        private void ActualizaListaDepartamentos(string nombreDepartamento)
        {
            lbxDepartamentos.DataSource = null;
            lbxDepartamentos.DataSource = AccesoDatos.ObtieneListaNombresDepartamentos();

            //Seleccionamos el departamento que se llama igual al del municipio seleccionado
            if (string.IsNullOrEmpty(nombreDepartamento))
                lbxDepartamentos.SelectedIndex = 0;
            else
                lbxDepartamentos.SelectedIndex = lbxDepartamentos.Items.IndexOf(nombreDepartamento);

        }

        private void ActualizaListaCuencas(string nombreCuenca)
        {
            lbxCuencas.DataSource = null;
            lbxCuencas.DataSource = AccesoDatos.ObtieneNombresCuencas();

            //Seleccionamos la cuenca que se llama igual al del municipio seleccionado
            if (string.IsNullOrEmpty(nombreCuenca))
                lbxCuencas.SelectedIndex = 0;
            else
                lbxCuencas.SelectedIndex = lbxCuencas.Items.IndexOf(nombreCuenca);
        }

        private void lbxInfoMunicipios_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbxInfoMunicipios.DataSource != null)
            {
                //Obtenemos el código del municipio
                string?[] infoMunicipio = lbxInfoMunicipios.SelectedItem!.ToString()!.Split('-');
                int codigoMunicipio = int.Parse(infoMunicipio[0]!.Trim());
                txtCodigoMunicipio.Text = codigoMunicipio.ToString();

                //Leemos desde la DB, el municipio asociado al código
                Municipio unMunicipio = AccesoDatos.ObtieneMunicipio(codigoMunicipio);

                //Actualizamos las listas asignando como item seleccionado
                //el valor correspondiente de la propiedad del municipio
                ActualizaListaDepartamentos(unMunicipio.NombreDepartamento!);
                ActualizaListaCuencas(unMunicipio.NombreCuenca!);

                txtNombreMunicipio.Text = unMunicipio.Nombre;
            }
        }

        private void btnActualizaMunicipio_Click(object sender, EventArgs e)
        {
            try
            {
                string mensajeActualizacion;
                Municipio unMunicipio = new Municipio();

                unMunicipio.Codigo = int.Parse(txtCodigoMunicipio.Text);
                unMunicipio.Nombre = txtNombreMunicipio.Text;
                unMunicipio.NombreCuenca = lbxCuencas.SelectedItem!.ToString();
                unMunicipio.NombreDepartamento = lbxDepartamentos.SelectedItem!.ToString();

                bool resultadoActualizacion = AccesoDatos.ActualizaMunicipio(unMunicipio, out mensajeActualizacion);

                if (resultadoActualizacion)
                {
                    MessageBox.Show("El municipio se actualizó correctamente",
                    "Actualización exitosa",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(mensajeActualizacion,
                    "Fallo en la actualización del municipio",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }
            }
            catch (FormatException unErrorFormato)
            {
                MessageBox.Show($"Datos numéricos no tienen el formato Esperado. {unErrorFormato.Message}");
            }

            //Finalmente, actualizamos la lista de información de Municipios
            InicializaLbxInfoMunicipios();
        }
    }
}
