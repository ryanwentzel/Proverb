using Ninject.Modules;
using Proverb.Document;
using RazorEngine;
using RazorEngine.Configuration;
using RazorEngine.Templating;

namespace Proverb
{
    public sealed class CoreModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IDocumentParser>().To<DocumentParser>().InSingletonScope();

            ConfigureRazorEngine();
        }

        private void ConfigureRazorEngine()
        {
            var config = new FluentTemplateServiceConfiguration(c => c.WithEncoding(RazorEngine.Encoding.Raw));
            var templateService = new TemplateService(config);
            Razor.SetTemplateService(templateService);
        }
    }
}
