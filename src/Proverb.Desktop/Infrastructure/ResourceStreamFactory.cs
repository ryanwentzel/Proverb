using System.IO;
using System.Reflection;

namespace Proverb.Infrastructure
{
    public sealed class ResourceStreamFactory : IResourceStreamFactory
    {
        public Stream Create(string resourceName)
        {
            Ensure.ArgumentNotNull(resourceName, "resourceName");

            return Assembly.GetExecutingAssembly().GetManifestResourceStream("Proverb." + resourceName);
        }
    }
}
