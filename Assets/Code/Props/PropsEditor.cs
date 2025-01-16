namespace Code.Props
{
    using System;
    using Player;
    using UniRx;
    using UnityEngine.XR.Interaction.Toolkit.Interactors.Visuals;

    public class PropsEditor : IDisposable
    {
        private readonly ControlScheme _controlScheme;
        private IPropsModel _selectedPropsModel;
        private readonly IDisposable _movementStream;

        public PropsEditor(ControlScheme controlScheme)
        {
            _controlScheme = controlScheme;
            _movementStream = Observable.EveryUpdate().Where(x=>_selectedPropsModel != null).Subscribe(_ =>
            {
                MoveSelectedProps();
            });
        }
        
        public void SelectProps(IPropsModel propsModel)
        {
            _selectedPropsModel = propsModel;
            _selectedPropsModel.IsInEditMode.Value = true;
        }
        
        public void DeselectProps()
        {
            _selectedPropsModel.IsInEditMode.Value = false;
            _selectedPropsModel = null;
        }
        
        public void MoveSelectedProps()
        {
            var endPointType = _controlScheme.RightInteractor.TryGetCurveEndPoint(out var endPoint);
            // if(endPointType != EndPointType.ValidCastHit) return;
            _selectedPropsModel.Position.Value = endPoint;
        }

        public void Dispose()
        {
            // TODO release managed
            _movementStream.Dispose();
        }
    }
}