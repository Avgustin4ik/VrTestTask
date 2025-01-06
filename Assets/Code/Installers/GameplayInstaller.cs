namespace Code.Installers
{
    //todo можно заменить на пространство Code.Core и подтягивать все оттуда. либо добавить в ASMDF
    using Code.Core.SelectionScreen.Model;
    using Core.Abstract;
    using Core.UiElements.CloseButton.View;
    using Core.UiElements.SelectionScreen.SelectionPreview;
    using Reflex.Core;
    using UnityEngine;

    public class GameplayInstaller : MonoBehaviour, IInstaller
    {
        // public ServicesInstaller serviceSources;
        public BaseView[] uiViews;
        public void InstallBindings(ContainerBuilder containerBuilder)
        {
            // serviceSources.InstallBindings(containerBuilder);
#if DEBUG
            Debug.Log("GameplayInstaller InstallBindings");
#endif
            containerBuilder.AddScoped(typeof(SelectionScreenModel));
            containerBuilder.AddTransient(typeof(SelectionPreviewViewModel));
            containerBuilder.AddTransient(typeof(CloseButtonModel));
        }
    }
}