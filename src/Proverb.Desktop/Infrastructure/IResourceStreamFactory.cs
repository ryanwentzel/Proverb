using System.IO;

namespace Proverb.Infrastructure
{
    public interface IResourceStreamFactory
    {
        Stream Create(string resourceName);
    }
}
