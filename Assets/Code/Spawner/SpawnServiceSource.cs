namespace Code.Spawner
{
    using Reflex.Attributes;
    using UnityEngine;
    using UnityEngine.AddressableAssets;

    [CreateAssetMenu (menuName = "PGD/Service/SpawnService", fileName = "SpawnService", order = 0)]
    public class SpawnServiceSource : ServiceSource<SpawnService>
    {
        public AssetReference[] AssetReferences;
        protected override SpawnService CreateServiceInstance()
        {
            return new SpawnService(AssetReferences);
        }
    }
}