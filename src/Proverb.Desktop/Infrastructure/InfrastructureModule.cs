using Ninject.Modules;

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
        }
    }
}
