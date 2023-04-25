using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PescaArtesanal_NoSQL_WindowsForms.Modelos;

namespace PescaArtesanal_NoSQL_WindowsForms.Formularios
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
            Actividad nuevaActividad = new Actividad();
            string mensajeInsercion = string.Empty;
            bool resultadoInsercion;

            string separadorDecimal = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;

            try
            {
                nuevaActividad.NombreMetodo = lbxMetodos.SelectedItem!.ToString()!;
                nuevaActividad.NombreMunicipio = lbxMunicipios.SelectedItem!.ToString()!;
                nuevaActividad.NombreDepartamento = lbxDepartamentos.SelectedItem!.ToString();
                nuevaActividad.NombreCuenca = txtNombreCuenca.Text;
                nuevaActividad.Fecha = dtpFecha.Value;
                nuevaActividad.CantidadPescado = double.Parse(txtxCantidadPescado.Text
                                                                .Replace(",", separadorDecimal)
                                                                .Replace(".", separadorDecimal)
                                                             );

                if (nuevaActividad.CantidadPescado <= 0)
                {
                    mensajeInsercion = "La cantidad de pescado debe ser un número positivo mayor que cero.";
                    resultadoInsercion = false;
                }
                else
                {
                    resultadoInsercion = AccesoDatos.InsertarActividad(nuevaActividad,
                                        out mensajeInsercion);
                }

            }
            catch (FormatException unError)
            {
                mensajeInsercion = $"Error de conversión de formato. La cantidad de pescado debe ser un número positivo mayor que cero. {unError.Message}";
                resultadoInsercion = false;
            }

            if (resultadoInsercion)
            {
                MessageBox.Show(mensajeInsercion,
                    "Se logró guardar la nueva actividad",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                //Reiniciamos los controles de la forma
                txtxCantidadPescado.Text = string.Empty;
                dtpFecha.Value = DateTime.Now;

                lbxDepartamentos.SelectedIndex = 0;
                lbxMetodos.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show(mensajeInsercion,
                "Inserción Fallida",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }

        private void lbxMunicipios_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Aqui obtenemos el nombre de la cuenca
            if (lbxMunicipios.SelectedItems.Count > 0)
            {
                string nombreMunicipio = lbxMunicipios.SelectedItem!.ToString()!;
                string nombreDepartamento = lbxDepartamentos.SelectedItem!.ToString()!;
                txtNombreCuenca.Text = AccesoDatos.ObtenerNombreCuencaMunicipio(nombreMunicipio, nombreDepartamento);
            }
        }
    }
}
