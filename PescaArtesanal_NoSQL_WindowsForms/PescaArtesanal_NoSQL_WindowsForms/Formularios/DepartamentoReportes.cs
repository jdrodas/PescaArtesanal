namespace PescaArtesanal_NoSQL_WindowsForms.Formularios
{
    public partial class DepartamentoReportes : Form
    {
        public DepartamentoReportes()
        {
            InitializeComponent();
        }

        private void btnCerrarForma_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DepartamentoReportes_Load(object sender, EventArgs e)
        {
            ActualizarListaDepartamentos();
        }

        private void ActualizarListaDepartamentos()
        {
            lbxDepartamentos.DataSource = null;
            lbxDepartamentos.DataSource = AccesoDatos.ObtenerListaNombresDepartamentos();
            lbxDepartamentos.DisplayMember = "Nombre";

            lbxDepartamentos.SelectedIndex = 0;
        }

        private void lbxDepartamentos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbxDepartamentos.DataSource != null)
            {
                string nombreDepartamento = lbxDepartamentos.SelectedItem!.ToString()!;

                //Actualizamos el dataSource del DataGridView de actividades asociadas al departamento
                dgvActividades.DataSource = null;
                int totalActividadesDepartamento = AccesoDatos.ObtenerCantidadActividadesPorDepartamento(nombreDepartamento);

                if (totalActividadesDepartamento == 0)
                    gbxActividades.Visible = false;
                else
                {
                    dgvActividades.DataSource = AccesoDatos.ObtenerTablaActividadesPorDepartamento(nombreDepartamento);
                    txtTotalActividades.Text = totalActividadesDepartamento.ToString();
                    gbxActividades.Visible = true;
                }
            }
        }
    }
}
