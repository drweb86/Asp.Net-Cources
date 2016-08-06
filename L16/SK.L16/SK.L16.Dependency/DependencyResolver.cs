using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using SK.L16.Bl;
using SK.L16.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SK.L16.Dependency
{
    public class DependencyResolver : IDependencyResolver
    {
        private readonly IUnityContainer _unityContainer = new UnityContainer();

        public DependencyResolver()
        {
            _unityContainer.RegisterType<IPhotoService, PhotoService>();
            _unityContainer.RegisterType<IContext, Context>();
        }

        public object GetService(Type serviceType)
        {
            try
            {
                return _unityContainer.Resolve(serviceType);
            }
            catch
            {
                return null;
            }
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            try
            {
                return _unityContainer.ResolveAll(serviceType);
            }
            catch
            {
                return null;
            }
        }
    }
}
