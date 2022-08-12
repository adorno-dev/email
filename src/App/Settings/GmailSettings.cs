namespace App.Settings
{
    public class GmailSettings
    {
        public string? SenderName { get; set; }
        public string? SenderEmail { get; set; }
        public string? Password { get; set; }
        public string? ServerAddress { get; set; }
        public int ServerPort { get; set; }
        public bool UseSSL { get; set; }

        public string? TestingEmail { get; set; }
    }
}