using System.IO;

namespace Proverb.Infrastructure
{
    public interface IFileWriterFactory
    {
        TextWriter Create(string path);
    }
}
