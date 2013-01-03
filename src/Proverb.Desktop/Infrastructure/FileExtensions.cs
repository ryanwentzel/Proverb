using System.Collections.Generic;
using System.Linq;

namespace Proverb.Infrastructure
{
    public static class FileExtensions
    {
        public static readonly IEnumerable<string> Defaults = new[] { ".md", ".markdown", ".mdown", ".mkd", ".txt" };

        public static string Filter
        {
            get
            {
                var wildCards = Defaults.Select(extension => "*" + extension).ToArray();
                return string.Format("Markdown files({0})|{1}", string.Join(", ", wildCards), string.Join(";", wildCards));
            }
        }
    }
}
