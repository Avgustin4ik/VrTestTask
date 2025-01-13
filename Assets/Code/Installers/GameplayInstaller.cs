namespace Code.Installers
{
    //todo можно заменить на пространство Code.Core и подтягивать все оттуда. либо добавить в ASMDF
    using Code.Core.SelectionScreen.Model;
    using Core;
    using Core.Abstract;
    using Core.UiElements.CloseButton.View;
    using Reflex.Attributes;
    using Reflex.Core;
    using UiElements.SelectionScreen.SelectionPreview;
    using UnityEngine;

    public class GameplayInstaller : MonoBehaviour, IInstaller
    {
        public void InstallBindings(ContainerBuilder containerBuilder)
        {
#if DEBUG
            Debug.Log("GameplayInstaller InstallBindings");
#endif
            containerBuilder.AddScoped(typeof(SelectionScreenModel));
            containerBuilder.AddTransient(typeof(SelectionPreviewViewModel));
            containerBuilder.AddTransient(typeof(CloseButtonModel));
            ContainerDi.Builder = containerBuilder;
        }
    }
}