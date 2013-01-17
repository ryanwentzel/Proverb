using Ninject.Modules;
using RazorEngine;
using RazorEngine.Configuration;
using RazorEngine.Templating;

namespace Proverb
{
    public sealed class CoreModule : NinjectModule
    {
        public override void Load()
        {
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
