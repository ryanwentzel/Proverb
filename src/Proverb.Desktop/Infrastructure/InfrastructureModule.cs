using Ninject.Modules;

namespace Proverb.Infrastructure
{
    public sealed class InfrastructureModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IApplicationInfo>().To<ApplicationInfo>().InSingletonScope();
        }
    }
}
