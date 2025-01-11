namespace Code.Core.SelectionScreen.Model
{
    using Abstract;
    using UnityEngine.AddressableAssets;

    public class SelectionScreenModel : ISelectionScreen
    {
        public AssetReference SelectedAsset { get; }
    }
}