namespace Code.UiElements.CloseButton.View
{
    using Core.Abstract;
    using Core.Extentions;
    using Model;
    using Reflex.Attributes;
    using UniRx;
    using UnityEngine.UI;

    public class CloseButtonView : UiView<CloseButtonModel>
    {
        public Button Button;
        public BaseView TargetView;
        [Inject]
        public override void Initialize(CloseButtonModel model)
        {
            Button.onClick.AsObservable().Subscribe(_ => HideWindow());
            base.Initialize(model);
            TargetView ??= gameObject.GetParentComponent<BaseView>();
        }
        private void HideWindow()
        {
            TargetView.Hide();
        }
    }
}