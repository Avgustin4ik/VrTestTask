namespace Code.Spawner
{
    using System.Collections.Generic;
    using Core.Service;
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
        
        public void Spawn(AssetReference assetReference, Vector3 position, Quaternion rotation)
        {
            throw new System.NotImplementedException();
        }
        
        public void Test()
        {
            Debug.Log("Test");
        }
    }
}