namespace App.Services.Contracts
{
    public interface IEmailService
    {
        Task SendEmailAsync(string? to, string subject, string text, string html);

        string? GetTestingEmail();
    }
}