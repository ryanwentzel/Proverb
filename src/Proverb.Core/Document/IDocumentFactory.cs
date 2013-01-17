
using System.Threading.Tasks;

namespace Proverb.Document
{
    public interface IDocumentFactory
    {
        IDocument NewDocument();

        IDocument NewDocument(string content);

        Task<IDocument> NewDocument(string path, string content);

        Task<IDocument> OpenDocument(string path);
    }
}
