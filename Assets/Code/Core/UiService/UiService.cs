namespace Code.Core.UiService
{
    using System;
    using System.Collections.Generic;
    using Abstract;
    using Abstract.Service;
    using UnityEngine;
    using UnityEngine.AddressableAssets;

    public class UiService : Service, IUiService, IDisposable
    {
        private Dictionary<Type, AssetReference> _uiAssets;
        
        public UiService(Dictionary<Type, AssetReference> assetCollection)
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

        public AssetReference GetUiAssetReference<T>() where T : BaseView
        {
            return _uiAssets[typeof(T)];
        }
    }
}