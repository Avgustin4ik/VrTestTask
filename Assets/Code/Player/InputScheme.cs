namespace Code.Installers
{
    using System;
    using UnityEngine;
    using UnityEngine.InputSystem;
    using UnityEngine.XR.Interaction.Toolkit.Interactors;

    [Serializable]
    public struct InputScheme
    {
        public NearFarInteractor rightInteractor;
        public NearFarInteractor leftInteractor;
        [Space(10)]
        [Header("Right Hand")]
        public InputActionReference rHandPrimaryButtonRef;
        public InputActionReference rHandSecondaryButtonRef;
        public InputActionReference rTriggerActionRef;
    }
}