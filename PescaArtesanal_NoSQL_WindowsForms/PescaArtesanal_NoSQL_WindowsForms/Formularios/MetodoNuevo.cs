using PescaArtesanal_NoSQL_WindowsForms.Modelos;

namespace PescaArtesanal_NoSQL_WindowsForms.Formularios
{
    public partial class MetodoNuevo : Form
    {
        public MetodoNuevo()
        {
            InitializeComponent();
        }

        private void btnCerrarForma_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MetodoNuevo_Load(object sender, EventArgs e)
        {
            ActualizarListaMetodos();
        }

        private void ActualizarListaMetodos()
        {
            lbxMetodos.DataSource = null;
            lbxMetodos.DataSource = AccesoDatos.ObtenerListaNombresMetodos();

            lbxMetodos.SelectedIndex = 0;
        }

        private void btnGuardarMetodo_Click(object sender, EventArgs e)
        {
            Metodo nuevoMetodo = new Metodo
            {
                Nombre = txtNombreMetodo.Text
            };

            string? mensajeInsercion;
            bool resultadoInsercion = AccesoDatos.InsertarMetodo(nuevoMetodo,
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
