using Ninject.Modules;

namespace Proverb.Helpers
{
    public sealed class HelpersModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IApplicationInfo>().To<ApplicationInfo>().InSingletonScope();
        }
    }
}
