using MarkdownSharp;
using RazorEngine;

namespace Proverb.Document
{
    public sealed class DocumentParser : IDocumentParser
    {
        private readonly Markdown _markdown;

        private readonly ITemplate _template;

        public DocumentParser(ITemplate template)
        {
            Ensure.ArgumentNotNull(template, "template");

            _template = template;
            _markdown = new Markdown();
        }

        public string Parse(IDocument markdownDocument)
        {
            Ensure.ArgumentNotNull(markdownDocument, "markdownDocument");

            var html = _markdown.Transform(markdownDocument.Content);
            return Razor.Parse(_template.Content, new { Content = html });
        }
    }
}
