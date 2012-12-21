using System.IO;

namespace Proverb.Infrastructure
{
    public sealed class FileReaderFactory : IFileReaderFactory
    {
        public TextReader Create(string path)
        {
            return new StreamReader(path);
        }
    }
}
