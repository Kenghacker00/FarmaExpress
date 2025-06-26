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
    public partial class Productopedido : UserControl
    {
        public event EventHandler BotonEliminarClick;

        public Productopedido()
        {
            InitializeComponent();
        }

        private void Productopedido_Load(object sender, EventArgs e)
        {

        }


        private void btnEliminar_Click(object sender, EventArgs e)
        {
            BotonEliminarClick?.Invoke(this, EventArgs.Empty);
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

        public string cantidad
        {
            get { return lblCantidadTableta.Text; }
            set { lblCantidadTableta.Text = value; }
        }
    }
}
