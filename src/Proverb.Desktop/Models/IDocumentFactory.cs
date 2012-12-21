
using System.Threading.Tasks;
namespace Proverb.Models
{
    public interface IDocumentFactory
    {
        IDocument NewDocument();

        Task<IDocument> NewDocument(string path, string content);
    }
}
