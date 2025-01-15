namespace Code.Spawner
{
    using System;
    using Core;
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
        
        public async UniTask<GameObject> SpawnInstanceAsync(AssetReference assetReference, Vector3 position = default, Quaternion rotation = default)
        {
            var task = Addressables.LoadAssetAsync<GameObject>(assetReference);
            await task;
            var prefab = task.Result;
            var instance = GameObject.Instantiate(prefab, position, rotation);
            _injector.Inject(instance);
            return instance;
        }
        
        public void Destroy()
        {
            //todo добавить удаление пропов
        }
    }
}