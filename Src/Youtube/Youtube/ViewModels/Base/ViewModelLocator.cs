using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Services;

using Unity.Lifetime; //using Microsoft.Practices.ServiceLocation;
using Unity; //using Microsoft.Practices.Unity;

using Youtube.DataServices;
using Youtube.DataServices.Base;
using Youtube.DataServices.Interfaces;
using Youtube.Services;
using Youtube.Services.Interfaces;
using Splat;
using System.Diagnostics;

namespace Youtube.ViewModels.Base
{
    public class ViewModelLocator
    {
        private readonly IUnityContainer _unityContainer;

        private static readonly ViewModelLocator _instance = new ViewModelLocator();

        public static ViewModelLocator Instance
        {
            get { return _instance; }
        }

        protected ViewModelLocator()
        {
            _unityContainer = new UnityContainer();

            //providers
            _unityContainer.RegisterType<IRequestProvider, RequestProvider>();
            _unityContainer.RegisterType<IPageDialogService, PageDialogService>();
            _unityContainer.RegisterType<IDialogService, DialogService>();

            //_unityContainer.RegisterType<IServiceLocator,Location>()

            // Reg. Nav. Service
            RegisterSingleton<INavigationService, NavigationService>();
            
            //Data Services
            _unityContainer.RegisterType<IAuthenticationService, AuthenticationService>();
            _unityContainer.RegisterType<IProfileService, ProfileService>();
            _unityContainer.RegisterType<ITrendingService, TrendingService>();
            _unityContainer.RegisterType<IVideoService, VideoService>();
            
            //View Models
            _unityContainer.RegisterType<LoginViewModel>();
            _unityContainer.RegisterType<MainViewModel>();
            _unityContainer.RegisterType<MenuViewModel>();
            _unityContainer.RegisterType<HomeViewModel>();
            _unityContainer.RegisterType<VideoViewModel>();
        }

        public T Resolve<T>()
        {
            return _unityContainer.Resolve<T>();
        }

        public object Resolve(Type type)
        {
            try
            {
                return _unityContainer.Resolve(type);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("[ex] unityContainer.Resolve error: " + ex.Message);
                throw;
            }
        }

        public void Register<T>(T instance)
        {
            _unityContainer.RegisterInstance<T>(instance);
        }

        public void Register<TInterface, T>() where T : TInterface
        {
            _unityContainer.RegisterType<TInterface, T>();
        }

        public void RegisterSingleton<TInterface, T>() where T : TInterface
        {
            _unityContainer.RegisterType<TInterface, T>(new ContainerControlledLifetimeManager());
        }
    }
}
