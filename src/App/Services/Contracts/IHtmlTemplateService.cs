namespace App.Services.Contracts
{
    public interface IHtmlTemplateService
    {
        Task<string> GetHtmlFromTemplate(string path, IDictionary<string, string>? values = null);        
    }
}