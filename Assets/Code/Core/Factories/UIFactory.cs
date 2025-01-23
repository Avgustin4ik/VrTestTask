namespace Code.Core.Factories
{
    using Code.Core;
    using Cysharp.Threading.Tasks;
    using UnityEngine;
    using UnityEngine.AddressableAssets;

    public class UIFactory
    {
        private readonly Injector _injector;
        public UIFactory(Injector injector)
        {
            _injector = injector;
        }
        
        public async UniTask<TObject> SpawnUIInstanceAsync<TObject>(AssetReference assetReference, Transform parent, Vector3 position = default, Quaternion rotation = default) where TObject : UnityEngine.Object
        {
            var task = Addressables.LoadAssetAsync<GameObject>(assetReference);
            await task;
            var prefab = task.Result;
            var instance = GameObject.Instantiate<TObject>(prefab.GetComponent<TObject>(),parent);
            _injector.Inject(instance);
            return instance;
        }
        
        public TObject SpawnUI<TObject>(TObject uiPrefab, Transform parent, Vector3 position = default, Quaternion rotation = default) where TObject : UnityEngine.Object
        {
            var instance = GameObject.Instantiate(uiPrefab, parent);
            _injector.Inject(instance);
            return instance;
        }
    }
}