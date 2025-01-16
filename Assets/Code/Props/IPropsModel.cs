namespace Code
{
    using Core.Abstract;
    using UniRx;
    using UnityEngine;

    public interface IPropsModel : IModel
    {
        public ReactiveProperty<Vector3> Position { get; }
        public ReactiveProperty<Quaternion> Rotation { get; }
        public ReactiveProperty<bool> IsInEditMode { get; }
        public void Test();
    }
}