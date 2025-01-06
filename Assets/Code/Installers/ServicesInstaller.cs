namespace Code.Installers
{
    using Core.Service;
    using Reflex.Core;
    using UnityEngine;

    public class ServicesInstaller : MonoBehaviour, IInstaller
    {
        // public ServiceSource[] serviceSources;
        public SpawnServiceSource spawnService;
        public void InstallBindings(ContainerBuilder containerBuilder)
        {
#if DEBUG
            Debug.Log("ServicesInstaller InstallBindings");
#endif
            containerBuilder.AddSingleton(x => spawnService.CreateService());
        }
    }
}