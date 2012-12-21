using System.Threading.Tasks;

namespace Proverb.Models
{
    public interface IDocumentEditor
    {
        IDocument Document { get; }

        Task<IDocument> New();

        Task<IDocument> Open();

        Task<IDocument> Save();

        Task<IDocument> SaveAs();
    }
}
