namespace Code.Core.UiService
{
    using System;
    using System.Collections.Generic;
    using Abstract;
    using Abstract.Service;
    using Sirenix.OdinInspector;
    using UnityEngine;
    using UnityEngine.AddressableAssets;
    
    [CreateAssetMenu (menuName = "PGD/Service/UI Service", fileName = "UiService", order = 0)]

    public class UiServiceSource : ServiceSource<UiService>
    {
        [OnCollectionChanged("TryUpdateAssetsDatabase")]
        public AssetReference[] AssetReferences;
    
        private Dictionary<Type,AssetReference> _assetCollection;
        [Button]
        private bool TryUpdateAssetsDatabase()
        {
            _assetCollection ??= new Dictionary<Type, AssetReference>();
            var isAllLoaded = true;
            foreach (var assetReference in AssetReferences)
            {
                var asyncOperationHandle = assetReference.LoadAssetAsync<GameObject>();
                var gameObject = asyncOperationHandle.WaitForCompletion();
                var assetType = default(Type);
                try
                {
                    assetType = gameObject.TryGetComponent(out BaseView baseView) ? baseView.GetType() : null;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    isAllLoaded = false;
                }
                finally
                {
                    asyncOperationHandle.Release();
                    _assetCollection.TryAdd(assetType, assetReference);
                }
            }

            foreach (var value in _assetCollection)
            {
                Debug.Log($"Key: {value.Key}, Value: {value.Value}");
            }
            return isAllLoaded;
        }

        protected override UiService CreateServiceInstance()
        {
            if(_assetCollection == null)
                TryUpdateAssetsDatabase();
            return new UiService(_assetCollection);//инжектировать сюда словарь?
        }
    }
}