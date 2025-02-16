namespace Code.Core.Factories
{
    using Abstract;
    using Code.Core;
    using Cysharp.Threading.Tasks;
    using UiService;
    using UnityEngine;

    public class UIFactory : PropsFactory
    {
        private readonly IUiService _uiService;

        public UIFactory(Injector injector, IUiService uiService) : base(injector)
        {
            _uiService = uiService;
        }

        public async UniTask<T> SpawnUIInstanceAsync<T>(
            Transform parent,
            Vector3 position = default,
            Quaternion rotation = default) where T : BaseView
        {
            var uiAssetReference = _uiService.GetUiAssetReference<T>();
            var baseView = await base.SpawnInstanceAsync(uiAssetReference);
            var instance = baseView.GetComponent<T>();
            instance.transform.SetParent(parent);
            instance.transform.localPosition = position;
            instance.transform.localRotation = rotation;
            instance.transform.localScale = Vector3.one;
            return instance;
        }
    }
}