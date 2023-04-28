namespace PescaArtesanal_NoSQL_WindowsForms.Formularios
{
    partial class MetodoNuevo
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
            lbxMetodos = new ListBox();
            label4 = new Label();
            txtNombreMetodo = new TextBox();
            btnGuardarMetodo = new Button();
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
            label1.Size = new Size(880, 32);
            label1.TabIndex = 0;
            label1.Text = "Registra Nuevo Método";
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
            label2.Location = new Point(236, 106);
            label2.Name = "label2";
            label2.Size = new Size(146, 21);
            label2.TabIndex = 2;
            label2.Text = "Métodos existentes:";
            // 
            // lbxMetodos
            // 
            lbxMetodos.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lbxMetodos.FormattingEnabled = true;
            lbxMetodos.ItemHeight = 21;
            lbxMetodos.Location = new Point(402, 101);
            lbxMetodos.Margin = new Padding(3, 2, 3, 2);
            lbxMetodos.Name = "lbxMetodos";
            lbxMetodos.Size = new Size(238, 109);
            lbxMetodos.TabIndex = 4;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(265, 250);
            label4.Name = "label4";
            label4.Size = new Size(117, 21);
            label4.TabIndex = 6;
            label4.Text = "Nuevo Método:";
            // 
            // txtNombreMetodo
            // 
            txtNombreMetodo.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtNombreMetodo.Location = new Point(402, 246);
            txtNombreMetodo.Margin = new Padding(3, 2, 3, 2);
            txtNombreMetodo.Name = "txtNombreMetodo";
            txtNombreMetodo.Size = new Size(238, 29);
            txtNombreMetodo.TabIndex = 7;
            // 
            // btnGuardarMetodo
            // 
            btnGuardarMetodo.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnGuardarMetodo.Location = new Point(659, 245);
            btnGuardarMetodo.Margin = new Padding(3, 2, 3, 2);
            btnGuardarMetodo.Name = "btnGuardarMetodo";
            btnGuardarMetodo.Size = new Size(133, 30);
            btnGuardarMetodo.TabIndex = 8;
            btnGuardarMetodo.Text = "Guardar";
            btnGuardarMetodo.UseVisualStyleBackColor = true;
            btnGuardarMetodo.Click += btnGuardarMetodo_Click;
            // 
            // MetodoNuevo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(880, 463);
            Controls.Add(btnGuardarMetodo);
            Controls.Add(txtNombreMetodo);
            Controls.Add(label4);
            Controls.Add(lbxMetodos);
            Controls.Add(label2);
            Controls.Add(btnCerrarForma);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            MaximumSize = new Size(880, 463);
            MinimumSize = new Size(880, 463);
            Name = "MetodoNuevo";
            Text = "Nueva Método";
            Load += MetodoNuevo_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button btnCerrarForma;
        private Label label2;
        private ListBox lbxMetodos;
        private Label label4;
        private TextBox txtNombreMetodo;
        private Button btnGuardarMetodo;
    }
}