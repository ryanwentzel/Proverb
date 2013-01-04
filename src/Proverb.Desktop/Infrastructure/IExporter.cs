using System.Threading.Tasks;
using Proverb.Models;

namespace Proverb.Infrastructure
{
    public interface IExporter
    {
        Task<string> Export(IDocument document, string path);
    }
}
