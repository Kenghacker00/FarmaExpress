namespace FarmaExpressApp
{
    partial class Catalogo
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Catalogo));
            FLPproductos = new FlowLayoutPanel();
            txtBuscar = new Guna.UI2.WinForms.Guna2TextBox();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            lblCarritoCount = new Label();
            pictureBox4 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            SuspendLayout();
            // 
            // FLPproductos
            // 
            FLPproductos.AutoScroll = true;
            FLPproductos.BackColor = SystemColors.ControlLight;
            FLPproductos.FlowDirection = FlowDirection.TopDown;
            FLPproductos.Location = new Point(0, 45);
            FLPproductos.Margin = new Padding(3, 4, 3, 4);
            FLPproductos.Name = "FLPproductos";
            FLPproductos.Size = new Size(938, 579);
            FLPproductos.TabIndex = 0;
            // 
            // txtBuscar
            // 
            txtBuscar.CustomizableEdges = customizableEdges3;
            txtBuscar.DefaultText = "";
            txtBuscar.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtBuscar.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtBuscar.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtBuscar.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtBuscar.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtBuscar.Font = new Font("Segoe UI", 9F);
            txtBuscar.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtBuscar.Location = new Point(297, 7);
            txtBuscar.Margin = new Padding(3, 5, 3, 5);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.PlaceholderText = "Buscar...";
            txtBuscar.SelectedText = "";
            txtBuscar.ShadowDecoration.CustomizableEdges = customizableEdges4;
            txtBuscar.Size = new Size(368, 29);
            txtBuscar.TabIndex = 1;
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = (Image)resources.GetObject("pictureBox1.BackgroundImage");
            pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox1.Location = new Point(241, 5);
            pictureBox1.Margin = new Padding(3, 4, 3, 4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(51, 31);
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            pictureBox1.Click += btnBuscar_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.BackgroundImage = (Image)resources.GetObject("pictureBox2.BackgroundImage");
            pictureBox2.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox2.Location = new Point(864, 629);
            pictureBox2.Margin = new Padding(3, 4, 3, 4);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(66, 39);
            pictureBox2.TabIndex = 0;
            pictureBox2.TabStop = false;
            pictureBox2.Click += btnVerCarrito_Click;
            // 
            // lblCarritoCount
            // 
            lblCarritoCount.AutoSize = true;
            lblCarritoCount.Location = new Point(842, 639);
            lblCarritoCount.Name = "lblCarritoCount";
            lblCarritoCount.Size = new Size(17, 20);
            lblCarritoCount.TabIndex = 3;
            lblCarritoCount.Text = "0";
            // 
            // pictureBox4
            // 
            pictureBox4.BackgroundImage = (Image)resources.GetObject("pictureBox4.BackgroundImage");
            pictureBox4.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox4.Location = new Point(867, 4);
            pictureBox4.Margin = new Padding(3, 4, 3, 4);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(63, 32);
            pictureBox4.TabIndex = 5;
            pictureBox4.TabStop = false;
            pictureBox4.Click += pictureBox4_Click;
            // 
            // Catalogo
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientInactiveCaption;
            ClientSize = new Size(937, 673);
            Controls.Add(pictureBox4);
            Controls.Add(lblCarritoCount);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Controls.Add(txtBuscar);
            Controls.Add(FLPproductos);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Margin = new Padding(3, 4, 3, 4);
            Name = "Catalogo";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FlowLayoutPanel FLPproductos;
        private Guna.UI2.WinForms.Guna2TextBox txtBuscar;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private Label lblCarritoCount;
        private PictureBox pictureBox4;
    }
}