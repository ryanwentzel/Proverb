using System;
using System.Threading.Tasks;
using HtmlAgilityPack;
using MarkdownSharp;
using Proverb.Extensions;
using Proverb.Models;

namespace Proverb.Infrastructure
{
    public sealed class HtmlExporter : IExporter
    {
        private readonly IResourceStreamFactory _streamFactory;

        private readonly Markdown _markdown;

        public HtmlExporter(IResourceStreamFactory factory)
        {
            Ensure.ArgumentNotNull(factory, "factory");

            _streamFactory = factory;
            _markdown = new Markdown();
        }

        public async Task<string> Export(IDocument document, string path)
        {
            return await Task.Run(() =>
            {
                var htmlDocument = new HtmlDocument();
                using (var stream = _streamFactory.Create(Constants.TemplateFileName))
                {
                    htmlDocument.Load(stream);
                }

                var bodyNode = htmlDocument.DocumentNode.SelectSingleNode("//body");
                if (bodyNode == null) throw new InvalidOperationException("Body node is null.");

                bodyNode.InnerHtml = _markdown.Transform(document.Content);
                htmlDocument.Save(path);
            }).ContinueWith<string>(t => 
            {
                t.PropagateExceptions();
                return path;
            });
        }
    }
}
