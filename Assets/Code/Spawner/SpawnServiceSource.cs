namespace Code.Core.Service
{
    using System;
    using UnityEngine;
    using UnityEngine.AddressableAssets;
    using Object = System.Object;

    [CreateAssetMenu (menuName = "PGD/Service/SpawnService", fileName = "SpawnService", order = 0)]
    public class SpawnServiceSource : ServiceSource
    {
        public AssetReference[] AssetReferences;

        public SpawnService CreateService()
        {
            return new SpawnService(AssetReferences);
        }
    }
}