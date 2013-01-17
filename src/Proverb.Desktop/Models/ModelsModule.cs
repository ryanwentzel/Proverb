using Ninject.Modules;
using Proverb.Document;

namespace Proverb.Models
{
    public sealed class ModelsModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IDocumentEditor>().To<DocumentEditor>().InSingletonScope();
            Bind<IDocumentFactory>().To<DocumentFactory>().InSingletonScope();
        }
    }
}
