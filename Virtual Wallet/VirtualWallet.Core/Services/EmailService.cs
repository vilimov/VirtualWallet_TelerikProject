using MailKit.Security;
using Microsoft.Extensions.Configuration;
using MimeKit;
using MimeKit.Text;
using VirtualWallet.Application.Services.Contracts;
using VirtualWallet.Domain.Entities;

namespace VirtualWallet.Application.Services
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration config;

        public EmailService(IConfiguration config)
        {
            this.config = config;
        }
        public void SendEmail(Mail request)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(config.GetSection("EmailUsername").Value));
            email.To.Add(MailboxAddress.Parse(request.To));
            email.Subject = request.Subject;
            email.Body = new TextPart(TextFormat.Html) { Text = request.Body };

            int port = int.Parse(config.GetSection("EmailPort").Value);
            using var smtp = new MailKit.Net.Smtp.SmtpClient();         
            smtp.Connect(config.GetSection("EmailHost").Value, port, SecureSocketOptions.StartTls);
            smtp.Authenticate(config.GetSection("EmailUsername").Value, config.GetSection("EmailPassword").Value);
            smtp.Send(email);
            smtp.Disconnect(true);
        }
    }
}
