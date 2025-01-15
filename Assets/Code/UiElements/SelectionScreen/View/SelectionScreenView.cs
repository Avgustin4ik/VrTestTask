namespace Code.Core.UiElements.SelectionScreen.View
{
    using System.Collections.Generic;
    using System.Linq;
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
    using UnityEngine.UI;

    public class SelectionScreenView : UiView<SelectionScreenModel>
    {
        //todo : refactor spawn to use asset reference
        [SerializeField] private SelectionPreviewView spawnButtonPrefab;
        [SerializeField] private Transform contentParent;
        public Button SpawnTestButton;
        [Inject] private SpawnService _spawnService;
        [Inject] private PropsFactory _propsFactory;
        [Inject] private UIFactory _uiFactory;
        [Inject]
        public override void Initialize(SelectionScreenModel model)
        {
            SpawnTestButton.OnClickAsObservable().Subscribe(x => SpawnTestAsset()).AddTo(this);
            SetupButtons(_spawnService.GetAssetReferences());
            SetDefaultState();
            // closeButton.Button.onClick.AsObservable().Subscribe(x => Close()).AddTo(this);
            base.Initialize(model);
        }

        private void SpawnTestAsset()
        {
            Debug.Log("SpawnTestAsset");
            var assetReference = _spawnService.GetAssetReferences().First();
            _propsFactory.SpawnInstanceAsync(assetReference);
        }

        private void SetupButtons(IEnumerable<AssetReference> refs)
        {
            foreach (var assetRef in refs)
            {
                var spawnUI = _uiFactory.SpawnUI(spawnButtonPrefab, contentParent);
                spawnUI.Model.AssetReference = assetRef;
                //todo : refactor spawn with models
            }
        }

        private void SetDefaultState()
        {
            // Hide();
        }
    }
}