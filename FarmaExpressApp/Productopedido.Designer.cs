namespace FarmaExpressApp
{
    partial class Productopedido
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            lblNombre = new Guna.UI2.WinForms.Guna2HtmlLabel();
            lblprecio = new Guna.UI2.WinForms.Guna2HtmlLabel();
            lblCantidadTableta = new Guna.UI2.WinForms.Guna2HtmlLabel();
            btnEliminarproducPe = new Guna.UI2.WinForms.Guna2GradientButton();
            SuspendLayout();
            // 
            // lblNombre
            // 
            lblNombre.BackColor = Color.Transparent;
            lblNombre.Font = new Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblNombre.ForeColor = Color.Teal;
            lblNombre.Location = new Point(16, 4);
            lblNombre.Margin = new Padding(3, 4, 3, 4);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(138, 23);
            lblNombre.TabIndex = 9;
            lblNombre.Text = "NombreProducto";
            lblNombre.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SingleBitPerPixelGridFit;
            // 
            // lblprecio
            // 
            lblprecio.BackColor = Color.Transparent;
            lblprecio.Font = new Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblprecio.ForeColor = Color.DarkSlateGray;
            lblprecio.Location = new Point(16, 37);
            lblprecio.Margin = new Padding(3, 4, 3, 4);
            lblprecio.Name = "lblprecio";
            lblprecio.Size = new Size(50, 23);
            lblprecio.TabIndex = 10;
            lblprecio.Text = "Precio";
            lblprecio.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SingleBitPerPixelGridFit;
            // 
            // lblCantidadTableta
            // 
            lblCantidadTableta.BackColor = Color.Transparent;
            lblCantidadTableta.Font = new Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCantidadTableta.ForeColor = Color.DarkSlateGray;
            lblCantidadTableta.Location = new Point(120, 37);
            lblCantidadTableta.Margin = new Padding(3, 4, 3, 4);
            lblCantidadTableta.Name = "lblCantidadTableta";
            lblCantidadTableta.Size = new Size(90, 23);
            lblCantidadTableta.TabIndex = 11;
            lblCantidadTableta.Text = "cantidad: -";
            lblCantidadTableta.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SingleBitPerPixelGridFit;
            // 
            // btnEliminarproducPe
            // 
            btnEliminarproducPe.BackColor = Color.Transparent;
            btnEliminarproducPe.BorderRadius = 3;
            btnEliminarproducPe.CustomizableEdges = customizableEdges5;
            btnEliminarproducPe.DisabledState.BorderColor = Color.DarkGray;
            btnEliminarproducPe.DisabledState.CustomBorderColor = Color.DarkGray;
            btnEliminarproducPe.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnEliminarproducPe.DisabledState.FillColor2 = Color.FromArgb(169, 169, 169);
            btnEliminarproducPe.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnEliminarproducPe.FillColor = Color.Chocolate;
            btnEliminarproducPe.FillColor2 = Color.Orange;
            btnEliminarproducPe.Font = new Font("Microsoft JhengHei", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnEliminarproducPe.ForeColor = Color.White;
            btnEliminarproducPe.Location = new Point(259, 16);
            btnEliminarproducPe.Margin = new Padding(3, 4, 3, 4);
            btnEliminarproducPe.Name = "btnEliminarproducPe";
            btnEliminarproducPe.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btnEliminarproducPe.Size = new Size(43, 36);
            btnEliminarproducPe.TabIndex = 16;
            btnEliminarproducPe.Text = "X";
            btnEliminarproducPe.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SingleBitPerPixel;
            btnEliminarproducPe.Click += btnEliminar_Click;
            // 
            // Productopedido
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnEliminarproducPe);
            Controls.Add(lblCantidadTableta);
            Controls.Add(lblprecio);
            Controls.Add(lblNombre);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Productopedido";
            Size = new Size(318, 73);
            Load += Productopedido_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2HtmlLabel lblNombre;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblprecio;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblCantidadTableta;
        private Guna.UI2.WinForms.Guna2GradientButton btnEliminarproducPe;
    }
}
