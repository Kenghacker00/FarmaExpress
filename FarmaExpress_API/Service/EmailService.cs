
using MailKit.Net.Smtp;
using MimeKit;

namespace FarmaExpress_API.Service
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _config;

        public EmailService(IConfiguration config)
        {
            _config = config;
        }

        public async Task EnviarCodigoVerificacion(string correoDestino, string codigo)
        {
            var mensaje = new MimeMessage();
            mensaje.From.Add(new MailboxAddress("FarmaExpress", _config["MailSettings:From"]));
            mensaje.To.Add(MailboxAddress.Parse(correoDestino));
            mensaje.Subject = "Recuperación de Contraseña - FarmaExpress";

            string html = $@"
    <div style='font-family: Arial, sans-serif; background-color: #f9f9f9; padding: 20px; color: #333;'>
        <div style='max-width: 600px; margin: auto; background-color: white; border-radius: 10px; box-shadow: 0 0 10px rgba(0,0,0,0.1); padding: 30px;'>
            <div style='text-align: center;'>
                <img src='https://i.ibb.co/cXtHfwhL/Farma-Express-Logo.jpg' alt='FarmaExpress' style='width: 150px; margin-bottom: 20px;' />
                <h2 style='color: #2a9d8f;'>Recuperación de contraseña</h2>
                <p style='font-size: 16px;'>Has solicitado recuperar tu contraseña. Usa el siguiente código para continuar:</p>
                <div style='font-size: 28px; font-weight: bold; color: #e76f51; margin: 20px 0;'>{codigo}</div>
                <p style='font-size: 14px; color: #666;'>Este código expira en 10 minutos. Si no fuiste tú, ignora este mensaje.</p>
            </div>
            <hr style='margin: 30px 0;'>
            <p style='text-align: center; font-size: 12px; color: #999;'>FarmaExpress - Automatizando tu salud</p>
        </div>
    </div>";

            mensaje.Body = new TextPart("html")
            {
                Text = html
            };

            using var smtp = new SmtpClient();
            await smtp.ConnectAsync(_config["MailSettings:SmtpServer"], int.Parse(_config["MailSettings:Port"]), true);
            await smtp.AuthenticateAsync(_config["MailSettings:From"], _config["MailSettings:Password"]);
            await smtp.SendAsync(mensaje);
            await smtp.DisconnectAsync(true);
        }

    }
}
