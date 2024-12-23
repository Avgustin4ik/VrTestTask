namespace Code.Core.UiElements.CloseButton.View
{
    using Abstract;
    using Extentions;
    using UniRx;
    using UnityEngine.UI;
    public class CloseButtonView : UiView<CloseButtonModel>
    {
        public Button Button;
        public BaseView TargetView;
        protected override void Initialize(CloseButtonModel model)
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