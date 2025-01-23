namespace Code.UiElements.SelectionScreen.Model
{
    using Core.Abstract;
    using UnityEngine.AddressableAssets;

    public interface ISelectionScreen : IModel
    {
        public AssetReference SelectedAsset { get; }
        
    }
}