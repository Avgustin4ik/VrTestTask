namespace Code.Gameplay.Props
{
    using UniRx;
    using UnityEngine;

    public class PropsModel : IPropsModel
    {
        public ReactiveProperty<Vector3> Position { get; } = new ReactiveProperty<Vector3>();

        public ReactiveProperty<Quaternion> Rotation { get; } = new ReactiveProperty<Quaternion>();
        public ReactiveProperty<bool> IsInEditMode { get; } = new ReactiveProperty<bool>();
        
        public PropsModel()
        {
            Debug.Log("PropsModel Construct");
        }

        public void Test()
        {
            Debug.Log("TestModel Test");
        }

        public ReactiveCommand<bool> Despawn { get; } = new ReactiveCommand<bool>();
    }
}