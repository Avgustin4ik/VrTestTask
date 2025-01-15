namespace Code.Installers
{
    //todo можно заменить на пространство Code.Core и подтягивать все оттуда. либо добавить в ASMDF
    using Code.Core.SelectionScreen.Model;
    using Core;
    using Core.UiElements.CloseButton.View;
    using Models;
    using Reflex.Core;
    using Spawner;
    using UiElements.SelectionScreen.SelectionPreview;
    using UnityEngine;

    public class GameplayInstaller : MonoBehaviour, IInstaller
    {
        public void InstallBindings(ContainerBuilder containerBuilder)
        {
#if DEBUG
            Debug.Log("GameplayInstaller InstallBindings");
#endif
            containerBuilder.AddSingleton(typeof(Injector));
            containerBuilder.AddSingleton(typeof(PropsFactory));
            containerBuilder.AddSingleton(typeof(UIFactory));
            
            containerBuilder.AddTransient(typeof(TestModel), typeof(ITestModel));
            
            
            containerBuilder.AddScoped(typeof(SelectionScreenModel));
            containerBuilder.AddTransient(typeof(SelectionPreviewViewModel));
            containerBuilder.AddTransient(typeof(CloseButtonModel));
            ContainerDi.Builder = containerBuilder;
        }
    }
}