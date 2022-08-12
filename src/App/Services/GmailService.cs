using App.Services.Contracts;
using App.Settings;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;

namespace App.Services
{
    public class GmailService : IEmailService
    {
        private readonly GmailSettings settings;

        public GmailService(IOptions<GmailSettings> settings)
        {
            this.settings = settings.Value;
        }

        public string? GetTestingEmail() => settings.TestingEmail;

        public async Task SendEmailAsync(string? to, string subject, string text, string html)
        {
            var message = new MimeMessage();
            var fromAddress = new MailboxAddress(settings.SenderName, settings.SenderEmail);
            var toAddress = MailboxAddress.Parse(to);
            var builder = new BodyBuilder { TextBody = text, HtmlBody = html };

            message.From.Add(fromAddress);
            message.To.Add(toAddress);
            message.Subject = subject;
            message.Body = builder.ToMessageBody();

            try
            {
                var smtp = new SmtpClient();
                
                smtp.ServerCertificateValidationCallback = (s, c, h, e) => true;

                await smtp.ConnectAsync(settings.ServerAddress, settings.ServerPort).ConfigureAwait(false);
                await smtp.AuthenticateAsync(settings.SenderEmail, settings.Password).ConfigureAwait(false);
                await smtp.SendAsync(message).ConfigureAwait(false);
                await smtp.DisconnectAsync(true).ConfigureAwait(false);
            }
            catch (Exception error)
            {
                throw new InvalidOperationException(error.Message);
            }
        }
    }
}