namespace PescaArtesanal_NoSQL_WindowsForms.Formularios
{
    partial class ActividadNueva
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            btnCerrarForma = new Button();
            label2 = new Label();
            label3 = new Label();
            lbxDepartamentos = new ListBox();
            lbxMetodos = new ListBox();
            btnGuardaActividad = new Button();
            lbxMunicipios = new ListBox();
            label4 = new Label();
            label5 = new Label();
            dtpFecha = new DateTimePicker();
            txtxCantidadPescado = new TextBox();
            label6 = new Label();
            label7 = new Label();
            txtNombreCuenca = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.BackColor = Color.SteelBlue;
            label1.Dock = DockStyle.Top;
            label1.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.AliceBlue;
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(1006, 57);
            label1.TabIndex = 0;
            label1.Text = "Registra Nueva Actividad de Pesca";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnCerrarForma
            // 
            btnCerrarForma.FlatStyle = FlatStyle.Flat;
            btnCerrarForma.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnCerrarForma.Location = new Point(971, 4);
            btnCerrarForma.Margin = new Padding(3, 4, 3, 4);
            btnCerrarForma.Name = "btnCerrarForma";
            btnCerrarForma.Size = new Size(27, 32);
            btnCerrarForma.TabIndex = 1;
            btnCerrarForma.Text = "X";
            btnCerrarForma.UseVisualStyleBackColor = true;
            btnCerrarForma.Click += btnCerrarForma_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(39, 84);
            label2.Name = "label2";
            label2.Size = new Size(143, 28);
            label2.TabIndex = 2;
            label2.Text = "Departamento:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(19, 452);
            label3.Name = "label3";
            label3.Size = new Size(166, 28);
            label3.TabIndex = 3;
            label3.Text = "Método de Pesca:";
            // 
            // lbxDepartamentos
            // 
            lbxDepartamentos.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lbxDepartamentos.FormattingEnabled = true;
            lbxDepartamentos.ItemHeight = 28;
            lbxDepartamentos.Location = new Point(185, 84);
            lbxDepartamentos.Margin = new Padding(3, 4, 3, 4);
            lbxDepartamentos.Name = "lbxDepartamentos";
            lbxDepartamentos.Size = new Size(309, 116);
            lbxDepartamentos.TabIndex = 4;
            lbxDepartamentos.SelectedIndexChanged += lbxDepartamentos_SelectedIndexChanged;
            // 
            // lbxMetodos
            // 
            lbxMetodos.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lbxMetodos.FormattingEnabled = true;
            lbxMetodos.ItemHeight = 28;
            lbxMetodos.Location = new Point(185, 437);
            lbxMetodos.Margin = new Padding(3, 4, 3, 4);
            lbxMetodos.Name = "lbxMetodos";
            lbxMetodos.Size = new Size(309, 116);
            lbxMetodos.TabIndex = 5;
            // 
            // btnGuardaActividad
            // 
            btnGuardaActividad.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnGuardaActividad.Location = new Point(736, 449);
            btnGuardaActividad.Margin = new Padding(3, 4, 3, 4);
            btnGuardaActividad.Name = "btnGuardaActividad";
            btnGuardaActividad.Size = new Size(174, 53);
            btnGuardaActividad.TabIndex = 8;
            btnGuardaActividad.Text = "Guardar";
            btnGuardaActividad.UseVisualStyleBackColor = true;
            btnGuardaActividad.Click += btnGuardaActividad_Click;
            // 
            // lbxMunicipios
            // 
            lbxMunicipios.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lbxMunicipios.FormattingEnabled = true;
            lbxMunicipios.ItemHeight = 28;
            lbxMunicipios.Location = new Point(185, 233);
            lbxMunicipios.Margin = new Padding(3, 4, 3, 4);
            lbxMunicipios.Name = "lbxMunicipios";
            lbxMunicipios.Size = new Size(309, 116);
            lbxMunicipios.TabIndex = 10;
            lbxMunicipios.SelectedIndexChanged += lbxMunicipios_SelectedIndexChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(74, 233);
            label4.Name = "label4";
            label4.Size = new Size(104, 28);
            label4.TabIndex = 9;
            label4.Text = "Municipio:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(613, 89);
            label5.Name = "label5";
            label5.Size = new Size(66, 28);
            label5.TabIndex = 11;
            label5.Text = "Fecha:";
            // 
            // dtpFecha
            // 
            dtpFecha.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dtpFecha.Format = DateTimePickerFormat.Short;
            dtpFecha.Location = new Point(698, 84);
            dtpFecha.Margin = new Padding(3, 5, 3, 5);
            dtpFecha.Name = "dtpFecha";
            dtpFecha.Size = new Size(178, 34);
            dtpFecha.TabIndex = 12;
            // 
            // txtxCantidadPescado
            // 
            txtxCantidadPescado.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtxCantidadPescado.Location = new Point(728, 165);
            txtxCantidadPescado.Margin = new Padding(3, 5, 3, 5);
            txtxCantidadPescado.Name = "txtxCantidadPescado";
            txtxCantidadPescado.Size = new Size(148, 34);
            txtxCantidadPescado.TabIndex = 13;
            txtxCantidadPescado.TextAlign = HorizontalAlignment.Right;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(533, 169);
            label6.Name = "label6";
            label6.Size = new Size(171, 28);
            label6.TabIndex = 14;
            label6.Text = "Cantidad Pescado:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label7.Location = new Point(99, 368);
            label7.Name = "label7";
            label7.Size = new Size(79, 28);
            label7.TabIndex = 16;
            label7.Text = "Cuenca:";
            label7.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtNombreCuenca
            // 
            txtNombreCuenca.Enabled = false;
            txtNombreCuenca.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtNombreCuenca.Location = new Point(184, 362);
            txtNombreCuenca.Margin = new Padding(3, 5, 3, 5);
            txtNombreCuenca.Name = "txtNombreCuenca";
            txtNombreCuenca.Size = new Size(310, 34);
            txtNombreCuenca.TabIndex = 15;
            // 
            // ActividadNueva
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1006, 617);
            Controls.Add(label7);
            Controls.Add(txtNombreCuenca);
            Controls.Add(label6);
            Controls.Add(txtxCantidadPescado);
            Controls.Add(dtpFecha);
            Controls.Add(label5);
            Controls.Add(lbxMunicipios);
            Controls.Add(label4);
            Controls.Add(btnGuardaActividad);
            Controls.Add(lbxMetodos);
            Controls.Add(lbxDepartamentos);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(btnCerrarForma);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 5, 3, 5);
            MaximumSize = new Size(1006, 617);
            MinimumSize = new Size(1006, 617);
            Name = "ActividadNueva";
            Text = "Nuevo Municipio";
            Load += MunicipioNuevo_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button btnCerrarForma;
        private Label label2;
        private Label label3;
        private ListBox lbxDepartamentos;
        private ListBox lbxMetodos;
        private Button btnGuardaActividad;
        private ListBox lbxMunicipios;
        private Label label4;
        private Label label5;
        private DateTimePicker dtpFecha;
        private TextBox txtxCantidadPescado;
        private Label label6;
        private Label label7;
        private TextBox txtNombreCuenca;
    }
}