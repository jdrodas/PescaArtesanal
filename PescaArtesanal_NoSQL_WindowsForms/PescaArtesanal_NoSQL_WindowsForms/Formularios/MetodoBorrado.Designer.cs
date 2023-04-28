namespace PescaArtesanal_NoSQL_WindowsForms.Formularios
{
    partial class MetodoBorrado
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
            txtIdMetodo = new TextBox();
            label3 = new Label();
            btnBorrarMetodo = new Button();
            txtNombreMetodo = new TextBox();
            label5 = new Label();
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
            label1.Text = "Borrar Método";
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
            label2.Location = new Point(236, 101);
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
            lbxMetodos.SelectedIndexChanged += lbxMetodos_SelectedIndexChanged;
            // 
            // txtIdMetodo
            // 
            txtIdMetodo.Enabled = false;
            txtIdMetodo.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtIdMetodo.Location = new Point(402, 237);
            txtIdMetodo.Margin = new Padding(3, 2, 3, 2);
            txtIdMetodo.Name = "txtIdMetodo";
            txtIdMetodo.Size = new Size(238, 29);
            txtIdMetodo.TabIndex = 15;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(353, 241);
            label3.Name = "label3";
            label3.Size = new Size(26, 21);
            label3.TabIndex = 14;
            label3.Text = "Id:";
            // 
            // btnBorrarMetodo
            // 
            btnBorrarMetodo.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnBorrarMetodo.Location = new Point(674, 284);
            btnBorrarMetodo.Margin = new Padding(3, 2, 3, 2);
            btnBorrarMetodo.Name = "btnBorrarMetodo";
            btnBorrarMetodo.Size = new Size(133, 30);
            btnBorrarMetodo.TabIndex = 13;
            btnBorrarMetodo.Text = "Borrar";
            btnBorrarMetodo.UseVisualStyleBackColor = true;
            btnBorrarMetodo.Click += btnBorrarMetodo_Click;
            // 
            // txtNombreMetodo
            // 
            txtNombreMetodo.Enabled = false;
            txtNombreMetodo.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtNombreMetodo.Location = new Point(402, 286);
            txtNombreMetodo.Margin = new Padding(3, 2, 3, 2);
            txtNombreMetodo.Name = "txtNombreMetodo";
            txtNombreMetodo.Size = new Size(238, 29);
            txtNombreMetodo.TabIndex = 12;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(308, 289);
            label5.Name = "label5";
            label5.Size = new Size(71, 21);
            label5.TabIndex = 11;
            label5.Text = "Nombre:";
            // 
            // MetodoBorrado
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(880, 463);
            Controls.Add(txtIdMetodo);
            Controls.Add(label3);
            Controls.Add(btnBorrarMetodo);
            Controls.Add(txtNombreMetodo);
            Controls.Add(label5);
            Controls.Add(lbxMetodos);
            Controls.Add(label2);
            Controls.Add(btnCerrarForma);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            MaximumSize = new Size(880, 463);
            MinimumSize = new Size(880, 463);
            Name = "MetodoBorrado";
            Text = "Método Borrado";
            Load += MetodoBorrado_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button btnCerrarForma;
        private Label label2;
        private ListBox lbxMetodos;
        private TextBox txtIdMetodo;
        private Label label3;
        private Button btnBorrarMetodo;
        private TextBox txtNombreMetodo;
        private Label label5;
    }
}