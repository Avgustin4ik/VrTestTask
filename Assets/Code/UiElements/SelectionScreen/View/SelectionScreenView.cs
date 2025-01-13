namespace Code.Core.UiElements.SelectionScreen.View
{
    using System.Collections.Generic;
    using CloseButton.View;
    using Code.Core.Abstract;
    using Code.Core.SelectionScreen.Model;
    using Code.UiElements.SelectionScreen.SelectionPreview;
    using Reflex.Attributes;
    using Reflex.Injectors;
    using Spawner;
    using UniRx;
    using UnityEngine;
    using UnityEngine.AddressableAssets;

    public class SelectionScreenView : UiView<SelectionScreenModel>
    {
        //todo : refactor spawn to use asset reference
        [SerializeField] private SelectionPreviewView spawnButtonPrefab;
        [SerializeField] private Transform contentParent;
        [Inject] private SpawnService _spawnService;
        
        [Inject]
        public override void Initialize(SelectionScreenModel model)
        {
            SetupButtons(_spawnService.GetAssetReferences());
            SetDefaultState();
            // closeButton.Button.onClick.AsObservable().Subscribe(x => Close()).AddTo(this);
            base.Initialize(model);
        }

        private void SetupButtons(IEnumerable<AssetReference> refs)
        {
            foreach (var assetRef in refs)
            {
                var model = new SelectionPreviewViewModel
                {
                    AssetReference = assetRef
                };
                //todo : refactor spawn with models
                var button = Instantiate(spawnButtonPrefab, contentParent);
                button.Initialize(model);
            }
        }

        private void SetDefaultState()
        {
            // Hide();
        }
    }
}