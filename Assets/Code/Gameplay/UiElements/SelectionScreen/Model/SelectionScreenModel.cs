namespace Code.UiElements.SelectionScreen.Model
{
    using UnityEngine.AddressableAssets;

    public class SelectionScreenModel : ISelectionScreen
    {
        public AssetReference SelectedAsset { get; }
    }
}