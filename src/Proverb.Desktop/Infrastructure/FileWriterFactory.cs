using System.IO;

namespace Proverb.Infrastructure
{
    public sealed class FileWriterFactory : IFileWriterFactory
    {
        public TextWriter Create(string path)
        {
            return new StreamWriter(path);
        }
    }
}
