using PescaArtesanal_NoSQL_WindowsForms.Modelos;

namespace PescaArtesanal_NoSQL_WindowsForms.Formularios
{
    public partial class DepartamentoActualizado : Form
    {
        public DepartamentoActualizado()
        {
            InitializeComponent();
        }

        private void btnCerrarForma_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DepartamentoActualizado_Load(object sender, EventArgs e)
        {
            ActualizarListaDepartamentos();
        }

        private void ActualizarListaDepartamentos()
        {
            lbxDepartamentos.DataSource = null;
            lbxDepartamentos.DataSource = AccesoDatos.ObtenerListaNombresDepartamentos();

            lbxDepartamentos.SelectedIndex = 0;
        }

        private void btnActualizarDepartamento_Click(object sender, EventArgs e)
        {
            Departamento unDepartamento = new Departamento
            {
                Id = txtIdDepartamento.Text,
                Nombre = txtNombreDepartamento.Text
            };

            string? mensajeActualizacion;
            bool resultadoActualizacion = AccesoDatos.ActualizarDepartamento(unDepartamento,
                                        out mensajeActualizacion);

            if (resultadoActualizacion)
            {
                MessageBox.Show(mensajeActualizacion,
                    "Inserción Exitosa",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                //Si la inserción fue exitosa, se puede cerrar el formulario
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

        private void lbxDepartamentos_SelectedIndexChanged(object sender, EventArgs e)
        {
            string? nombreDepartamento = lbxDepartamentos.SelectedItem!.ToString();
            string idDepartamento = AccesoDatos.ObtenerIdDepartamento(nombreDepartamento!);

            txtIdDepartamento.Text = idDepartamento;
            txtNombreDepartamento.Text = nombreDepartamento;
        }
    }
}
