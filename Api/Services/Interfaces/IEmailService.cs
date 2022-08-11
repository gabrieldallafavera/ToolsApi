namespace Api.Services.Interfaces
{
    public interface IEmailService
    {
        Task SendEmail(EmailRequest emailRequest);
        void SendEmailHangfire(EmailRequest emailRequest);
    }
}
