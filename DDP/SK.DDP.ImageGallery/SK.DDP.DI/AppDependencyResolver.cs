using System;
using System.Collections.Generic;
using System.Web.Http.Dependencies;
using Microsoft.Practices.Unity;
using SK.DDP.BL;

namespace SK.DDP.DI
{
    public class AppDependencyResolver :
        System.Web.Mvc.IDependencyResolver, System.Web.Http.Dependencies.IDependencyResolver
    {
        private readonly IUnityContainer _container;

        public AppDependencyResolver()
        {
            _container = new UnityContainer();
            _container.RegisterType<IPhotoService, PhotoService>();
            _container.RegisterType<IUserManagementService, UserManagementService>();
        }

        public object GetService(Type serviceType)
        {
            try
            {
                return _container.Resolve(serviceType);
            }
            catch (ResolutionFailedException)
            {
                return null;
            }
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            try
            {
                return _container.ResolveAll(serviceType);
            }
            catch (ResolutionFailedException)
            {
                return null;
            }
        }

        public IDependencyScope BeginScope()
        {
            return new AppDependencyResolver();
        }

        public void Dispose()
        {
            _container.Dispose();
        }
    }
}
