using System.Windows.Forms;

namespace Proverb.Infrastructure
{
    public sealed class ApplicationInfo : IApplicationInfo
    {
        public string Name { get; private set; }

        public string Version { get; private set; }

        public ApplicationInfo()
        {
            Name = Application.ProductName;
            Version = Application.ProductVersion;
        }
    }
}
