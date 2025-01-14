namespace Code.Models
{
    using UniRx;
    using UnityEngine;
    using UnityEngine.XR.Interaction.Toolkit.Interactors;

    public class ObjectModel : IObjectModel
    {
        public ObjectModel(XRInteractionGroup xrInteractionGroup)
        {
            
        }
        public ReactiveProperty<Vector3> Position { get; }
        public ReactiveProperty<Quaternion> Rotation { get; }
        public State State { get; set; }
        
        public void Spawn()
        {
            State = State.Spawned;
        }
        
        public void Edit()
        {
            State = State.Edited;
        }
    }
}