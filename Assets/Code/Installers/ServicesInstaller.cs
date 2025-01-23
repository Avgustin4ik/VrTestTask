namespace Code.Installers
{
    using Core.Abstract.Service;
    using Reflex.Core;
    using Reflex.Injectors;
    using UnityEngine;
    //todo перенести в немобеховский инсталлер (инсталер проекта например)
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
                containerBuilder.AddSingleton(service);
            }
        }
    }
}