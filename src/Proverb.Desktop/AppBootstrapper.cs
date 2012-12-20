
using System;
using System.Collections.Generic;
using System.Reflection;
using Caliburn.Micro;
using Ninject;
using Proverb.ViewModels;

namespace Proverb
{
    public class AppBootstrapper : Bootstrapper<ShellViewModel>
    {
        private IKernel _kernel;

        protected override void OnExit(object sender, EventArgs e)
        {
            _kernel.Dispose();
            base.OnExit(sender, e);
        }

        protected override void Configure()
        {
            _kernel = new StandardKernel();
            _kernel.Bind<IWindowManager>().To<WindowManager>().InSingletonScope();
            _kernel.Bind<IEventAggregator>().To<EventAggregator>().InSingletonScope();

            // Other parts of the application configure bindings in modules.
            _kernel.Load(Assembly.GetExecutingAssembly());
        }

        protected override object GetInstance(Type service, string key)
        {
            return _kernel.Get(service, key);
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return _kernel.GetAll(service);
        }

        protected override void BuildUp(object instance)
        {
            _kernel.Inject(instance);
        }

#if !DEBUG
        protected override void StartRuntime()
        {
            AppDomain.CurrentDomain.UnhandledException += OnAppDomainUnhandledException;
            try
            {
                base.StartRuntime();
            }
            catch (Exception exception)
            {
                HandleException(exception);
            }
        }

        private static void HandleException(Exception exception)
        {
            MessageBox.Show("Something has gone terribly wrong!", "Unhandled Exception", MessageBoxButton.OK, MessageBoxImage.Error);
            Environment.Exit(1);
        }

        protected override void OnUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            e.Handled = true;
            HandleException(e.Exception);
        }

        private static void OnAppDomainUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            HandleException(e.ExceptionObject as Exception);
        }
#endif
    }
}
