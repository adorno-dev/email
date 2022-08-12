using App.Services.Contracts;

namespace App.Services
{
    public class HtmlTemplateService : IHtmlTemplateService
    {
        public async Task<string> GetHtmlFromTemplate(string path, IDictionary<string, string>? values = null)
        {
            var html = File.ReadAllText(Path.GetFullPath(path));

            if (html is not null)
            {
                if (values is not null)
                {
                    foreach (var item in values)
                        html = html.Replace($"##{item.Key}##", item.Value);    
                }
                
                return html;
            }

            await Task.CompletedTask;

            return string.Empty;
        }
    }
}