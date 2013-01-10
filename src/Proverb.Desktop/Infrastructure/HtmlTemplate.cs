
using System.IO;
using System.Reflection;
namespace Proverb.Infrastructure
{
    public sealed class HtmlTemplate : IHtmlTemplate
    {
        public string Html { get; private set; }

        public HtmlTemplate(string html)
        {
            Ensure.ArgumentNotNullOrEmpty(html, "html");

            Html = html;
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
