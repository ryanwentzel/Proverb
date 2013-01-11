using MarkdownSharp;
using Proverb.Models;
using RazorEngine;

namespace Proverb.Infrastructure
{
    public sealed class RazorHtmlTemplateParser : IHtmlTemplateParser
    {
        private readonly Markdown _markdown;

        public RazorHtmlTemplateParser()
        {
            _markdown = new Markdown();
        }

        public string Parse(IHtmlTemplate template, IDocument markdownDocument)
        {
            Ensure.ArgumentNotNull(template, "template");
            Ensure.ArgumentNotNull(markdownDocument, "markdownDocument");

            var html = _markdown.Transform(markdownDocument.Content);
            return Razor.Parse(template.Html, new { Content = html });
        }
    }
}
