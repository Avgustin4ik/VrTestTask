namespace Code.Core.Factories
{
    using Code.Core;
    using Cysharp.Threading.Tasks;
    using UnityEngine;
    using UnityEngine.AddressableAssets;

    public class PropsFactory
    {
        private readonly Injector _injector;
        public PropsFactory(Injector injector)
        {
            _injector = injector;
            //todo добавить инъекцию зависимостей
        }
        
        public virtual async UniTask<GameObject> SpawnInstanceAsync(AssetReference assetReference, Vector3 position = default, Quaternion rotation = default)
        {
            var task = Addressables.LoadAssetAsync<GameObject>(assetReference);
            await task;
            var prefab = task.Result;
            var instance = GameObject.Instantiate(prefab, position, rotation);
            _injector.Inject(instance);
            return instance;
        }
        public virtual async UniTask<TComponent> SpawnInstanceAsync<TComponent>(AssetReferenceT<TComponent> assetReference, Vector3 position = default, Quaternion rotation = default) where TComponent : Component
        {
            var task = Addressables.LoadAssetAsync<TComponent>(assetReference);
            await task;
            var prefab = task.Result;
            var instance = GameObject.Instantiate(prefab, position, rotation).GetComponent<TComponent>();
            _injector.Inject(instance);
            return instance;
        }
        public void Destroy()
        {
            //todo добавить удаление пропов
        }
    }
}