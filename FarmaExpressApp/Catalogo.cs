using FarmaExpress_API.Dto;
using Newtonsoft.Json;
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
    public partial class Catalogo : Form
    {
        private readonly string _token;
        private readonly int _usuarioId;

        private List<ProductoDto> carrito = new List<ProductoDto>();
        private List<ProductoDto> productosOriginales = new List<ProductoDto>();


        public Catalogo(string token, int usuarioId)
        {
            InitializeComponent();
            _token = token;
            _usuarioId = usuarioId;

            CargarProductos();
        }

        private void ActualizarContadorCarrito()
        {
            lblCarritoCount.Text = carrito.Count.ToString();
        }


        private async Task<List<ProductoDto>> ObtenerProductos()
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _token);
                var response = await client.GetAsync("https://localhost:7290/api/Producto");

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<ProductoDto>>(json);
                }
                else
                {
                    MessageBox.Show("Error al obtener los productos desde la API");
                    return new List<ProductoDto>();
                }
            }
        }

        private async void MostrarProductos(List<ProductoDto> productos)
        {
            FLPproductos.Controls.Clear();

            foreach (var producto in productos)
            {
                var control = new ProductoControl
                {
                    NombreProducto = producto.Nombre,
                    Precio = $"C$ {producto.Precio:F2}",
                    Categoria = producto.Categoria.Nombre ?? "-"
                };

                try
                {
                    using (var client = new HttpClient())
                    {
                        var stream = await client.GetStreamAsync(producto.ImagenUrl);
                        control.ImgProducto = Image.FromStream(stream);
                    }
                }
                catch
                {
                    control.ImgProducto = Properties.Resources.logoMotoOg;
                }

                control.BotonAgregarClick += (s, e) =>
                {
                    carrito.Add(producto);
                    ActualizarContadorCarrito();
                    MessageBox.Show($"Agregado: {control.NombreProducto}");
                };

                FLPproductos.Controls.Add(control);
            }
        }

        private async void CargarProductos()
        {
            productosOriginales = await ObtenerProductos();
            MostrarProductos(productosOriginales);

        }

        private void btnVerCarrito_Click(object sender, EventArgs e)
        {
            var carritoForm = new CarritoCompras(carrito, ActualizarContadorCarrito, _token,_usuarioId);
            carritoForm.Show();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string textoBusqueda = txtBuscar.Text.Trim().ToLower();

            var filtrados = productosOriginales
                .Where(p => p.Nombre.ToLower().Contains(textoBusqueda))
                .ToList();

            MostrarProductos(filtrados);
        }


        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
