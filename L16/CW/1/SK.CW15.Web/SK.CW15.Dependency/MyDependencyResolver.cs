using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Contexts;
using System.Web.Mvc;
using SK.CW15.Bl;

namespace SK.CW15.Dependency
{
    public class MyDependencyResolver :
        IDependencyResolver
    {
        readonly IUnityContainer _container;

        public MyDependencyResolver()
        {
            _container = new UnityContainer();
            _container.RegisterType<IShopService, ShopService>();
        }

        public object GetService(Type serviceType)
        {
            try
            {
                return _container.Resolve(serviceType);
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
                return _container.ResolveAll(serviceType);
            }
            catch
            {
                return null;
            }
        }
    }
}
