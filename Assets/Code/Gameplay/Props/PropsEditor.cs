namespace Code.Gameplay.Props
{
    using System;
    using System.Collections.Generic;
    using Player;
    using UniRx;
    using UnityEngine;

    public class PropsEditor : IDisposable
    {
        private readonly ControlScheme _controlScheme;
        private IPropsModel _selectedPropsModel;
        private readonly IDisposable _movementStream;
        private readonly IDisposable _rotationStream;
        private readonly IObservable<long> _observableUpdate;
        private readonly IObservable<long> _testUpdate;

        private List<IDisposable> _disposables = new List<IDisposable>();

        public PropsEditor(ControlScheme controlScheme)
        {
            _controlScheme = controlScheme;
            _observableUpdate = Observable.EveryUpdate()
                .Where(x => _selectedPropsModel != null);
            _movementStream = _observableUpdate.Subscribe(_ => MoveSelectedProps())
                .AddTo(_disposables);

            _controlScheme.IsRightTriggerPressed
                .ThrottleFirst(TimeSpan.FromSeconds(0.5f))
                .Where(_ => _selectedPropsModel != null)
                .Subscribe(x => ConfirmSpawn())
                .AddTo(_disposables);
            
            _controlScheme.IsRightSecondaryButtonPressed
                .ThrottleFirst(TimeSpan.FromSeconds(0.5f))
                .Where(_ => _selectedPropsModel != null)
                .Subscribe(x => CancelSpawn())
                .AddTo(_disposables);
            
        }

        private void CancelSpawn()
        {
            
            _selectedPropsModel.Despawn.Execute(true);
            DeselectProps();
        }

        private void ConfirmSpawn()
        {
            if (_selectedPropsModel == null)
                return;
            _selectedPropsModel.IsInEditMode.Value = false;
            Debug.Log("Confirm Spawn");
            DeselectProps();
        }

        public void SelectProps(IPropsModel propsModel)
        {
            _selectedPropsModel = propsModel;
            _selectedPropsModel.IsInEditMode.Value = true;
        }

        public void SetProps(Vector3 position,
            Quaternion rotation)
        {
            _selectedPropsModel.Position.Value = position;
            _selectedPropsModel.Rotation.Value = rotation;
            DeselectProps();
        }


        private void DeselectProps()
        {
            _selectedPropsModel.IsInEditMode.Value = false;
            _selectedPropsModel = null;
        }

        private void MoveSelectedProps()
        {
            var endPointType = _controlScheme.RightInteractor.TryGetCurveEndPoint(out var endPoint);
            _selectedPropsModel.Position.Value = endPoint;
        }

        public void RotateAroundY(float angle)
        {
            _selectedPropsModel.Rotation.Value = Quaternion.Euler(0,
                angle,
                0);
        }

        public void Dispose()
        {
            // TODO release managed
            _movementStream.Dispose();
        }
    }
}