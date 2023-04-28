using PescaArtesanal_NoSQL_WindowsForms.Modelos;

namespace PescaArtesanal_NoSQL_WindowsForms.Formularios
{
    public partial class DepartamentoBorrado : Form
    {
        public DepartamentoBorrado()
        {
            InitializeComponent();
        }

        private void btnCerrarForma_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DepartamentoBorrado_Load(object sender, EventArgs e)
        {
            ActualizarListaDepartamentos();
        }

        private void ActualizarListaDepartamentos()
        {
            lbxDepartamentos.DataSource = null;
            lbxDepartamentos.DataSource = AccesoDatos.ObtenerListaNombresDepartamentos();

            lbxDepartamentos.SelectedIndex = 0;
        }

        private void lbxDepartamentos_SelectedIndexChanged(object sender, EventArgs e)
        {
            string? nombreDepartamento = lbxDepartamentos.SelectedItem!.ToString();
            string idDepartamento = AccesoDatos.ObtenerIdDepartamento(nombreDepartamento!);

            txtIdDepartamento.Text = idDepartamento;
            txtNombreDepartamento.Text = nombreDepartamento;
        }

        private void btnBorrarDepartamento_Click(object sender, EventArgs e)
        {
            Departamento unDepartamento = new Departamento
            {
                Id = txtIdDepartamento.Text,
                Nombre = txtNombreDepartamento.Text
            };

            string? mensajeEliminacion;
            bool resultadoEliminacion = AccesoDatos.EliminarDepartamento(unDepartamento,
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
