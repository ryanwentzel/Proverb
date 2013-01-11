using System.IO;
using System.Threading.Tasks;
using Proverb.Extensions;
using Proverb.Models;

namespace Proverb.Infrastructure
{
    public sealed class HtmlExporter : IExporter
    {
        private readonly IHtmlTemplate _template;

        private readonly IHtmlTemplateParser _parser;

        public HtmlExporter(IHtmlTemplate template, IHtmlTemplateParser parser)
        {
            Ensure.ArgumentNotNull(template, "template");
            Ensure.ArgumentNotNull(parser, "parser");

            _template = template;
            _parser = parser;
        }

        public async Task<string> Export(IDocument document, string path)
        {
            return await Task.Run(() =>
            {
                var fileContent = _parser.Parse(_template, document);
                File.WriteAllText(path, fileContent);
            }).ContinueWith<string>(t => 
            {
                t.PropagateExceptions();
                return path;
            });
        }
    }
}
