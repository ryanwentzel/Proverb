using System.IO;

namespace Proverb.Infrastructure
{
    public interface IFileReaderFactory
    {
        TextReader Create(string path);
    }
}
