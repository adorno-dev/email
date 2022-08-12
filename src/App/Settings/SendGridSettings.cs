namespace App.Settings
{
    public class SendGridSettings
    {
        public string? SenderName { get; set; }
        public string? SenderEmail { get; set; }
        public string? ApiKey { get; set; }

        public string? TestingEmail { get; set; }
    }
}