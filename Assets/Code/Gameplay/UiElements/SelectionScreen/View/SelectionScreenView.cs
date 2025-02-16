namespace Code.Gameplay.UiElements.SelectionScreen.View
{
    using System;
    using System.Collections.Generic;
    using Code.Core.Abstract;
    using Code.Core.Factories;
    using Code.Gameplay.Player;
    using Code.Gameplay.Spawner;
    using Code.UiElements.SelectionScreen.Model;
    using Code.UiElements.SelectionScreen.SelectionPreview;
    using Cysharp.Threading.Tasks;
    using Reflex.Attributes;
    using UniRx;
    using UnityEngine;
    using UnityEngine.AddressableAssets;

    public class SelectionScreenView : UiView<SelectionScreenModel>
    {
        //todo : refactor spawn to use asset reference
        [SerializeField] private SelectionPreviewView spawnButtonPrefab;
        [SerializeField] private Transform contentParent;
        
        [Inject] private SpawnService _spawnService;
        [Inject] private PropsFactory _propsFactory;
        [Inject] private UIFactory _uiFactory;
        [Inject] private ControlScheme _controlScheme;
        
        [Inject]
        public override void Initialize(SelectionScreenModel model)
        {
            SetupButtons(_spawnService.GetAssetReferences());
            SetDefaultState();
            _controlScheme.IsRightSecondaryButtonPressed
                .Throttle(TimeSpan.FromSeconds(0.5))
                .Where(isPressed => isPressed)
                .Subscribe(_ => Hide());
            base.Initialize(model);
        }
        
        private async UniTaskVoid SetupButtons(IEnumerable<AssetReference> refs)
        {
            foreach (var assetRef in refs)
            {
                var uiView = await _uiFactory.SpawnUIInstanceAsync<SelectionPreviewView>(contentParent);
                uiView.Model.AssetReference = assetRef;
                // todo : refactor spawn with models
            }
        }

        private void SetDefaultState()
        {
        }
    }
}