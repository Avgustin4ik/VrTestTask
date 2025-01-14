namespace Code.Models
{
    using UniRx;
    using UnityEngine;
    using UnityEngine.XR.Interaction.Toolkit.Interactors;

    public class ObjectModelMono : MonoBehaviour
    {
        public MeshRenderer MeshRenderer;
        public Collider Collider;
        public NearFarInteractor interactionGroup;
        public GameObject prefab;
        public void DisplayState(State state)
        {
            switch (state)
            {
                case State.Edited:
                    break;
                case State.Spawned:
                    break;
            }
        }

        private void Update()
        {
            interactionGroup.TryGetCurveEndPoint(out endPoint);
            prefab.transform.position = endPoint;
        }

        private Vector3 endPoint;


        // [Inject]
        public void Construct(IObjectModel model)
        {
            MeshRenderer.enabled = true;
            Collider.enabled = true;
            DisplayState(model.State);
            //подписка на события монобех <-> модель 
            model.Position.Subscribe(value => transform.position = value).AddTo(this); //подписка на события модель <-> монобех
            model.Rotation.Subscribe(value => transform.rotation = value).AddTo(this);
        }
    }
}