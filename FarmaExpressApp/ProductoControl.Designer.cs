namespace FarmaExpressApp
{
    partial class ProductoControl
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            lblNombre = new Guna.UI2.WinForms.Guna2HtmlLabel();
            lblprecio = new Guna.UI2.WinForms.Guna2HtmlLabel();
            pictureBox1 = new PictureBox();
            lblCategoría = new Guna.UI2.WinForms.Guna2HtmlLabel();
            btnAgregarpedido = new Guna.UI2.WinForms.Guna2GradientButton();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // lblNombre
            // 
            lblNombre.BackColor = Color.Transparent;
            lblNombre.Font = new Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblNombre.ForeColor = Color.Teal;
            lblNombre.Location = new Point(10, 157);
            lblNombre.Margin = new Padding(3, 4, 3, 4);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(138, 23);
            lblNombre.TabIndex = 8;
            lblNombre.Text = "NombreProducto";
            lblNombre.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SingleBitPerPixelGridFit;
            // 
            // lblprecio
            // 
            lblprecio.BackColor = Color.Transparent;
            lblprecio.Font = new Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblprecio.ForeColor = Color.DarkSlateGray;
            lblprecio.Location = new Point(10, 183);
            lblprecio.Margin = new Padding(3, 4, 3, 4);
            lblprecio.Name = "lblprecio";
            lblprecio.Size = new Size(50, 23);
            lblprecio.TabIndex = 9;
            lblprecio.Text = "Precio";
            lblprecio.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SingleBitPerPixelGridFit;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = SystemColors.ControlLightLight;
            pictureBox1.Location = new Point(18, 16);
            pictureBox1.Margin = new Padding(3, 4, 3, 4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(151, 133);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 10;
            pictureBox1.TabStop = false;
            // 
            // lblCategoría
            // 
            lblCategoría.BackColor = Color.Transparent;
            lblCategoría.Font = new Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCategoría.ForeColor = Color.DarkSlateGray;
            lblCategoría.Location = new Point(10, 207);
            lblCategoría.Margin = new Padding(3, 4, 3, 4);
            lblCategoría.Name = "lblCategoría";
            lblCategoría.Size = new Size(97, 23);
            lblCategoría.TabIndex = 11;
            lblCategoría.Text = "Categoría: -";
            lblCategoría.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SingleBitPerPixelGridFit;
            // 
            // btnAgregarpedido
            // 
            btnAgregarpedido.BackColor = Color.Transparent;
            btnAgregarpedido.BorderRadius = 3;
            btnAgregarpedido.CustomizableEdges = customizableEdges1;
            btnAgregarpedido.DisabledState.BorderColor = Color.DarkGray;
            btnAgregarpedido.DisabledState.CustomBorderColor = Color.DarkGray;
            btnAgregarpedido.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnAgregarpedido.DisabledState.FillColor2 = Color.FromArgb(169, 169, 169);
            btnAgregarpedido.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnAgregarpedido.FillColor = Color.SteelBlue;
            btnAgregarpedido.FillColor2 = Color.CadetBlue;
            btnAgregarpedido.Font = new Font("Microsoft JhengHei", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAgregarpedido.ForeColor = Color.White;
            btnAgregarpedido.Location = new Point(37, 237);
            btnAgregarpedido.Margin = new Padding(3, 4, 3, 4);
            btnAgregarpedido.Name = "btnAgregarpedido";
            btnAgregarpedido.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnAgregarpedido.Size = new Size(112, 35);
            btnAgregarpedido.TabIndex = 15;
            btnAgregarpedido.Text = "Agregar";
            btnAgregarpedido.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SingleBitPerPixel;
            btnAgregarpedido.Click += btnAgregar_Click;
            // 
            // ProductoControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnAgregarpedido);
            Controls.Add(lblCategoría);
            Controls.Add(pictureBox1);
            Controls.Add(lblprecio);
            Controls.Add(lblNombre);
            Margin = new Padding(3, 4, 3, 4);
            Name = "ProductoControl";
            Size = new Size(190, 276);
            Load += ProductoControl_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2HtmlLabel lblNombre;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblprecio;
        private PictureBox pictureBox1;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblCategoría;
        private Guna.UI2.WinForms.Guna2GradientButton btnAgregarpedido;
    }
}
