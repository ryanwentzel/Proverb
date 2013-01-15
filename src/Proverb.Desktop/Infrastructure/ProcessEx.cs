using System;

namespace Proverb.Infrastructure
{
    public static class ProcessEx
    {
        private static Action<string> _factory;

        public static void RegisterFactory(Action<string> factory)
        {
            Ensure.ArgumentNotNull(factory, "factory");

            _factory = factory;
        }

        public static void Start(string fileName)
        {
            Ensure.ArgumentNotNullOrEmpty(fileName, "fileName");

            if (_factory == null)
            {
                throw new InvalidOperationException("Call RegisterFactory(Action<string>) first.");
            }

            _factory(fileName);
        }
    }
}
