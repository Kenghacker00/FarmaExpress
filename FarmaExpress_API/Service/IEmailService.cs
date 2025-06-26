namespace FarmaExpress_API.Service
{
    public interface IEmailService
    {
        Task EnviarCodigoVerificacion(string correoDestino, string codigo);
    }
}
