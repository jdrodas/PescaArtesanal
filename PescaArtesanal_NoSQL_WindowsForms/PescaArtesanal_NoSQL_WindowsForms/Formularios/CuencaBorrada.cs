using PescaArtesanal_NoSQL_WindowsForms.Modelos;

namespace PescaArtesanal_NoSQL_WindowsForms.Formularios
{
    public partial class CuencaBorrada : Form
    {
        public CuencaBorrada()
        {
            InitializeComponent();
        }

        private void btnCerrarForma_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CuencaBorrada_Load(object sender, EventArgs e)
        {
            ActualizarListaCuencas();
        }

        private void ActualizarListaCuencas()
        {
            lbxCuencas.DataSource = null;
            lbxCuencas.DataSource = AccesoDatos.ObtenerListaNombresCuencas();

            lbxCuencas.SelectedIndex = 0;
        }

        private void lbxCuencas_SelectedIndexChanged(object sender, EventArgs e)
        {
            string? nombreCuenca = lbxCuencas.SelectedItem!.ToString();
            string idCuenca = AccesoDatos.ObtenerIdCuenca(nombreCuenca!);

            txtIdCuenca.Text = idCuenca;
            txtNombreCuenca.Text = nombreCuenca;
        }

        private void btnBorrarCuenca_Click(object sender, EventArgs e)
        {
            Cuenca unaCuenca = new Cuenca
            {
                Id = txtIdCuenca.Text,
                Nombre = txtNombreCuenca.Text
            };

            string? mensajeEliminacion;
            bool resultadoEliminacion = AccesoDatos.EliminarCuenca(unaCuenca,
                                        out mensajeEliminacion);

            if (resultadoEliminacion)
            {
                MessageBox.Show(mensajeEliminacion,
                    "Inserción Exitosa",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                //Si la eliminación fue exitosa, se puede cerrar el formulario
                this.Close();
            }
            else
            {
                MessageBox.Show(mensajeEliminacion,
                "Inserción Fallida",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }
    }
}
