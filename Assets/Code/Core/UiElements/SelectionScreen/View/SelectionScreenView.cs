namespace Code.Core.UiElements.SelectionScreen.View
{
    using Code.Core.Abstract;
    using Code.Core.SelectionScreen.Model;
    using UnityEngine;

    public class SelectionScreenView : UiView<SelectionScreenModel>
    {
        protected override void Initialize(SelectionScreenModel model)
        {
            SetDefaultState();
            base.Initialize(model);
        }

        private void SetDefaultState()
        {
            Hide();
        }
    }
}