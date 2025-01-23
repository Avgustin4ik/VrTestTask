namespace Code
{
    using Gameplay.Props;
    using Reflex.Attributes;
    using UnityEngine;
    public class GameCore : MonoBehaviour
    {
        private PropsEditor _propsEditor;

        private void OnEnable()
        {
            DontDestroyOnLoad(gameObject);
        }
        [Inject]
        public void Construct(PropsEditor propsEditor)
        {
            _propsEditor = propsEditor;
            Debug.Log("GameCore Construct");
        }
    }
}