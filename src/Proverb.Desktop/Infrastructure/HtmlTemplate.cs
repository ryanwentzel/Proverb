
using System.IO;
using System.Reflection;
using Proverb.Document;
namespace Proverb.Infrastructure
{
    public sealed class HtmlTemplate : ITemplate
    {
        public string Content { get; private set; }

        public HtmlTemplate(string html)
        {
            Ensure.ArgumentNotNullOrEmpty(html, "html");

            Content = html;
        }

        public static HtmlTemplate FromResource(string resourceName)
        {
            Ensure.ArgumentNotNullOrEmpty(resourceName, "resourceName");

            using (var reader = new StreamReader(Assembly.GetExecutingAssembly().GetManifestResourceStream("Proverb." + resourceName)))
            {
                return new HtmlTemplate(reader.ReadToEnd());
            }
        }
    }
}
