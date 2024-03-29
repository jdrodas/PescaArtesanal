﻿using PescaArtesanal_NoSQL_WindowsForms.Modelos;

namespace PescaArtesanal_NoSQL_WindowsForms.Formularios
{
    public partial class DepartamentoNuevo : Form
    {
        public DepartamentoNuevo()
        {
            InitializeComponent();
        }

        private void btnCerrarForma_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DepartamentoNuevo_Load(object sender, EventArgs e)
        {
            ActualizarListaDepartamentos();
        }

        private void ActualizarListaDepartamentos()
        {
            lbxDepartamentos.DataSource = null;
            lbxDepartamentos.DataSource = AccesoDatos.ObtenerListaNombresDepartamentos();

            lbxDepartamentos.SelectedIndex = 0;
        }

        private void btnGuardarDepartamento_Click(object sender, EventArgs e)
        {
            Departamento nuevoDepartamento = new Departamento
            {
                Nombre = txtNombreDepartamento.Text
            };

            string? mensajeInsercion;
            bool resultadoInsercion = AccesoDatos.InsertarDepartamento(nuevoDepartamento,
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
