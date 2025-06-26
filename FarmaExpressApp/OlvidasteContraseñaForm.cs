using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FarmaExpressApp
{
    public partial class OlvidasteContraseñaForm : Form
    {
        public OlvidasteContraseñaForm()
        {
            InitializeComponent();
        }

        private async void btnEnviarCodigo_Click(object sender, EventArgs e)
        {
            string correo = txtCorreo.Text;

            if (string.IsNullOrWhiteSpace(correo))
            {
                MessageBox.Show("Por favor, ingrese su correo.");
                return;
            }

            var cliente = new HttpClient();
            var contenido = new StringContent(
                JsonSerializer.Serialize(new { email = correo }),
                Encoding.UTF8,
                "application/json");

            var respuesta = await cliente.PostAsync("https://localhost:7290/api/Usuario/solicitar-recuperacion", contenido);

            if (respuesta.IsSuccessStatusCode)
            {
                MessageBox.Show("El código fue enviado a tu correo.");
            }
            else
            {
                var error = await respuesta.Content.ReadAsStringAsync();
                MessageBox.Show("Error: " + error);
            }
        }

        private async void btnIngresar_Click(object sender, EventArgs e)
        {
            string email = txtCorreo.Text;
            string codigo = txtCodigo.Text;

            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(codigo))
            {
                MessageBox.Show("Por favor, complete ambos campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var dto = new
            {
                Email = email,
                Codigo = codigo
            };

            using var client = new HttpClient();
            var contenido = new StringContent(
                JsonSerializer.Serialize(dto),
                Encoding.UTF8,
                "application/json"
            );

            var response = await client.PostAsync("https://localhost:7290/api/usuario/verificar-codigo", contenido);

            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Código verificado. Continúa con el cambio de contraseña.", "Éxito");

                // Abrir el formulario de cambiar contraseña
                var form = new CambiarContraseña(email); // Asegúrate de tener un constructor que reciba el email
                this.Hide();
                form.ShowDialog();
            }
            else
            {
                string error = await response.Content.ReadAsStringAsync();
                MessageBox.Show($"Error al verificar: {error}", "Código inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
