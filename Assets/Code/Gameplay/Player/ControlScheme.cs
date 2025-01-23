namespace Code.Gameplay.Player
{
    using System;
    using UniRx;
    using UnityEngine.XR;
    using UnityEngine.XR.Interaction.Toolkit.Interactors;
    using InputDevice = UnityEngine.XR.InputDevice;

    public class ControlScheme : IDisposable
    {
        private readonly InputScheme _input;
        private readonly IDisposable _controlStream;
        public InputDevice RightController { get; set; }
        public NearFarInteractor RightInteractor => _input.rightInteractor;
        
        public BoolReactiveProperty IsRightTriggerPressed { get; } = new BoolReactiveProperty();
        public BoolReactiveProperty IsRightPrimaryButtonPressed { get; } = new BoolReactiveProperty();
        public BoolReactiveProperty IsRightSecondaryButtonPressed { get; } = new BoolReactiveProperty();
        
        
        public ControlScheme(InputScheme inputScheme)
        {
            _input = inputScheme;
            _controlStream = Observable.EveryUpdate()
                .Subscribe(x => UpdateControl());
        }

        private void UpdateControl()
        {
            IsRightTriggerPressed.Value = _input.rTriggerActionRef.action.IsPressed();
            IsRightPrimaryButtonPressed.Value = _input.rHandPrimaryButtonRef.action.IsPressed();
            IsRightSecondaryButtonPressed.Value = _input.rHandSecondaryButtonRef.action.IsPressed();
        }

        private void OnDeviceDisconnected(InputDevice obj)
        {
            if (obj.characteristics.HasFlag(InputDeviceCharacteristics.Right))
            {
                #if DEBUG
                UnityEngine.Debug.Log("Right Controller Disconnected");
                #endif
            }
        }

        private void OnDeviceConnected(InputDevice device)
        {
            SetupRightControllerActions(device);
        }

        private void SetupRightControllerActions(InputDevice device)
        {
#if DEBUG
            UnityEngine.Debug.Log($"Device name: {device.name} with role: {device.role}");
#endif
            if (!device.characteristics.HasFlag(InputDeviceCharacteristics.Right)) return;
            RightController = device;
        }


        public void Dispose()
        {
            InputDevices.deviceConnected -= OnDeviceConnected;
            InputDevices.deviceDisconnected -= OnDeviceDisconnected;
            _controlStream.Dispose();
        }
    }
}