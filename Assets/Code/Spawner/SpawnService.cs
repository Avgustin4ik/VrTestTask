namespace Code.Core.Service
{
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.AddressableAssets;

    public class SpawnService : Service, ISpawnService
    {
        private readonly IEnumerable<AssetReference> _assets;
        
        public SpawnService(IEnumerable<AssetReference> assets)
        {
            _assets = assets;
        }

        public IEnumerable<AssetReference> GetAssetReferences()
        {
            return _assets;
        }
        
        public void Test()
        {
            Debug.Log("Test");
        }
    }
}