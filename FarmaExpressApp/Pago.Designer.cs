namespace FarmaExpressApp
{
    partial class Pago
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            lblTotal = new Label();
            label6 = new Label();
            label5 = new Label();
            btnPagar = new Guna.UI2.WinForms.Guna2GradientButton();
            numTarjeta = new Guna.UI2.WinForms.Guna2TextBox();
            cvv = new Guna.UI2.WinForms.Guna2TextBox();
            mm = new Guna.UI2.WinForms.Guna2TextBox();
            yy = new Guna.UI2.WinForms.Guna2TextBox();
            nombre = new Guna.UI2.WinForms.Guna2TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial Rounded MT Bold", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(99, 36);
            label1.Name = "label1";
            label1.Size = new Size(123, 20);
            label1.TabIndex = 45;
            label1.Text = "Realizar pago";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.ForeColor = SystemColors.ActiveCaptionText;
            label2.Location = new Point(147, 114);
            label2.Name = "label2";
            label2.Size = new Size(147, 20);
            label2.TabIndex = 46;
            label2.Text = "Número de la tarjeta";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.ForeColor = SystemColors.ActiveCaptionText;
            label3.Location = new Point(147, 207);
            label3.Name = "label3";
            label3.Size = new Size(36, 20);
            label3.TabIndex = 48;
            label3.Text = "CVV";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.ForeColor = SystemColors.ActiveCaptionText;
            label4.Location = new Point(379, 208);
            label4.Name = "label4";
            label4.Size = new Size(141, 20);
            label4.TabIndex = 50;
            label4.Text = "Fecha de expiración";
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Font = new Font("Arial", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotal.Location = new Point(512, 406);
            lblTotal.Name = "lblTotal";
            lblTotal.RightToLeft = RightToLeft.No;
            lblTotal.Size = new Size(0, 19);
            lblTotal.TabIndex = 56;
            lblTotal.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.ForeColor = SystemColors.ActiveCaptionText;
            label6.Location = new Point(147, 303);
            label6.Name = "label6";
            label6.Size = new Size(148, 20);
            label6.TabIndex = 53;
            label6.Text = "Nombre de la tarjeta";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(99, 405);
            label5.Name = "label5";
            label5.Size = new Size(103, 20);
            label5.TabIndex = 55;
            label5.Text = "Total a pagar:";
            // 
            // btnPagar
            // 
            btnPagar.BackColor = Color.Transparent;
            btnPagar.BorderRadius = 3;
            btnPagar.CustomizableEdges = customizableEdges1;
            btnPagar.DisabledState.BorderColor = Color.DarkGray;
            btnPagar.DisabledState.CustomBorderColor = Color.DarkGray;
            btnPagar.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnPagar.DisabledState.FillColor2 = Color.FromArgb(169, 169, 169);
            btnPagar.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnPagar.FillColor = Color.SteelBlue;
            btnPagar.FillColor2 = Color.CadetBlue;
            btnPagar.Font = new Font("Microsoft JhengHei", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnPagar.ForeColor = Color.White;
            btnPagar.Location = new Point(267, 457);
            btnPagar.Margin = new Padding(3, 4, 3, 4);
            btnPagar.Name = "btnPagar";
            btnPagar.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnPagar.Size = new Size(128, 37);
            btnPagar.TabIndex = 57;
            btnPagar.Text = "Pagar";
            btnPagar.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SingleBitPerPixel;
            btnPagar.Click += btnPagar_Click;
            // 
            // numTarjeta
            // 
            numTarjeta.AccessibleDescription = "Nombre";
            numTarjeta.Animated = true;
            numTarjeta.BackColor = Color.Transparent;
            numTarjeta.BorderColor = Color.Teal;
            numTarjeta.BorderRadius = 6;
            numTarjeta.BorderThickness = 2;
            numTarjeta.CustomizableEdges = customizableEdges3;
            numTarjeta.DefaultText = "";
            numTarjeta.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            numTarjeta.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            numTarjeta.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            numTarjeta.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            numTarjeta.FillColor = Color.GhostWhite;
            numTarjeta.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            numTarjeta.Font = new Font("Microsoft JhengHei", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            numTarjeta.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            numTarjeta.Location = new Point(147, 139);
            numTarjeta.Margin = new Padding(3, 5, 3, 5);
            numTarjeta.MaxLength = 16;
            numTarjeta.Name = "numTarjeta";
            numTarjeta.PlaceholderForeColor = SystemColors.ActiveCaption;
            numTarjeta.PlaceholderText = "0000-0000-0000-0000";
            numTarjeta.SelectedText = "";
            numTarjeta.ShadowDecoration.CustomizableEdges = customizableEdges4;
            numTarjeta.Size = new Size(301, 41);
            numTarjeta.TabIndex = 58;
            numTarjeta.KeyPress += numTarjeta_KeyPress;
            // 
            // cvv
            // 
            cvv.AccessibleDescription = "Nombre";
            cvv.Animated = true;
            cvv.BackColor = Color.Transparent;
            cvv.BorderColor = Color.Teal;
            cvv.BorderRadius = 6;
            cvv.BorderThickness = 2;
            cvv.CustomizableEdges = customizableEdges5;
            cvv.DefaultText = "";
            cvv.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            cvv.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            cvv.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            cvv.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            cvv.FillColor = Color.GhostWhite;
            cvv.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            cvv.Font = new Font("Microsoft JhengHei", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cvv.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            cvv.Location = new Point(147, 232);
            cvv.Margin = new Padding(3, 5, 3, 5);
            cvv.MaxLength = 16;
            cvv.Name = "cvv";
            cvv.PlaceholderForeColor = SystemColors.ActiveCaption;
            cvv.PlaceholderText = "000";
            cvv.SelectedText = "";
            cvv.ShadowDecoration.CustomizableEdges = customizableEdges6;
            cvv.Size = new Size(106, 41);
            cvv.TabIndex = 59;
            cvv.KeyPress += cvv_KeyPress;
            // 
            // mm
            // 
            mm.AccessibleDescription = "Nombre";
            mm.Animated = true;
            mm.BackColor = Color.Transparent;
            mm.BorderColor = Color.Teal;
            mm.BorderRadius = 6;
            mm.BorderThickness = 2;
            mm.CustomizableEdges = customizableEdges7;
            mm.DefaultText = "";
            mm.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            mm.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            mm.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            mm.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            mm.FillColor = Color.GhostWhite;
            mm.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            mm.Font = new Font("Microsoft JhengHei", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            mm.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            mm.Location = new Point(361, 231);
            mm.Margin = new Padding(3, 5, 3, 5);
            mm.MaxLength = 2;
            mm.Name = "mm";
            mm.PlaceholderForeColor = SystemColors.ActiveCaption;
            mm.PlaceholderText = "mm";
            mm.SelectedText = "";
            mm.ShadowDecoration.CustomizableEdges = customizableEdges8;
            mm.Size = new Size(72, 41);
            mm.TabIndex = 60;
            mm.KeyPress += mm_KeyPress;
            // 
            // yy
            // 
            yy.AccessibleDescription = "Nombre";
            yy.Animated = true;
            yy.BackColor = Color.Transparent;
            yy.BorderColor = Color.Teal;
            yy.BorderRadius = 6;
            yy.BorderThickness = 2;
            yy.CustomizableEdges = customizableEdges9;
            yy.DefaultText = "";
            yy.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            yy.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            yy.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            yy.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            yy.FillColor = Color.GhostWhite;
            yy.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            yy.Font = new Font("Microsoft JhengHei", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            yy.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            yy.Location = new Point(448, 231);
            yy.Margin = new Padding(3, 5, 3, 5);
            yy.MaxLength = 2;
            yy.Name = "yy";
            yy.PlaceholderForeColor = SystemColors.ActiveCaption;
            yy.PlaceholderText = "yy";
            yy.SelectedText = "";
            yy.ShadowDecoration.CustomizableEdges = customizableEdges10;
            yy.Size = new Size(72, 41);
            yy.TabIndex = 61;
            yy.KeyPress += yy_KeyPress;
            // 
            // nombre
            // 
            nombre.AccessibleDescription = "Nombre";
            nombre.Animated = true;
            nombre.BackColor = Color.Transparent;
            nombre.BorderColor = Color.Teal;
            nombre.BorderRadius = 6;
            nombre.BorderThickness = 2;
            nombre.CustomizableEdges = customizableEdges11;
            nombre.DefaultText = "";
            nombre.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            nombre.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            nombre.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            nombre.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            nombre.FillColor = Color.GhostWhite;
            nombre.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            nombre.Font = new Font("Microsoft JhengHei", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            nombre.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            nombre.Location = new Point(147, 328);
            nombre.Margin = new Padding(3, 5, 3, 5);
            nombre.MaxLength = 16;
            nombre.Name = "nombre";
            nombre.PlaceholderForeColor = SystemColors.ActiveCaption;
            nombre.PlaceholderText = "";
            nombre.SelectedText = "";
            nombre.ShadowDecoration.CustomizableEdges = customizableEdges12;
            nombre.Size = new Size(301, 41);
            nombre.TabIndex = 62;
            // 
            // Pago
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.fondoRegistro;
            ClientSize = new Size(676, 534);
            Controls.Add(nombre);
            Controls.Add(yy);
            Controls.Add(mm);
            Controls.Add(cvv);
            Controls.Add(numTarjeta);
            Controls.Add(btnPagar);
            Controls.Add(lblTotal);
            Controls.Add(label5);
            Controls.Add(label6);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.SizableToolWindow;
            Name = "Pago";
            Text = "Pago";
            Load += Pago_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label lblTotal;
        private Label label6;
        private Label label5;
        private Guna.UI2.WinForms.Guna2GradientButton btnPagar;
        private Guna.UI2.WinForms.Guna2TextBox numTarjeta;
        private Guna.UI2.WinForms.Guna2TextBox cvv;
        private Guna.UI2.WinForms.Guna2TextBox mm;
        private Guna.UI2.WinForms.Guna2TextBox yy;
        private Guna.UI2.WinForms.Guna2TextBox nombre;
    }
}