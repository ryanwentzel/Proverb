
using System.Threading.Tasks;
using Proverb.Extensions;
using Proverb.Infrastructure;

namespace Proverb.Models
{
    public class DocumentFactory : IDocumentFactory
    {
        private readonly IFileWriterFactory _fileWriterFactory;

        public DocumentFactory(IFileWriterFactory fileWriterFactory)
        {
            Ensure.ArgumentNotNull(fileWriterFactory, "fileWriterFactory");

            _fileWriterFactory = fileWriterFactory;
        }

        public IDocument NewDocument()
        {
            return new NewDocument();
        }

        public async Task<IDocument> NewDocument(string path, string content)
        {
            var writer = _fileWriterFactory.Create(path);

            Task writeTask = writer.WriteAsync(content);
            await writeTask;

            writer.Dispose();
            writeTask.PropagateExceptions();

            return new Document(path, content);
        }
    }
}
