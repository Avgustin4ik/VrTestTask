namespace Code
{
    using System.Linq;
    using Reflex.Attributes;
    using Spawner;
    using UnityEngine;

    public class TestMono : MonoBehaviour
    {
        [Inject] private SpawnService _spawnService;

        [Inject]
        public void Constuct(ITestModel model)
        {
            var firstOrDefault = _spawnService.GetAssetReferences().FirstOrDefault();
            Debug.Log(firstOrDefault);
            Debug.Log("TestMono Construct");
            model.Test();
        }
    }

    public interface ITestModel
    {
        public void Test();
    }
    
    public class TestModel : ITestModel
    {
        public void Test()
        {
            Debug.Log("TestModel Test");
        }
    }
}