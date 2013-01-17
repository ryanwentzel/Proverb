using System.Threading.Tasks;
using Proverb.Document;
using Proverb.Extensions;

namespace Proverb.Infrastructure
{
    public sealed class HtmlExporter : IExporter
    {
        private readonly IFileWriterFactory _writerFactory;

        private readonly IDocumentParser _parser;

        public HtmlExporter(IFileWriterFactory writerFactory, IDocumentParser parser)
        {
            Ensure.ArgumentNotNull(writerFactory, "writerFactory");
            Ensure.ArgumentNotNull(parser, "parser");

            _writerFactory = writerFactory;
            _parser = parser;
        }

        public async Task<string> Export(IDocument document, string path)
        {
            var fileContents = _parser.Parse(document);
            using (var writer = _writerFactory.Create(path))
            {
                return await writer.WriteAsync(fileContents).ContinueWith(t => 
                {
                    t.PropagateExceptions();
                    return path;
                });
            }
        }
    }
}
