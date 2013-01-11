using Proverb.Models;

namespace Proverb.Infrastructure
{
    public interface IHtmlTemplateParser
    {
        string Parse(IHtmlTemplate template, IDocument markdownDocument);
    }
}
