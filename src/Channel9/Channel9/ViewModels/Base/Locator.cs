using Channel9.Services.Navigation;
using Channel9.Services.RssService;
using Microsoft.Practices.Unity;
using System;

namespace Channel9.ViewModels.Base
{
    public class Locator
    {
        private readonly IUnityContainer _container;

        private static readonly Locator _instance = new Locator();

        public static Locator Instance
        {
            get
            {
                return _instance;
            }
        }

        protected Locator()
        {
            _container = new UnityContainer();

            _container.RegisterType<INavigationService, NavigationService>();
            _container.RegisterType<IRssService, RssService>();

            _container.RegisterType<MenuViewModel>();
            _container.RegisterType<MainViewModel>();
            _container.RegisterType<HomeViewModel>();
        }

        public T Resolve<T>()
        {
            return _container.Resolve<T>();
        }

        public object Resolve(Type type)
        {
            return _container.Resolve(type);
        }
    }
}