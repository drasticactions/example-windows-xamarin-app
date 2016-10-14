namespace example_windows_app.ViewModels
{
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Threading.Tasks;
    using Bezysoftware.Navigation;
    using Bezysoftware.Navigation.Lookup;
    using Bezysoftware.Navigation.Platform;
    using Bezysoftware.Navigation.StatePersistence;
    using example_windows_app.Tools;
    using Microsoft.Practices.ServiceLocation;
    using Microsoft.Practices.Unity;

    public class ViewModelLocator
    {
        static ViewModelLocator()
        {
            var unity = new UnityContainer();

            ServiceLocator.SetLocatorProvider(() => new UnityServiceLocator(unity));

            unity
                .RegisterType<INavigationService, NavigationService>(new ContainerControlledLifetimeManager())
                .RegisterType<IViewLocator, ViewLocator>(new ContainerControlledLifetimeManager())
                .RegisterType<IViewModelLocator, ViewModelServiceLocator>(new ContainerControlledLifetimeManager())
                .RegisterType<IPlatformNavigator, PlatformNavigator>(new ContainerControlledLifetimeManager())
                .RegisterType<IApplicationFrameProvider, CurrentWindowFrameProvider>(new ContainerControlledLifetimeManager())
                .RegisterType<IStatePersistor, StatePersistor>(new ContainerControlledLifetimeManager())
                .RegisterType<IAssemblyResolver, ThisAssemblyResolver>(new ContainerControlledLifetimeManager())
                .RegisterInstance(typeof(TaskScheduler), TaskScheduler.Default)
                .RegisterType<INavigationInterceptor, AdaptiveNavigationInterceptor>("Adaptive", new ContainerControlledLifetimeManager())
                .RegisterType<IEnumerable<INavigationInterceptor>, INavigationInterceptor[]>(new ContainerControlledLifetimeManager())
                .RegisterType<MainPageViewModel>(new ContainerControlledLifetimeManager())
                .RegisterType<ArticlePageViewModel>(new ContainerControlledLifetimeManager());

            // manually register association for the main page to speed up application startup
            unity.Resolve<IViewLocator>().RegisterAssociation<MainPageViewModel, MainPage>();

            ServiceLocator.Current.GetInstance<INavigationService>().Navigated += ViewModelLocator_Navigated;
        }

        public static void Init()
        { }

        public MainPageViewModel Main => ServiceLocator.Current.GetInstance<MainPageViewModel>();

        public ArticlePageViewModel Article => ServiceLocator.Current.GetInstance<ArticlePageViewModel>();

        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }

        private static void ViewModelLocator_Navigated(object sender, NavigationEventArgs e)
        {
            Debug.WriteLine(e.ViewModelType);
        }
    }

}
