using System.Threading.Tasks;
using Proverb.Infrastructure;

namespace Proverb.Models
{
    public interface IDocumentEditor
    {
        IDocument Document { get; }

        Task<IDocument> New();

        Task<IDocument> Open();

        Task<IDocument> Save();

        Task<IDocument> SaveAs();

        Task<string> Export(IExporter exporter);

        Task<string> Preview(IExporter exporter);
    }
}
