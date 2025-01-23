namespace Code.Gameplay.Props
{
    using Core;
    using Core.Factories;
    using Cysharp.Threading.Tasks;
    using UnityEngine;
    using UnityEngine.AddressableAssets;

    public class EditablePropsFactory : PropsFactory
    {
        private readonly PropsEditor _propsEditor;
        public EditablePropsFactory(Injector injector, PropsEditor propsEditor) : base(injector)
        {
            _propsEditor = propsEditor;
        }

        public override async UniTask<TComponent> SpawnInstanceAsync<TComponent>(AssetReferenceT<TComponent> assetReference, Vector3 position = default,
            Quaternion rotation = default)
        {
            var instance = await base .SpawnInstanceAsync(assetReference, position, rotation);
            _propsEditor.SelectProps(instance.GetComponent<PropsMono>().Model);
            return instance;
        }

        public async UniTask<PropsMono> SpawnInstanceAsync(AssetReference assetReference, Vector3 position = default,
            Quaternion rotation = default)
        {
            var instance = await base.SpawnInstanceAsync(assetReference);

            if (!instance.TryGetComponent<PropsMono>(out var propsMono)) throw new System.Exception("PropsMono not found");
            _propsEditor.SelectProps(propsMono.Model);
            return propsMono;
        }
    }
}