using System.Text.Json;

namespace App.ViewModels
{
    public enum MessageType { Information, Error }

    public class MessageVM
    {
        public MessageType Type { get; set; }

        public string? Text { get; set; }

        public MessageVM(MessageType type, string? text)
        {
            Type = type;
            Text = text;
        }

        public override string ToString()
        {
            return JsonSerializer.Serialize<MessageVM>(this);
        }
    }
}