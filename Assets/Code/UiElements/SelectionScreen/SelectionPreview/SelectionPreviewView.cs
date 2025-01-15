namespace Code.UiElements.SelectionScreen.SelectionPreview
{
    using Code.Core.Abstract;
    using Core;
    using PrimeTween;
    using Reflex.Attributes;
    using Reflex.Core;
    using Reflex.Injectors;
    using Spawner;
    using UniRx;
    using UnityEngine;
    using UnityEngine.AddressableAssets;
    using UnityEngine.EventSystems;
    using UnityEngine.UI;

    public class SelectionPreviewView : UiView<SelectionPreviewViewModel>, IPointerEnterHandler, IPointerExitHandler
    {
        #region animations
        [Header("animation settings")]
        [Range(1, 1.5f)]
        public float highlightScale = 1.2f;
        public float durationInSeconds = 0.2f;
        public Ease ease = Ease.OutSine;
        #endregion
        
        public Button button;
        private Vector3 _defaultScale;
        [Inject] private PropsFactory _propsFactory;
        Container _container;
        
        [Inject]
        public override void Initialize(SelectionPreviewViewModel model)
        {
            _container ??= ContainerDi.Builder.Parent;
            button.OnClickAsObservable().Subscribe(x => OnModelPicked()).AddTo(this);
            _defaultScale = transform.localScale;
            base.Initialize(model);
        }

        public void Start()
        {
            var builderParent = ContainerDi.Builder.Parent;
        }

        private void OnModelPicked()
        {
            _propsFactory.SpawnInstanceAsync(Model.AssetReference);
        }

        public void Highlight(bool isHighlighted = true)
        {
            Tween.Scale(
                transform,
                isHighlighted ? _defaultScale*highlightScale : _defaultScale,
                durationInSeconds,ease);
        }


        public void OnPointerEnter(PointerEventData eventData)
        {
            Highlight();
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            Highlight(false);
        }
    }

    public class SelectionPreviewViewModel : IModel
    {
        public AssetReference AssetReference;
    }
}