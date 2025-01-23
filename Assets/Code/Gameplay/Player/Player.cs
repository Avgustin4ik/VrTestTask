namespace Code.Gameplay.Player
{
    using System;
    using Core.Factories;
    using UniRx;
    using UnityEngine;

    public class Player : MonoBehaviour, IDisposable
    {
        private readonly ControlScheme _controlScheme;
        private readonly UIFactory _uiFactory;
        public Canvas canvas;
        
        public Player(ControlScheme controlScheme, UIFactory uiFactory)
        {
            _controlScheme = controlScheme;
            _uiFactory = uiFactory;
            
            _controlScheme.IsRightSecondaryButtonPressed
                .Throttle(TimeSpan.FromSeconds(0.5))
                .Where(isPressed => isPressed)
                .Subscribe(_ => CloseSelectionScreen());
            
            _controlScheme.IsRightPrimaryButtonPressed
                .Throttle(TimeSpan.FromSeconds(0.5))
                .Where(isPressed => isPressed)
                .Subscribe(_ => ShowSelectionScreen());
        }

        private void CloseSelectionScreen()
        {
            throw new NotImplementedException();
        }

        private void ShowSelectionScreen()
        {
            // _uiFactory.SpawnUIInstanceAsync()
        }

        public void Dispose()
        {
            
        }
    }
}