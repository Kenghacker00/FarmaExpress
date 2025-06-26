using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FarmaExpressApp
{
    public partial class ProductoControl : UserControl
    {

        public ProductoControl()
        {
            InitializeComponent();
        }

        private void ProductoControl_Load(object sender, EventArgs e)
        {

        }

        public event EventHandler BotonAgregarClick;

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            BotonAgregarClick?.Invoke(this, EventArgs.Empty);
        }


        public string NombreProducto
        {
            get { return lblNombre.Text; }
            set { lblNombre.Text = value; }
        }

        public string Precio
        {
            get { return lblprecio.Text; }
            set { lblprecio.Text = value; }
        }

        public string Categoria
        {
            get { return lblCategoría.Text; }
            set { lblCategoría.Text = value; }
        }

        public Image ImgProducto
        {
            get { return pictureBox1.Image; }
            set { pictureBox1.Image = value; }
        }
    }
}
