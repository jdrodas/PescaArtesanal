namespace PescaArtesanal_WindowsForms.Formularios
{
    partial class MetodoReportes
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
            txtCodigoMetodo = new TextBox();
            label4 = new Label();
            label3 = new Label();
            lbxMetodosPesca = new ListBox();
            label2 = new Label();
            label5 = new Label();
            label6 = new Label();
            txtActividadesXML = new TextBox();
            txtActividadesJSON = new TextBox();
            txtActividadTextoPlano = new TextBox();
            label7 = new Label();
            txtCantidadActividades = new TextBox();
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
            label1.Size = new Size(1006, 41);
            label1.TabIndex = 0;
            label1.Text = "Actividades de Pesca por Método";
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
            // txtCodigoMetodo
            // 
            txtCodigoMetodo.BackColor = Color.White;
            txtCodigoMetodo.Enabled = false;
            txtCodigoMetodo.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtCodigoMetodo.Location = new Point(612, 205);
            txtCodigoMetodo.Margin = new Padding(1);
            txtCodigoMetodo.Name = "txtCodigoMetodo";
            txtCodigoMetodo.Size = new Size(138, 34);
            txtCodigoMetodo.TabIndex = 9;
            txtCodigoMetodo.TextAlign = HorizontalAlignment.Right;
            // 
            // label4
            // 
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(56, 297);
            label4.Margin = new Padding(2);
            label4.Name = "label4";
            label4.Size = new Size(170, 28);
            label4.TabIndex = 12;
            label4.Text = "Versión en XML:";
            label4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(252, 211);
            label3.Margin = new Padding(1, 0, 1, 0);
            label3.Name = "label3";
            label3.Size = new Size(357, 28);
            label3.TabIndex = 8;
            label3.Text = "Código Método de Pesca Seleccionado:";
            label3.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lbxMetodosPesca
            // 
            lbxMetodosPesca.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lbxMetodosPesca.FormattingEnabled = true;
            lbxMetodosPesca.ItemHeight = 28;
            lbxMetodosPesca.Location = new Point(441, 69);
            lbxMetodosPesca.Margin = new Padding(3, 4, 3, 4);
            lbxMetodosPesca.Name = "lbxMetodosPesca";
            lbxMetodosPesca.Size = new Size(309, 116);
            lbxMetodosPesca.TabIndex = 13;
            lbxMetodosPesca.SelectedIndexChanged += lbxMetodosPesca_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(246, 69);
            label2.Name = "label2";
            label2.Size = new Size(166, 28);
            label2.TabIndex = 12;
            label2.Text = "Método de Pesca:";
            // 
            // label5
            // 
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(355, 297);
            label5.Margin = new Padding(2);
            label5.Name = "label5";
            label5.Size = new Size(170, 28);
            label5.TabIndex = 14;
            label5.Text = "Versión en JSON:";
            label5.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(649, 297);
            label6.Margin = new Padding(2);
            label6.Name = "label6";
            label6.Size = new Size(230, 28);
            label6.TabIndex = 15;
            label6.Text = "Versión en Texto Plano:";
            label6.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtActividadesXML
            // 
            txtActividadesXML.Location = new Point(56, 349);
            txtActividadesXML.Multiline = true;
            txtActividadesXML.Name = "txtActividadesXML";
            txtActividadesXML.ScrollBars = ScrollBars.Both;
            txtActividadesXML.Size = new Size(257, 194);
            txtActividadesXML.TabIndex = 16;
            // 
            // txtActividadesJSON
            // 
            txtActividadesJSON.Location = new Point(355, 349);
            txtActividadesJSON.Multiline = true;
            txtActividadesJSON.Name = "txtActividadesJSON";
            txtActividadesJSON.ScrollBars = ScrollBars.Both;
            txtActividadesJSON.Size = new Size(257, 194);
            txtActividadesJSON.TabIndex = 17;
            // 
            // txtActividadTextoPlano
            // 
            txtActividadTextoPlano.Location = new Point(649, 349);
            txtActividadTextoPlano.Multiline = true;
            txtActividadTextoPlano.Name = "txtActividadTextoPlano";
            txtActividadTextoPlano.ScrollBars = ScrollBars.Both;
            txtActividadTextoPlano.Size = new Size(257, 194);
            txtActividadTextoPlano.TabIndex = 18;
            // 
            // label7
            // 
            label7.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label7.Location = new Point(56, 561);
            label7.Margin = new Padding(2);
            label7.Name = "label7";
            label7.Size = new Size(284, 28);
            label7.TabIndex = 19;
            label7.Text = "Total Actividades Encontradas:";
            label7.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtCantidadActividades
            // 
            txtCantidadActividades.BackColor = Color.White;
            txtCantidadActividades.Enabled = false;
            txtCantidadActividades.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtCantidadActividades.Location = new Point(355, 558);
            txtCantidadActividades.Margin = new Padding(1);
            txtCantidadActividades.Name = "txtCantidadActividades";
            txtCantidadActividades.Size = new Size(138, 34);
            txtCantidadActividades.TabIndex = 20;
            txtCantidadActividades.TextAlign = HorizontalAlignment.Right;
            // 
            // MetodoReportes
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1006, 617);
            Controls.Add(txtCantidadActividades);
            Controls.Add(label7);
            Controls.Add(txtActividadTextoPlano);
            Controls.Add(txtActividadesJSON);
            Controls.Add(txtActividadesXML);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(lbxMetodosPesca);
            Controls.Add(label2);
            Controls.Add(txtCodigoMetodo);
            Controls.Add(label3);
            Controls.Add(btnCerrarForma);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            MaximumSize = new Size(1006, 617);
            MinimumSize = new Size(1006, 617);
            Name = "MetodoReportes";
            Text = "Reportes Métodos de Pesca";
            Load += MetodoReportes_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button btnCerrarForma;
        private TextBox txtCodigoMetodo;
        private Label label3;
        private ListBox lbxMetodosPesca;
        private Label label2;
        private Label label4;
        private Label label5;
        private Label label6;
        private TextBox txtActividadesXML;
        private TextBox txtActividadesJSON;
        private TextBox txtActividadTextoPlano;
        private Label label7;
        private TextBox txtCantidadActividades;
    }
}