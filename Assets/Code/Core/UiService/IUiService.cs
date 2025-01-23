namespace Code.Core.UiService
{
    using Abstract;
    using UnityEngine;
    using UnityEngine.AddressableAssets;

    public interface IUiService
    {
        GameObject GetUiPrefab<T>() where T : BaseView;
        AssetReference GetUiAssetReference<T>() where T : BaseView;
    }
}