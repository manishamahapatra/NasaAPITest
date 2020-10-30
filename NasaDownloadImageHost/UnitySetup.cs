using System.Linq;
using Microsoft.Practices.Unity;
using NasaAPIProject.NasaDownloadImageHost.Services;
using NasaAPIProject.Common;

namespace NasaAPIProject.NasaDownloadImageHost
{
    public static class UnitySetup
    {
       public static IUnityContainer Container;

        public static void RegisterComponents()
        {
            Container = new UnityContainer();
            Container.RegisterType(typeof(ISingletonDependency));
        }

        
        public static IUnityContainer GetContainer()
        {
            return Container;
        }

        public static T Resolve<T>()
        {
            return Container.Resolve<T>();
        }
    }
}
