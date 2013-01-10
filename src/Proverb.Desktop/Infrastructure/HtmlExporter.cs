using System.IO;
using System.Threading.Tasks;
using MarkdownSharp;
using Proverb.Extensions;
using Proverb.Models;
using RazorEngine;

namespace Proverb.Infrastructure
{
    public sealed class HtmlExporter : IExporter
    {
        private readonly IHtmlTemplate _template;

        private readonly Markdown _markdown;

        public HtmlExporter(IHtmlTemplate template)
        {
            Ensure.ArgumentNotNull(template, "template");

            _template = template;
            _markdown = new Markdown();
        }

        public async Task<string> Export(IDocument document, string path)
        {
            return await Task.Run(() =>
            {
                var html = _markdown.Transform(document.Content);
                var fileContent = Razor.Parse(_template.Html, new { Content = html });
                File.WriteAllText(path, fileContent);
            }).ContinueWith<string>(t => 
            {
                t.PropagateExceptions();
                return path;
            });
        }
    }
}
