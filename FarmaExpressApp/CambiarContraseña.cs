using FarmaExpress.Models.Dto;
using FarmaExpress_API.Dto;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FarmaExpressApp
{
    public partial class CambiarContraseña : Form
    {
        private readonly string _email;
        public CambiarContraseña(string email)
        {
            InitializeComponent();
            _email = email;
        }

        private async void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (txtNueva.Text != txtConfirmar.Text)
            {
                MessageBox.Show("Las contraseñas no coinciden.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var nuevaPassword = txtNueva.Text;
            var email = _email;

            // Obtener ID por correo
            using var client = new HttpClient();
            var response = await client.GetAsync($"https://localhost:7290/api/usuario/email/{email}");

            if (!response.IsSuccessStatusCode)
            {
                MessageBox.Show("No se pudo obtener el usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var usuario = await response.Content.ReadFromJsonAsync<UsuarioDto>();
            int usuarioId = usuario.UsuarioId;

            // Crear PATCH
            var patchDoc = new JsonPatchDocument<RestablecerPasswordDto>();
            patchDoc.Replace(p => p.NuevaContraseña, nuevaPassword);

            var content = new StringContent(
                JsonConvert.SerializeObject(patchDoc),
                Encoding.UTF8,
                "application/json-patch+json");


            var result = await client.PatchAsync($"https://localhost:7290/api/usuario/cambiar-password/{usuarioId}", content);

            if (result.IsSuccessStatusCode)
            {
                MessageBox.Show("Contraseña actualizada con éxito.");
                this.Close();
            }
            else
            {
                MessageBox.Show("Error al cambiar la contraseña.");
            }
        }
    }
}
