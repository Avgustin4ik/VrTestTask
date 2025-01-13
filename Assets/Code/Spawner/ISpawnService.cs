namespace Code.Core.Service
{
    using System.Collections.Generic;
    using UnityEngine.AddressableAssets;

    public interface ISpawnService
    {
        IEnumerable<AssetReference> GetAssetReferences();
    }
}