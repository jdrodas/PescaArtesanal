using PescaArtesanal_WindowsForms.Modelos;

namespace PescaArtesanal_WindowsForms.Formularios
{
    public partial class CuencaActualizada : Form
    {
        public CuencaActualizada()
        {
            InitializeComponent();
        }

        private void btnCerrarForma_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CuencaActualizada_Load(object sender, EventArgs e)
        {
            ActualizarListaCuencas();
        }

        private void ActualizarListaCuencas()
        {
            lbxCuencas.DataSource = null;
            lbxCuencas.DataSource = AccesoDatos.ObtenerListaNombresCuencas();

            lbxCuencas.SelectedIndex = 0;
        }

        private void btnActualizarCuenca_Click(object sender, EventArgs e)
        {
            Cuenca unaCuenca = new Cuenca
            {
                Codigo = int.Parse(txtCodigoCuenca.Text),
                Nombre = txtNombreCuenca.Text
            };

            string? mensajeActualizacion;
            bool resultadoActualizacion = AccesoDatos.ActualizarCuenca(unaCuenca,
                                        out mensajeActualizacion);

            if (resultadoActualizacion)
            {
                MessageBox.Show(mensajeActualizacion,
                    "Inserción Exitosa",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                //Si la actualización fue exitosa, se puede cerrar el formulario
                this.Close();
            }
            else
            {
                MessageBox.Show(mensajeActualizacion,
                "Inserción Fallida",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }

        private void lbxCuencas_SelectedIndexChanged(object sender, EventArgs e)
        {
            string? nombreCuenca = lbxCuencas.SelectedItem!.ToString();
            int codigoCuenca = AccesoDatos.ObtenerCodigoCuenca(nombreCuenca!);

            txtCodigoCuenca.Text = codigoCuenca.ToString();
            txtNombreCuenca.Text = nombreCuenca;
        }
    }
}
