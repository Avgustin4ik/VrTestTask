namespace Code.Core.Service
{
    using Reflex.Attributes;
    using Spawner;
    using UnityEngine;
    using UnityEngine.AddressableAssets;

    [CreateAssetMenu (menuName = "PGD/Service/SpawnService", fileName = "SpawnService", order = 0)]
    public class SpawnServiceSource : ServiceSource<SpawnService>
    {
        public AssetReference[] AssetReferences;
        [Inject]
        protected override SpawnService CreateServiceInstance()
        {
            return new SpawnService(AssetReferences);
        }
    }
}