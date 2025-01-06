namespace Code.Core.Service
{
    using System.Collections.Generic;
    using UnityEngine.AddressableAssets;

    internal interface ISpawnService
    {
        IEnumerable<AssetReference> GetAssetReferences();
    }
}