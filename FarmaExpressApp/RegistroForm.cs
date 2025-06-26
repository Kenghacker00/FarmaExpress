using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.Text.Json;
using FarmaExpress.Models.Dto;
using FarmaExpress_API.Dto;


namespace FarmaExpressApp
{
    public partial class RegistroForm : Form
    {
        public RegistroForm()
        {
            InitializeComponent();
        }

        private void RegistroForm_Load(object sender, EventArgs e) { }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
            IniciodeSesión form = new IniciodeSesión();
            form.ShowDialog();
        }

        private async Task<bool> RegistrarUsuarioAsync(UsuarioCreateDto usuarioDto)
        {
            using var cliente = new HttpClient();
            var contenido = new StringContent(
                JsonSerializer.Serialize(usuarioDto),
                Encoding.UTF8,
                "application/json");

            var respuesta = await cliente.PostAsync("https://localhost:7290/api/auth/registro", contenido);

            if (respuesta.IsSuccessStatusCode)
            {
                MessageBox.Show("Usuario registrado correctamente");
                return true;
            }
            else
            {
                string error = await respuesta.Content.ReadAsStringAsync();

                if (!string.IsNullOrWhiteSpace(error))
                    MessageBox.Show("Error: " + error, "Registro fallido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                    MessageBox.Show("Error desconocido al registrar.", "Registro fallido", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return false;
            }
        }

        private async void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text != txtConfirmarPassword.Text)
            {
                MessageBox.Show("Las contraseñas no coinciden.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var usuario = new UsuarioCreateDto
            {
                Nombre = txtNombre.Text,
                Apellido = txtApellido.Text,
                Email = txtEmail.Text,
                Contraseña = txtPassword.Text
            };

            bool exito = await RegistrarUsuarioAsync(usuario);

            if (exito)
            {
                this.Hide();
                new IniciodeSesión().Show();
            }
        }
    }
}
