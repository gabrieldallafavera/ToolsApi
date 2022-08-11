using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;

namespace Api.Services.Services
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendEmail(EmailRequest emailRequest)
        {
            var email = new MimeMessage();

            email.From.Add(MailboxAddress.Parse(_configuration.GetSection("Email:From").Value));
            email.To.Add(MailboxAddress.Parse(emailRequest.To));
            if (!string.IsNullOrEmpty(emailRequest.Cc))
            {
                email.Cc.Add(MailboxAddress.Parse(emailRequest.Cc));
            }
            email.Subject = emailRequest.Subject;

            var builder = new BodyBuilder();

            builder.HtmlBody = emailRequest.Body;

            if (emailRequest.Attachments != null)
            {
                foreach (var item in emailRequest.Attachments)
                {
                    builder.Attachments.Add(item.Name, new MemoryStream(Convert.FromBase64String(item.Base64)));
                }
            }

            email.Body = builder.ToMessageBody();

            var smtp = new SmtpClient();
            await smtp.ConnectAsync(_configuration.GetSection("Email:Host").Value, int.Parse(_configuration.GetSection("Email:Port").Value), SecureSocketOptions.StartTls);
            await smtp.AuthenticateAsync(_configuration.GetSection("Email:Username").Value, _configuration.GetSection("Email:Password").Value);
            await smtp.SendAsync(email);
            await smtp.DisconnectAsync(true);
        }

        public void SendEmailHangfire(EmailRequest emailRequest)
        {
            BackgroundJob.Enqueue<IEmailService>(x => x.SendEmail(emailRequest));
        }
    }
}
