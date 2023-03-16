namespace PescaArtesanal_WindowsForms.Formularios
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
            label1.Size = new Size(880, 43);
            label1.TabIndex = 0;
            label1.Text = "Registra Nueva Actividad de Pesca";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnCerrarForma
            // 
            btnCerrarForma.FlatStyle = FlatStyle.Flat;
            btnCerrarForma.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnCerrarForma.Location = new Point(850, 3);
            btnCerrarForma.Name = "btnCerrarForma";
            btnCerrarForma.Size = new Size(24, 24);
            btnCerrarForma.TabIndex = 1;
            btnCerrarForma.Text = "X";
            btnCerrarForma.UseVisualStyleBackColor = true;
            btnCerrarForma.Click += btnCerrarForma_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(34, 63);
            label2.Name = "label2";
            label2.Size = new Size(113, 21);
            label2.TabIndex = 2;
            label2.Text = "Departamento:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(17, 300);
            label3.Name = "label3";
            label3.Size = new Size(130, 21);
            label3.TabIndex = 3;
            label3.Text = "Método de Pesca:";
            // 
            // lbxDepartamentos
            // 
            lbxDepartamentos.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lbxDepartamentos.FormattingEnabled = true;
            lbxDepartamentos.ItemHeight = 21;
            lbxDepartamentos.Location = new Point(162, 63);
            lbxDepartamentos.Name = "lbxDepartamentos";
            lbxDepartamentos.Size = new Size(271, 88);
            lbxDepartamentos.TabIndex = 4;
            lbxDepartamentos.SelectedIndexChanged += lbxDepartamentos_SelectedIndexChanged;
            // 
            // lbxMetodos
            // 
            lbxMetodos.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lbxMetodos.FormattingEnabled = true;
            lbxMetodos.ItemHeight = 21;
            lbxMetodos.Location = new Point(162, 289);
            lbxMetodos.Name = "lbxMetodos";
            lbxMetodos.Size = new Size(271, 88);
            lbxMetodos.TabIndex = 5;
            // 
            // btnGuardaActividad
            // 
            btnGuardaActividad.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnGuardaActividad.Location = new Point(644, 337);
            btnGuardaActividad.Name = "btnGuardaActividad";
            btnGuardaActividad.Size = new Size(152, 40);
            btnGuardaActividad.TabIndex = 8;
            btnGuardaActividad.Text = "Guardar";
            btnGuardaActividad.UseVisualStyleBackColor = true;
            btnGuardaActividad.Click += btnGuardaActividad_Click;
            // 
            // lbxMunicipios
            // 
            lbxMunicipios.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lbxMunicipios.FormattingEnabled = true;
            lbxMunicipios.ItemHeight = 21;
            lbxMunicipios.Location = new Point(162, 175);
            lbxMunicipios.Name = "lbxMunicipios";
            lbxMunicipios.Size = new Size(271, 88);
            lbxMunicipios.TabIndex = 10;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(65, 175);
            label4.Name = "label4";
            label4.Size = new Size(82, 21);
            label4.TabIndex = 9;
            label4.Text = "Municipio:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(495, 66);
            label5.Name = "label5";
            label5.Size = new Size(53, 21);
            label5.TabIndex = 11;
            label5.Text = "Fecha:";
            // 
            // dtpFecha
            // 
            dtpFecha.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dtpFecha.Location = new Point(563, 60);
            dtpFecha.Margin = new Padding(3, 4, 3, 4);
            dtpFecha.Name = "dtpFecha";
            dtpFecha.Size = new Size(288, 29);
            dtpFecha.TabIndex = 12;
            // 
            // txtxCantidadPescado
            // 
            txtxCantidadPescado.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtxCantidadPescado.Location = new Point(645, 127);
            txtxCantidadPescado.Margin = new Padding(3, 4, 3, 4);
            txtxCantidadPescado.Name = "txtxCantidadPescado";
            txtxCantidadPescado.Size = new Size(151, 29);
            txtxCantidadPescado.TabIndex = 13;
            txtxCantidadPescado.TextAlign = HorizontalAlignment.Right;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(495, 130);
            label6.Name = "label6";
            label6.Size = new Size(135, 21);
            label6.TabIndex = 14;
            label6.Text = "Cantidad Pescado:";
            // 
            // ActividadNueva
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(880, 463);
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
            Margin = new Padding(3, 4, 3, 4);
            MaximumSize = new Size(880, 463);
            MinimumSize = new Size(880, 463);
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
    }
}