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
            InicializarLbxInfoMunicipios();
        }

        private void InicializarLbxInfoMunicipios()
        {

            lbxInfoMunicipios.DataSource = null;
            lbxInfoMunicipios.DataSource = AccesoDatos.ObtenerListaInformacionMunicipios();
            lbxInfoMunicipios.DisplayMember = "infoMunicipio";

            //Seleccionamos el primer municipio de la lista
            lbxInfoMunicipios.SelectedIndex = 0;
        }

        private void lbxInfoMunicipios_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbxInfoMunicipios.DataSource != null)
            {
                //Obtenemos el Id del municipio
                string?[] infoMunicipio = lbxInfoMunicipios.SelectedItem!.ToString()!.Split('-');
                string? nombreMunicipio = infoMunicipio[0]!.Trim();
                string? nombreDepartamento = infoMunicipio[1]!.Trim();

                //Leemos desde la DB, el municipio asociado al código
                Municipio unMunicipio = AccesoDatos.ObtenerMunicipio(nombreMunicipio!, nombreDepartamento!);
                txtIdMunicipio.Text = unMunicipio.Id;
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
                    string?[] infoMunicipio = lbxInfoMunicipios.SelectedItem!.ToString()!.Split('-');

                    Municipio unMunicipio = AccesoDatos.ObtenerMunicipio(txtIdMunicipio.Text);

                    bool resultadoEliminacion = AccesoDatos.EliminarMunicipio(unMunicipio, out mensajeEliminacion);

                    if (resultadoEliminacion)
                    {
                        MessageBox.Show(mensajeEliminacion,
                        "Borrado exitoso",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                        //Si la eliminación fue exitosa, se puede cerrar el formulario
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show(mensajeEliminacion,
                        "Borrado Fallido",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    }

                }
                catch (FormatException unErrorFormato)
                {
                    MessageBox.Show($"Datos numéricos no tienen el formato Esperado. {unErrorFormato.Message}");
                }
            }
        }
    }
}
