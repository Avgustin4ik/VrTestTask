namespace Code.Gameplay.Props
{
    using Reflex.Attributes;
    using UniRx;
    using UnityEngine;

    public class PropsMono : MonoBehaviour
    {
        [SerializeField] private Material _editMaterial;
        [SerializeField] private Material _defaultMaterial;
        [SerializeField] private Material _errorMaterial;
        private MeshRenderer _meshRenderer;
        private Transform _transform;
        public IPropsModel Model;
        
        [Inject]
        public void Constuct(IPropsModel model)
        {
            _meshRenderer = gameObject.GetComponent<MeshRenderer>();
            _defaultMaterial = _meshRenderer.material;
            _transform = transform;
            Model = model;
            model.Position.Where(x=>model.IsInEditMode.Value).Subscribe(Move).AddTo(this);
            model.Rotation.Where(x=>model.IsInEditMode.Value).Subscribe(Rotate).AddTo(this);
            model.IsInEditMode.Subscribe(HandleVisual).AddTo(this);
            model.Test();
            model.Despawn.Subscribe( x =>
            {
                Debug.Log("Despawn");
                Destroy(gameObject);
            }).AddTo(this);
        }
        
        private void HandleVisual(bool isInEditMode)
        {
            if (isInEditMode)
            {
                //todo add vfx
                Debug.Log("PropsMono HandleVisual");
                _meshRenderer.material = _editMaterial;
            }
            else
            {
                _meshRenderer.material = _defaultMaterial;
            }
        }
        private void Move(Vector3 vector3) => _transform.position = vector3;
        private void Rotate(Quaternion quaternion) => _transform.rotation = quaternion;
    }
}