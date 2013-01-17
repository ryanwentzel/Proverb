using System.Diagnostics;
using Ninject.Modules;
using Proverb.Document;
using RazorEngine;
using RazorEngine.Configuration;
using RazorEngine.Templating;

namespace Proverb.Infrastructure
{
    public sealed class InfrastructureModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IApplicationInfo>().To<ApplicationInfo>().InSingletonScope();
            Bind<IDialogService>().To<DialogService>().InSingletonScope();
            Bind<IFileWriterFactory>().To<FileWriterFactory>().InSingletonScope();
            Bind<IFileReaderFactory>().To<FileReaderFactory>().InSingletonScope();
            Bind<Proverb.Document.ITemplate>().ToMethod(context => HtmlTemplate.FromResource(Constants.TemplateFileName)).InSingletonScope();
            Bind<IDocumentParser>().To<DocumentParser>().InSingletonScope();
            Bind<IExporter>().To<HtmlExporter>().InSingletonScope();

            ConfigureRazorEngine();
            RegisterProcessFactory();
        }

        private void ConfigureRazorEngine()
        {
            var config = new FluentTemplateServiceConfiguration(c => c.WithEncoding(RazorEngine.Encoding.Raw));
            var templateService = new TemplateService(config);
            Razor.SetTemplateService(templateService);
        }

        private void RegisterProcessFactory()
        {
            ProcessEx.RegisterFactory(fileName => Process.Start(fileName));
        }
    }
}
