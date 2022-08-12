using System.Text.Json;
using App.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace App.Extensions
{
    public static class ControllerExtensions
    {
        public static void Show(this Controller @this, string text, bool error = false)
        {
            @this.TempData.Add("message", JsonSerializer.Serialize(new MessageVM(error ? MessageType.Error : MessageType.Information, text)));
        }
    }
}