namespace Code.Models
{
    using UniRx;
    using UnityEngine;

    public interface IObjectModel
    {
        ReactiveProperty<Vector3> Position { get; }
        ReactiveProperty<Quaternion> Rotation { get; }
        State State { get; set; }
        void Spawn();
        void Edit();
    }
}