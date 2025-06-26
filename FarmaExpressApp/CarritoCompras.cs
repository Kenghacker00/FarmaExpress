using FarmaExpress_API.Dto;
using Newtonsoft.Json.Linq;
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
    public partial class CarritoCompras : Form
    {
        private List<ProductoDto> _carrito;
        private Action _refrescarContador;
        private string _token;
        private int _usuarioId;


        public CarritoCompras(List<ProductoDto> carrito, Action refrescarContador, string token, int usuarioid)
        {
            InitializeComponent();
            _carrito = carrito;
            _refrescarContador = refrescarContador;
            _token = token;
            MostrarCarrito();
            _usuarioId = usuarioid;

        }



        private void MostrarCarrito()
        {
            FLPcarrito.Controls.Clear();

            foreach (var producto in _carrito.ToList())
            {
                var item = new Productopedido
                {
                    NombreProducto = producto.Nombre,
                    Precio = $"C$ {producto.Precio:F2}",
                    cantidad = "1" // más adelante podés permitir modificar la cantidad
                };

                item.BotonEliminarClick += (s, e) =>
                {
                    _carrito.Remove(producto);
                    _refrescarContador?.Invoke();
                    MostrarCarrito();
                };

                FLPcarrito.Controls.Add(item);
            }

            lblTotals.Text = $"C$ {_carrito.Sum(p => p.Precio):F2}";
        }

        private void btnAgregarpedido_Click(object sender, EventArgs e)
        {
            var pagoForm = new Pago(_carrito, _token,_usuarioId);
            pagoForm.Show();

        }
    }
}
