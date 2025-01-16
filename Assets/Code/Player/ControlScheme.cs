namespace Code.Player
{
    using UnityEngine.XR.Interaction.Toolkit.Interactors;

    public class ControlScheme
    {
        public NearFarInteractor RightInteractor { get; }
        public NearFarInteractor LeftInteractor { get; }

        public ControlScheme(
            NearFarInteractor rightInteractor,
            NearFarInteractor leftInteractor
        )
        {
            RightInteractor = rightInteractor;
            LeftInteractor = leftInteractor;
        }
    }
}