namespace FarmaExpressApp
{
    partial class CarritoCompras
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            FLPcarrito = new FlowLayoutPanel();
            lblNombre = new Guna.UI2.WinForms.Guna2HtmlLabel();
            guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            lblTotals = new Guna.UI2.WinForms.Guna2HtmlLabel();
            btnAgregarpedido = new Guna.UI2.WinForms.Guna2GradientButton();
            SuspendLayout();
            // 
            // FLPcarrito
            // 
            FLPcarrito.BackColor = SystemColors.GradientActiveCaption;
            FLPcarrito.Location = new Point(14, 65);
            FLPcarrito.Margin = new Padding(3, 4, 3, 4);
            FLPcarrito.Name = "FLPcarrito";
            FLPcarrito.Size = new Size(353, 433);
            FLPcarrito.TabIndex = 0;
            // 
            // lblNombre
            // 
            lblNombre.BackColor = Color.Transparent;
            lblNombre.Font = new Font("Century Gothic", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblNombre.ForeColor = Color.MintCream;
            lblNombre.Location = new Point(14, 16);
            lblNombre.Margin = new Padding(3, 4, 3, 4);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(94, 34);
            lblNombre.TabIndex = 9;
            lblNombre.Text = "Pedido";
            lblNombre.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SingleBitPerPixelGridFit;
            // 
            // guna2HtmlLabel1
            // 
            guna2HtmlLabel1.BackColor = Color.Transparent;
            guna2HtmlLabel1.Font = new Font("Century Gothic", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            guna2HtmlLabel1.ForeColor = Color.DarkSlateGray;
            guna2HtmlLabel1.Location = new Point(387, 151);
            guna2HtmlLabel1.Margin = new Padding(3, 4, 3, 4);
            guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            guna2HtmlLabel1.Size = new Size(181, 34);
            guna2HtmlLabel1.TabIndex = 10;
            guna2HtmlLabel1.Text = "Total a pagar:";
            guna2HtmlLabel1.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SingleBitPerPixelGridFit;
            // 
            // lblTotals
            // 
            lblTotals.BackColor = Color.Transparent;
            lblTotals.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTotals.ForeColor = Color.DarkSlateGray;
            lblTotals.Location = new Point(409, 193);
            lblTotals.Margin = new Padding(3, 4, 3, 4);
            lblTotals.Name = "lblTotals";
            lblTotals.Size = new Size(43, 25);
            lblTotals.TabIndex = 11;
            lblTotals.Text = "C$ -";
            lblTotals.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SingleBitPerPixelGridFit;
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
            btnAgregarpedido.Location = new Point(387, 336);
            btnAgregarpedido.Margin = new Padding(3, 4, 3, 4);
            btnAgregarpedido.Name = "btnAgregarpedido";
            btnAgregarpedido.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnAgregarpedido.Size = new Size(226, 71);
            btnAgregarpedido.TabIndex = 16;
            btnAgregarpedido.Text = "¡Comprar ahora!";
            btnAgregarpedido.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SingleBitPerPixel;
            btnAgregarpedido.Click += btnAgregarpedido_Click;
            // 
            // CarritoCompras
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.fondoCarrito;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(627, 525);
            Controls.Add(btnAgregarpedido);
            Controls.Add(lblTotals);
            Controls.Add(guna2HtmlLabel1);
            Controls.Add(lblNombre);
            Controls.Add(FLPcarrito);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Margin = new Padding(3, 4, 3, 4);
            Name = "CarritoCompras";
            Text = "CarritoCompras";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FlowLayoutPanel FLPcarrito;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblNombre;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTotals;
        private Guna.UI2.WinForms.Guna2GradientButton btnAgregarpedido;
    }
}