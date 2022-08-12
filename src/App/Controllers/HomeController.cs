using System.Text;
using App.Extensions;
using App.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmailService emailService;
        private readonly IHtmlTemplateService templateService;

        public HomeController(IEmailService emailService, IHtmlTemplateService templateService)
        {
            this.emailService = emailService;
            this.templateService = templateService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> SendTestEmail()
        {
            var html = await templateService.GetHtmlFromTemplate($"Templates{Path.DirectorySeparatorChar}TestingEmail.html");

            await emailService.SendEmailAsync(emailService.GetTestingEmail(), "Email", string.Empty, html);

            this.Show($"Your message were sent to {emailService.GetTestingEmail()}.");

            return RedirectToAction(nameof(Index));
        }
    }
}