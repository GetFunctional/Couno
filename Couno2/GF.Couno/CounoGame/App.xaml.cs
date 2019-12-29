using System.Reflection;
using System.Windows;
using CounoGame.Shared.Mvvm.DataTemplates;
using CounoGame.Shared.Mvvm.ViewModels;
using CounoGame.UI.Content;
using LightInject;

namespace CounoGame
{
    /// <summary>
    ///     Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly Assembly ApplicationAssembly = typeof(App).Assembly;

        public IServiceContainer DiContainer { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Registering Types used by the application
            var container = this.SetupDependencyInjectionContainer();
            this.DiContainer = container;

            // Registering Default DataTemplates using IViewFor Mechanic
            var dataTemplates = this.AggregateDataTemplatesForViews();
            Current.Resources.MergedDictionaries.Add(dataTemplates);

            // Creating Shell Window of Application
            var shell = new ShellWindow(container.Create<ShellViewModel>());
            Current.MainWindow = shell;
            Current.ShutdownMode = ShutdownMode.OnMainWindowClose;
            shell.Show();

        }

        private ResourceDictionary AggregateDataTemplatesForViews()
        {
            var generator = new ViewDataTemplateGenerator();
            var dataTemplates = generator.GetDataTemplatesFrom(ApplicationAssembly);
            return dataTemplates;
        }

        private IServiceContainer SetupDependencyInjectionContainer()
        {
            var lightInjectContainer = new ServiceContainer();

            // Register all Types of ViewModels
            lightInjectContainer.RegisterAssembly(ApplicationAssembly,
                (s, _) => !s.IsAssignableFrom(typeof(IViewModel)));

            return lightInjectContainer;
        }
    }
}