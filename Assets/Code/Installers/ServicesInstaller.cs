namespace Code.Installers
{
    using Reflex.Core;
    using UnityEngine;

    public class ServicesInstaller : MonoBehaviour, IInstaller
    {
        public ServiceSourceBase[] serviceSources;
        public void InstallBindings(ContainerBuilder containerBuilder)
        {
#if DEBUG
            Debug.Log("ServicesInstaller InstallBindings");
#endif
            foreach (var sourceBase in serviceSources)
            {
                var service = sourceBase.CreateService();
                Debug.Log("sourceBase: " + service.GetType());
                containerBuilder.AddSingleton(service, service.GetType());
            }
        }
    }
    
    public class TestMonoBehaviour<T> : MonoBehaviour
    {
        public T Test()
        {
            return default;
        }
    }
}