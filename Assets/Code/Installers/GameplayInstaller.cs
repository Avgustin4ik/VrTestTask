namespace Code.Installers
{
    using Code.Core.SelectionScreen.Model;
    using Core;
    using Core.UiElements.CloseButton.View;
    using Player;
    using Props;
    using Reflex.Core;
    using Spawner;
    using UiElements.SelectionScreen.SelectionPreview;
    using UnityEngine;
    using UnityEngine.InputSystem;
    using UnityEngine.InputSystem.XR;
    using UnityEngine.XR;

    public class GameplayInstaller : MonoBehaviour, IInstaller
    {
        [Header("Input")]
        public bool runSimulation = true;
        [SerializeField] private InputScheme simulatorInputScheme;
        [SerializeField] private InputScheme deviceInputScheme;
        
        public void InstallBindings(ContainerBuilder containerBuilder)
        {
#if DEBUG
            Debug.Log("GameplayInstaller InstallBindings");
#endif
            InstallControl(containerBuilder);
            
            containerBuilder.AddSingleton(typeof(PropsEditor));
            containerBuilder.AddSingleton(typeof(Injector));
            containerBuilder.AddSingleton(typeof(PropsFactory));
            containerBuilder.AddSingleton(typeof(UIFactory));
            containerBuilder.AddSingleton(typeof(EditablePropsFactory));
            
            containerBuilder.AddTransient(typeof(TestModel), typeof(ITestModel));
            containerBuilder.AddTransient(typeof(PropsModel), typeof(IPropsModel));

            containerBuilder.AddScoped(typeof(SelectionScreenModel));
            containerBuilder.AddTransient(typeof(SelectionPreviewViewModel));
            containerBuilder.AddTransient(typeof(CloseButtonModel));
        }

        private void InstallControl(ContainerBuilder containerBuilder)
        {
            //todo добавить переключение между симуляцией и устройством на лету
            var inputScheme = runSimulation ? this.simulatorInputScheme : deviceInputScheme;
            containerBuilder.AddSingleton(this.simulatorInputScheme.rightInteractor);
            containerBuilder.AddSingleton(this.simulatorInputScheme.leftInteractor);
            containerBuilder.AddSingleton(new ControlScheme(
                inputScheme));
        }
    }
}
