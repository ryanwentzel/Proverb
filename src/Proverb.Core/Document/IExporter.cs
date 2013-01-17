using System.Threading.Tasks;

namespace Proverb.Document
{
    public interface IExporter
    {
        Task<string> Export(IDocument document, string path);
    }
}
