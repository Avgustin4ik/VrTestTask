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
    using UnityEngine.XR.Interaction.Toolkit.Interactors;

    public class GameplayInstaller : MonoBehaviour, IInstaller
    {
        [SerializeField] private NearFarInteractor rightInteractor;
        [SerializeField] private NearFarInteractor leftInteractor;
        public void InstallBindings(ContainerBuilder containerBuilder)
        {
#if DEBUG
            Debug.Log("GameplayInstaller InstallBindings");
#endif
            containerBuilder.AddSingleton(rightInteractor);
            containerBuilder.AddSingleton(leftInteractor);
            containerBuilder.AddSingleton(new ControlScheme(rightInteractor, leftInteractor));
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
    }
}