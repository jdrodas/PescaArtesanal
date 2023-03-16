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
    public partial class ActividadNueva : Form
    {
        public ActividadNueva()
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
            ActualizaListaMunicipios();
            ActualizaListaMetodos();

        }

        private void ActualizaListaDepartamentos()
        {
            lbxDepartamentos.DataSource = null;
            lbxDepartamentos.DataSource = AccesoDatos.ObtenerListaNombresDepartamentos();
            lbxDepartamentos.DisplayMember = "Nombre";

            lbxDepartamentos.SelectedIndex = 0;
        }

        private void ActualizaListaMetodos()
        {
            lbxMetodos.DataSource = null;
            lbxMetodos.DataSource = AccesoDatos.ObtenerListaNombresMetodos();
            lbxMetodos.DisplayMember = "nombre";

            lbxMetodos.SelectedIndex = 0;
        }

        private void ActualizaListaMunicipios()
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
            {
                string nombreDepartamento = lbxDepartamentos.SelectedItem!.ToString()!;

                lbxMunicipios.DataSource = null;
                lbxMunicipios.DataSource = AccesoDatos.ObtenerListaNombresMunicipios(nombreDepartamento);
                lbxMunicipios.DisplayMember = "nombre";

                lbxMunicipios.SelectedIndex = 0;
            }
        }

        private void btnGuardaActividad_Click(object sender, EventArgs e)
        {
            //Actividad nuevaActividad = new Actividad();

            //nuevaActividad.NombreMetodo = lbxMetodos.SelectedItem!.ToString()!;
            //nuevaActividad.NombreMunicipio = lbxMunicipios.SelectedItem!.ToString()!;
            //nuevaActividad.Fecha = dtpFecha.Value.ToShortDateString();
            //nuevaActividad.CantidadPescado = double.Parse(txtxCantidadPescado.Text);

            //string mensajeInsercion = string.Empty;

            //bool resultadoInsercion = AccesoDatos.InsertaNuevaActividad(nuevaActividad,
            //                            out mensajeInsercion);

            //if (resultadoInsercion)
            //{
            //    MessageBox.Show(mensajeInsercion,
            //        "Se logró guardar la nueva actividad",
            //        MessageBoxButtons.OK,
            //        MessageBoxIcon.Information);

            //}
            //else
            //{
            //    MessageBox.Show(mensajeInsercion,
            //    "Inserción Fallida",
            //    MessageBoxButtons.OK,
            //    MessageBoxIcon.Error);
            //}
        }
    }
}
