namespace Code.Spawner
{
    using Cysharp.Threading.Tasks;
    using Reflex.Core;
    using Reflex.Injectors;
    using UnityEngine;
    using UnityEngine.AddressableAssets;

    public class PropsFactory
    {
        private readonly Container _container;

        public PropsFactory(Container container)
        {
            _container = container;
            //todo добавить инъекцию зависимостей
        }
        
        public async UniTask<GameObject> Create(AssetReference assetReference, Vector3 position = default, Quaternion rotation = default)
        {
            var task = Addressables.LoadAssetAsync<GameObject>(assetReference);
            await task;
            var prefab = task.Result;
            var instance = GameObject.Instantiate(prefab, Vector3.zero, Quaternion.identity);
            GameObjectInjector.InjectRecursive(instance, _container);
            return instance;
            //todo добавить создание пропов
        }
        
        public void Destroy()
        {
            //todo добавить удаление пропов
        }
    }
}