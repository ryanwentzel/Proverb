
using System.Threading.Tasks;
using Proverb.Extensions;
using Proverb.Infrastructure;

namespace Proverb.Models
{
    public class DocumentFactory : IDocumentFactory
    {
        private readonly IFileWriterFactory _fileWriterFactory;
        private readonly IFileReaderFactory _fileReaderFactory;

        public DocumentFactory(IFileWriterFactory fileWriterFactory, IFileReaderFactory fileReaderFactory)
        {
            Ensure.ArgumentNotNull(fileWriterFactory, "fileWriterFactory");
            Ensure.ArgumentNotNull(fileReaderFactory, "fileReaderFactory");

            _fileWriterFactory = fileWriterFactory;
            _fileReaderFactory = fileReaderFactory;
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

        public async Task<IDocument> OpenDocument(string path)
        {
            var reader = _fileReaderFactory.Create(path);
            return await reader.ReadToEndAsync().ContinueWith<IDocument>(t => 
            {
                reader.Dispose();
                t.PropagateExceptions();

                return new Document(path, t.Result);
            });
        }
    }
}
