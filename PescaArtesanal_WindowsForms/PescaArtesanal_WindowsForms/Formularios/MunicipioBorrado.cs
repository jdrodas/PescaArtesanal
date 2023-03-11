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
    public partial class MunicipioBorrado : Form
    {
        public MunicipioBorrado()
        {
            InitializeComponent();
        }

        private void btnCerrarForma_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MunicipioBorrado_Load(object sender, EventArgs e)
        {
            InicializaLbxInfoMunicipios();
        }

        private void InicializaLbxInfoMunicipios()
        {

            lbxInfoMunicipios.DataSource = null;
            lbxInfoMunicipios.DataSource = AccesoDatos.ObtieneListaInfoMunicipios();
            lbxInfoMunicipios.DisplayMember = "infoMunicipio";

            //Seleccionamos el primer municipio de la lista
            lbxInfoMunicipios.SelectedIndex = 0;
        }

        private void lbxInfoMunicipios_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbxInfoMunicipios.DataSource != null)
            {
                //Obtenemos el código del municipio
                string?[] infoMunicipio = lbxInfoMunicipios.SelectedItem!.ToString()!.Split('-');
                int codigoMunicipio = int.Parse(infoMunicipio[0]!.Trim());
                txtCodigoMunicipio.Text = codigoMunicipio.ToString(); ;

                txtNombreMunicipio.Text = infoMunicipio[1]!.Trim();
            }
        }

        private void btnBorraMunicipio_Click(object sender, EventArgs e)
        {
            var resultadoDialogo = MessageBox.Show(
                $"Está seguro que quiere borrar el municipio {txtNombreMunicipio.Text}?",
                $"Borrar municipio {txtNombreMunicipio.Text}",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (resultadoDialogo == DialogResult.Yes)
            {
                try
                {
                    string mensajeEliminacion;
                    int codigoMunicipio = int.Parse(txtCodigoMunicipio.Text);

                    bool resultadoEliminacion = AccesoDatos.EliminaMunicipio(codigoMunicipio, out mensajeEliminacion);

                    if (resultadoEliminacion)
                    {
                        MessageBox.Show("El municipio se eliminó correctamente",
                        "Borrado exitoso",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(mensajeEliminacion,
                        "Fallo en el borrado del municipio",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    }

                }
                catch (FormatException unErrorFormato)
                {
                    MessageBox.Show($"Datos numéricos no tienen el formato Esperado. {unErrorFormato.Message}");
                }
            }


            //Finalmente, actualizamos la lista de información de Municipios
            InicializaLbxInfoMunicipios();
        }

        private void MunicipioBorrado_Paint(object sender, PaintEventArgs e)
        {
            InicializaLbxInfoMunicipios();
        }
    }
}
