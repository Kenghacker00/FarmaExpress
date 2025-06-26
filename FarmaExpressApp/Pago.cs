using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FarmaExpress_API.Dto;
using FarmaExpress.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Reflection.Metadata;
using System.IO;

using iText.IO.Font.Constants;
using iText.IO.Image;
using iText.Kernel.Colors;
using iText.Kernel.Font;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Borders;
using iText.Layout.Element;
using iText.Layout.Properties;
using Document = iText.Layout.Document;
using Table = iText.Layout.Element.Table;
using iText.Kernel.Pdf.Canvas.Draw;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace FarmaExpressApp
{


    public partial class Pago : Form
    {
        private List<ProductoDto> carrito;
        private string _token;
        private int _usuarioId;

        public Pago(List<ProductoDto> carrito, string token, int usuarioid)
        {
            InitializeComponent();
            this.carrito = carrito;
            this._token = token;
            _usuarioId = usuarioid;

            lblTotal.Text = (CalcularMontoEnvio() + carrito.Sum(p => p.Precio)).ToString("C2");


        }

        private decimal CalcularMontoEnvio()
        {
            decimal costoPaquete = 15;
            int capacidadPaquete = 3;

            int cantidadProductos = carrito.Count;

            int numeroPaquetes = (cantidadProductos + capacidadPaquete - 1) / capacidadPaquete;

            return numeroPaquetes * costoPaquete;
        }



        private async void btnPagar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(numTarjeta.Text) ||
                string.IsNullOrWhiteSpace(cvv.Text) ||
                string.IsNullOrWhiteSpace(mm.Text) ||
                string.IsNullOrWhiteSpace(yy.Text) ||
                string.IsNullOrWhiteSpace(nombre.Text))
            {
                MessageBox.Show("Por favor, completá todos los datos de la tarjeta.");
                return;
            }

            if (numTarjeta.Text.Length != 16)
            {
                MessageBox.Show("La tarjeta debe tener 16 dígitos.");
                return;
            }

            if (cvv.Text.Length != 3)
            {
                MessageBox.Show("El CVV debe tener 3 dígitos.");
                return;
            }

            int mes = int.Parse(mm.Text);
            int anio = int.Parse(yy.Text);
            int anioActual = DateTime.Now.Year % 100;
            int mesActual = DateTime.Now.Month;

            if (anio < anioActual || (anio == anioActual && mes < mesActual))
            {
                MessageBox.Show("La tarjeta ha expirado.");
                return;
            }

            var pedido = new PedidoCreateDto
            {
                UsuarioId = _usuarioId,
                Fecha = DateTime.Now,
                Detalles = carrito
        .GroupBy(p => p.ProductoId)
        .Select(g => new PedidoDetalleCreateDto
        {
            ProductoId = g.Key,
            Cantidad = g.Count(),
            PrecioUnitario = g.First().Precio
        })
        .ToList()
            };

            pedido.PagoTotal = pedido.Detalles.Sum(d => d.PrecioUnitario * d.Cantidad);


            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _token);

                var json = JsonConvert.SerializeObject(pedido);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await client.PostAsync("https://localhost:7290/api/Pedido", content);

                if (response.IsSuccessStatusCode)
                {
                    decimal envio = CalcularMontoEnvio();
                    MessageBox.Show("¡Pago exitoso!");
                    GenerarFactura(nombre.Text, carrito, envio);
                    carrito.Clear();
                    Close();
                }
                else
                {
                    var errorBody = await response.Content.ReadAsStringAsync();
                    MessageBox.Show($"Error al procesar el pedido:\n{response.StatusCode}\n{errorBody}");
                }

            }
        }
        public void GenerarFactura(string nombreCliente, List<ProductoDto> carrito, decimal envio)
        {
            try
            {
                string fechaActual = DateTime.Now.ToString("yyMMdd");
                Random random = new Random();
                int codigoAleatorio = random.Next(0, 1000);
                string nombreArchivo = $"Factura{fechaActual}_{codigoAleatorio:D3}.pdf";
                string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), nombreArchivo);

                PdfWriter writer = new PdfWriter(filePath);
                PdfDocument pdf = new PdfDocument(writer);
                Document document = new Document(pdf);

                PdfFont standardFont = PdfFontFactory.CreateFont(iText.IO.Font.Constants.StandardFonts.HELVETICA);

                string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Imágenes", "logoMotoOg.jpg");

                iText.Layout.Element.Image logo = null;

                if (!File.Exists(path))
                {
                    Console.WriteLine("No se encontró la imagen en: " + path);
                }
                else
                {
                    var imageData = iText.IO.Image.ImageDataFactory.Create(path);
                    logo = new iText.Layout.Element.Image(imageData);
                }

                if (logo != null)
                {
                    logo.SetFixedPosition(110, 720);
                    logo.ScaleToFit(90, 90);
                    document.Add(logo);
                }


                Paragraph head = new Paragraph("FarmaExpress         \nContacto: farmaexpress@gmail.com     ").SetFont(standardFont)
                    .SetFontSize(14)
                    .SetTextAlignment(iText.Layout.Properties.TextAlignment.RIGHT);

                document.Add(head);

                document.Add(new Paragraph("\n\n"));

                Paragraph header = new Paragraph("Factura")
                    .SetFont(standardFont)
                    .SetFontSize(20)
                    .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
                    .SetMarginBottom(20);
                document.Add(header);
                LineSeparator separator1 = new LineSeparator(new SolidLine());
                separator1.SetWidth(520);
                separator1.SetMarginTop(20);
                document.Add(separator1);
                document.Add(new Paragraph(" "));


                Paragraph invoiceNumber = new Paragraph($"Número de factura: \t \t{codigoAleatorio}")
                .SetFont(standardFont)
                    .SetFontSize(13);
                Paragraph invoiceDate = new Paragraph("Fecha: \t\t \t" + DateTime.Now.ToString("dd/MM/yyyy"))
                    .SetFont(standardFont)
                    .SetFontSize(13);
                Paragraph customerName = new Paragraph($"Cliente: \t\t \t{nombre.Text}")
                    .SetFont(standardFont)
                    .SetFontSize(13);




                document.Add(invoiceNumber);
                document.Add(invoiceDate);
                document.Add(customerName);



                document.Add(new Paragraph(" "));
                document.Add(new Paragraph(" "));


                Table table = new Table(4);
                table.SetWidth(520);

                table.AddCell(new Cell().Add(new Paragraph("Cantidad"))
                    .SetBorder(new SolidBorder(1f))
                    .SetBackgroundColor(ColorConstants.LIGHT_GRAY));
                table.AddCell(new Cell().Add(new Paragraph("Descripción"))
                    .SetBorder(new SolidBorder(1f))
                    .SetBackgroundColor(ColorConstants.LIGHT_GRAY));
                table.AddCell(new Cell().Add(new Paragraph("Precio Unitario"))
                    .SetBorder(new SolidBorder(1f))
                    .SetBackgroundColor(ColorConstants.LIGHT_GRAY));
                table.AddCell(new Cell().Add(new Paragraph("Total"))
                    .SetBorder(new SolidBorder(1f))
                    .SetBackgroundColor(ColorConstants.LIGHT_GRAY));

                foreach (var p in carrito)
                {
                    table.AddCell(new Cell().Add(new Paragraph("1").SetFont(standardFont).SetTextAlignment(iText.Layout.Properties.TextAlignment.RIGHT)));
                    table.AddCell(new Cell().Add(new Paragraph($"{p.Nombre} {p.Categoria.Nombre}").SetFont(standardFont)));
                    table.AddCell(new Cell().Add(new Paragraph($"{p.Precio:C}").SetFont(standardFont).SetTextAlignment(iText.Layout.Properties.TextAlignment.RIGHT)));
                    table.AddCell(new Cell().Add(new Paragraph($"{p.Precio}").SetFont(standardFont).SetTextAlignment(iText.Layout.Properties.TextAlignment.RIGHT)));

                }

                document.Add(table);


                document.Add(new Paragraph("\n\n"));
                Paragraph subtotal = new Paragraph($"Subtotal: \t ${carrito.Sum(p => p.Precio)}\nEnvio:   \t ${envio}")
                    .SetFont(standardFont)
                    .SetFontSize(10)
                    .SetTextAlignment(iText.Layout.Properties.TextAlignment.RIGHT);
                document.Add(subtotal);
                LineSeparator separator2 = new LineSeparator(new SolidLine());
                separator2.SetWidth(520);
                separator2.SetMarginTop(20);
                document.Add(separator2);

                Paragraph total = new Paragraph($"Total: \t ${carrito.Sum(p => p.Precio) + envio}")
                    .SetFont(standardFont)
                    .SetFontSize(10)
                    .SetTextAlignment(iText.Layout.Properties.TextAlignment.RIGHT);
                document.Add(total);

                Paragraph footer = new Paragraph("www.farmaexpress.com | Términos y condiciones aplicables")
                    .SetFontSize(8)
                    .SetTextAlignment(TextAlignment.CENTER)
                    .SetFixedPosition(50, 50, 500);
                document.Add(footer);

                document.Close();
                carrito.Clear();
                MessageBox.Show("Factura generada en tu escritorio");
                Application.Exit();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }


        private void Pago_Load(object sender, EventArgs e)
        {

        }

        private void numTarjeta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void cvv_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void mm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void yy_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
