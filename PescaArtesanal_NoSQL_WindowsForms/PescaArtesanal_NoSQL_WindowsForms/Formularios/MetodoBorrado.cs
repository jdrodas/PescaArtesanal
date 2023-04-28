using PescaArtesanal_NoSQL_WindowsForms.Modelos;

namespace PescaArtesanal_NoSQL_WindowsForms.Formularios
{
    public partial class MetodoBorrado : Form
    {
        public MetodoBorrado()
        {
            InitializeComponent();
        }

        private void btnCerrarForma_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MetodoBorrado_Load(object sender, EventArgs e)
        {
            ActualizarListaMetodos();
        }

        private void ActualizarListaMetodos()
        {
            lbxMetodos.DataSource = null;
            lbxMetodos.DataSource = AccesoDatos.ObtenerListaNombresMetodos();

            lbxMetodos.SelectedIndex = 0;
        }

        private void lbxMetodos_SelectedIndexChanged(object sender, EventArgs e)
        {
            string? nombreMetodo = lbxMetodos.SelectedItem!.ToString();
            string idMetodo = AccesoDatos.ObtenerIdMetodo(nombreMetodo!);

            txtIdMetodo.Text = idMetodo;
            txtNombreMetodo.Text = nombreMetodo;
        }

        private void btnBorrarMetodo_Click(object sender, EventArgs e)
        {
            Metodo unMetodo = new Metodo
            {
                Id = txtIdMetodo.Text,
                Nombre = txtNombreMetodo.Text
            };

            string? mensajeEliminacion;
            bool resultadoEliminacion = AccesoDatos.EliminarMetodo(unMetodo,
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
