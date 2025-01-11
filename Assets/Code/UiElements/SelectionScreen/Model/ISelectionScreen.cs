namespace Code.Core.SelectionScreen.Model
{
    using Abstract;
    using UnityEngine.AddressableAssets;

    public interface ISelectionScreen : IModel
    {
        public AssetReference SelectedAsset { get; }
        
    }
}