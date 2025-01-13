namespace Code.Spawner
{
    using System;
    using System.Collections.Generic;
    using Core.Service;
    using Cysharp.Threading.Tasks;
    using UnityEngine;
    using UnityEngine.AddressableAssets;
    
    public class SpawnService : Service, ISpawnService, IDisposable
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
        
        private List<AssetReference> _assetReferences = new List<AssetReference>();
        
        public async UniTask Spawn(AssetReference assetReference, Vector3 position, Quaternion rotation)
        {
            var task = Addressables.LoadAssetAsync<GameObject>(assetReference);
            await task;
            var taskResult = task.Result;
            var instance = GameObject.Instantiate(taskResult, position, rotation);
        }
        
        public void Test()
        {
            Debug.Log("Test");
        }

        public void Dispose()
        {
            foreach (var assetReference in _assetReferences)
            {
                assetReference.ReleaseAsset();
            }
        }
    }
}