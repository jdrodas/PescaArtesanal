using PescaArtesanal_NoSQL_WindowsForms.Modelos;

namespace PescaArtesanal_NoSQL_WindowsForms.Formularios
{
    public partial class MetodoActualizado : Form
    {
        public MetodoActualizado()
        {
            InitializeComponent();
        }

        private void btnCerrarForma_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MetodoActualizado_Load(object sender, EventArgs e)
        {
            ActualizarListaMetodos();
        }

        private void ActualizarListaMetodos()
        {
            lbxMetodos.DataSource = null;
            lbxMetodos.DataSource = AccesoDatos.ObtenerListaNombresMetodos();

            lbxMetodos.SelectedIndex = 0;
        }

        private void btnActualizarMetodo_Click(object sender, EventArgs e)
        {
            Metodo unMetodo = new Metodo
            {
                Id = txtIdMetodo.Text,
                Nombre = txtNombreMetodo.Text
            };

            string? mensajeActualizacion;
            bool resultadoActualizacion = AccesoDatos.ActualizarMetodo(unMetodo,
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

        private void lbxMetodos_SelectedIndexChanged(object sender, EventArgs e)
        {
            string? nombreMetodo = lbxMetodos.SelectedItem!.ToString();
            string idMetodo = AccesoDatos.ObtenerIdMetodo(nombreMetodo!);

            txtIdMetodo.Text = idMetodo;
            txtNombreMetodo.Text = nombreMetodo;
        }
    }
}
