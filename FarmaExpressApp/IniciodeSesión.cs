using FarmaExpress.Models.Dto;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace FarmaExpressApp
{
    public partial class IniciodeSesión : Form
    {
        public IniciodeSesión()
        {
            InitializeComponent();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            RegistroForm form = new RegistroForm();
            form.ShowDialog();
        }

        private async Task<LoginResponseDto?> LoginUsuarioAsync(string gmail, string contraseña)
        {
            using var cliente = new HttpClient();

            var login = new LoginDto
            {
                Gmail = gmail,
                Contraseña = contraseña
            };

            var contenido = new StringContent(
                JsonConvert.SerializeObject(login),
                Encoding.UTF8,
                "application/json");

            var respuesta = await cliente.PostAsync("https://localhost:7290/api/auth/login", contenido);

            var body = await respuesta.Content.ReadAsStringAsync();

            if (respuesta.IsSuccessStatusCode)
            {
                var resultado = JsonConvert.DeserializeObject<LoginResponseDto>(body);
                return resultado;
            }
            else
            {
                MessageBox.Show("Credenciales incorrectas.\n" + body);
                return null;
            }
        }




        private async void BtnIniciarSesion_Click(object sender, EventArgs e)
        {
            var loginResultado = await LoginUsuarioAsync(txtGmail.Text, txtPassword.Text);

            if (loginResultado != null)
            {
                MessageBox.Show("Inicio de sesión exitoso");

                var catalogo = new Catalogo(loginResultado.Token, loginResultado.UsuarioId);
                this.Hide();
                catalogo.Show();
            }
        }


        private void btnOlvide_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OlvidasteContraseñaForm form = new OlvidasteContraseñaForm();
            form.ShowDialog();
        }

        private void IniciodeSesión_Load(object sender, EventArgs e)
        {

        }
    }
}
