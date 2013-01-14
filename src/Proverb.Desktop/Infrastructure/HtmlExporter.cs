using System.IO.Abstractions;
using System.Threading.Tasks;
using Proverb.Extensions;
using Proverb.Models;

namespace Proverb.Infrastructure
{
    public sealed class HtmlExporter : IExporter
    {
        private readonly IFileSystem _fileSystem;

        private readonly IHtmlTemplate _template;

        private readonly IHtmlTemplateParser _parser;

        public HtmlExporter(IFileSystem fileSystem, IHtmlTemplate template, IHtmlTemplateParser parser)
        {
            Ensure.ArgumentNotNull(fileSystem, "fileSystem");
            Ensure.ArgumentNotNull(template, "template");
            Ensure.ArgumentNotNull(parser, "parser");

            _fileSystem = fileSystem;
            _template = template;
            _parser = parser;
        }

        public async Task<string> Export(IDocument document, string path)
        {
            return await Task.Run(() =>
            {
                var fileContent = _parser.Parse(_template, document);
                _fileSystem.File.WriteAllText(path, fileContent);
            }).ContinueWith<string>(t => 
            {
                t.PropagateExceptions();
                return path;
            });
        }
    }
}
