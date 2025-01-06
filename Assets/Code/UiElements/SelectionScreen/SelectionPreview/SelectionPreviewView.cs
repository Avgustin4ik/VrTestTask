namespace Code.Core.UiElements.SelectionScreen.SelectionPreview
{
    using Abstract;
    using PrimeTween;
    using UnityEngine;

    public class SelectionPreviewView : UiView<SelectionPreviewViewModel>
    {
        private Vector3 _defaultScale;
        [Header("animation settings")]
        [Range(1, 1.5f)]
        public float highlightScale = 1.2f;
        public float durationInSeconds = 0.2f;
        public Ease ease = Ease.OutSine;
        public override void Initialize(SelectionPreviewViewModel model)
        {
            _defaultScale = transform.localScale;
            base.Initialize(model);
        }
        
        public void Highlight(bool isHighlighted = true)
        {
            Tween.Scale(
                transform,
                isHighlighted ? _defaultScale*highlightScale : _defaultScale,
                durationInSeconds,ease);
        }
    }

    public class SelectionPreviewViewModel : IModel
    {
        public string AssetReference;
    }
}