using App.Services.Contracts;
using App.Settings;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace App.Services
{
    public class SendGridService : IEmailService
    {
        private readonly SendGridSettings settings;

        public SendGridService(IOptions<SendGridSettings> settings)
        {
            this.settings = settings.Value;
        }

        public string? GetTestingEmail() => settings.TestingEmail;

        public async Task SendEmailAsync(string? to, string subject, string text, string html)
        {
            var client = new SendGridClient(settings.ApiKey);
            var fromAddress = new EmailAddress(settings.SenderEmail, settings.SenderName);
            var toAddress = new EmailAddress(to);
            var message = MailHelper.CreateSingleEmail(fromAddress, toAddress, subject, text, html);

            await client.SendEmailAsync(message);
        }
    }
}