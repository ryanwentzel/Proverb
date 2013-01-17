using System.Diagnostics;
using Ninject.Modules;
using Proverb.Document;

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

            RegisterProcessFactory();
        }

        private void RegisterProcessFactory()
        {
            ProcessEx.RegisterFactory(fileName => Process.Start(fileName));
        }
    }
}
