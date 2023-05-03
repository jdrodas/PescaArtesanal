using PescaArtesanal_WindowsForms.Modelos;

namespace PescaArtesanal_WindowsForms.Formularios
{
    public partial class CuencaNueva : Form
    {
        public CuencaNueva()
        {
            InitializeComponent();
        }

        private void btnCerrarForma_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CuencaNueva_Load(object sender, EventArgs e)
        {
            ActualizarListaCuencas();
        }

        private void ActualizarListaCuencas()
        {
            lbxCuencas.DataSource = null;
            lbxCuencas.DataSource = AccesoDatos.ObtenerListaNombresCuencas();

            lbxCuencas.SelectedIndex = 0;
        }

        private void btnGuardarCuenca_Click(object sender, EventArgs e)
        {
            Cuenca nuevaCuenca = new Cuenca
            {
                Nombre = txtNombreCuenca.Text
            };

            string? mensajeInsercion;
            bool resultadoInsercion = AccesoDatos.InsertarCuenca(nuevaCuenca,
                                        out mensajeInsercion);

            if (resultadoInsercion)
            {
                MessageBox.Show(mensajeInsercion,
                    "Inserción Exitosa",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                //Si la inserción fue exitosa, se puede cerrar el formulario
                this.Close();
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
