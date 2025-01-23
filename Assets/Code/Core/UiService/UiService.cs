namespace Code.Core.UiService
{
    using System;
    using System.Collections.Generic;
    using Abstract;
    using Abstract.Service;
    using UnityEngine;
    using UnityEngine.AddressableAssets;

    public class UiService : Service, IUIService, IDisposable
    {
        private Dictionary<Type, AssetReferenceT<BaseView>> _uiAssets;
        
        public UiService(Dictionary<Type, AssetReferenceT<BaseView>> assetCollection)
        {
            _uiAssets = assetCollection;
        }
        public void Dispose()
        {
            // TODO release managed resources here
        }

        public GameObject GetUiPrefab<T>() where T : BaseView
        {
            throw new NotImplementedException();
        }

        public AssetReferenceT<BaseView> GetUiAssetReference<T>() where T : BaseView
        {
            throw new NotImplementedException();
        }
    }

    public interface IUIService
    {
        GameObject GetUiPrefab<T>() where T : BaseView;
        AssetReferenceT<BaseView> GetUiAssetReference<T>() where T : BaseView;
    }
}