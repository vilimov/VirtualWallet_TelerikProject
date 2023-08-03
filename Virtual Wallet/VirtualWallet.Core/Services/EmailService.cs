using MailKit.Net.Smtp;
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

            /* int port = int.Parse(config.GetSection("EmailPort").Value);
             using var smtp = new MailKit.Net.Smtp.SmtpClient();         
             smtp.Connect(config.GetSection("EmailHost").Value, port, SecureSocketOptions.StartTls);
             smtp.Authenticate(config.GetSection("EmailUsername").Value, config.GetSection("EmailPassword").Value);
             smtp.Send(email);
             smtp.Disconnect(true);*/

            using (var client = new SmtpClient())
            {
                client.Connect("smtp.abv.bg", 465, SecureSocketOptions.SslOnConnect);
                client.Authenticate("mkm_vw@abv.bg", "aA1!23456");
                client.Send(email);
                client.Disconnect(true);
            }
        }

        public string GenerateVerificationLink(string token)
        {
            string VerificationBaseUrl = "http://localhost:5206/Users/VerifyEmail";
            string verificationToken = token;
            //string verificationUrl = $"{VerificationBaseUrl}/{verificationToken}";
            string verificationUrl = $"{VerificationBaseUrl}?token={verificationToken}";

            string verificationLink = $"<a href=\"{verificationUrl}\">Click here to verify</a>";
            return verificationLink;
        }
    }
}
