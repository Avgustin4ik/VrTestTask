namespace Code
{
    using Core.Service;
    using Reflex.Attributes;
    using Reflex.Core;
    using UnityEngine;
    public class GameCore : MonoBehaviour
    {
        [Inject] SpawnService _spawnService;
        private void OnEnable()
        {
            DontDestroyOnLoad(gameObject);
        }

        private void Awake()
        {
            // _serviceLoader.LoadServices();
            //todo add boot loader
            _spawnService.Test();
        }
        
        
    }
}