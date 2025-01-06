namespace Code.Core.UiElements.SelectionScreen.View
{
    using System.Collections.Generic;
    using Code.Core.Abstract;
    using Code.Core.SelectionScreen.Model;
    using Reflex.Attributes;
    using SelectionPreview;
    using Service;
    using UnityEngine;

    public class SelectionScreenView : UiView<SelectionScreenModel>
    {
        //todo : refactor spawn to use asset reference
        [SerializeField] private SelectionPreviewView _spawnButtonPrefab;
        [SerializeField] private Transform _contentParent;
        [Inject] SpawnService _spawnService;
        public override void Initialize(SelectionScreenModel model)
        {
            base.Initialize(model);
            // SetupButtons(_spawnService.GetAssetReferences());
            SetDefaultState();
        }

        private void SetupButtons(IEnumerable<string> refs)
        {
            foreach (var assetRef in refs)
            {
                var model = new SelectionPreviewViewModel
                {
                    AssetReference = assetRef
                };
                //todo : refactor spawn
                var instantiate = Instantiate(_spawnButtonPrefab, _contentParent);
                instantiate.Initialize(model);
            }
        }

        private void SetDefaultState()
        {
            // Hide();
        }
    }
}