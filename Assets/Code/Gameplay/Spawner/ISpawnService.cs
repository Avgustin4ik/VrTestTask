namespace Code.Gameplay.Spawner
{
    using System.Collections.Generic;
    using UnityEngine.AddressableAssets;

    public interface ISpawnService
    {
        IEnumerable<AssetReference> GetAssetReferences();
    }
}