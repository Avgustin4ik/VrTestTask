namespace Code.Installers
{
    //todo можно заменить на пространство Code.Core и подтягивать все оттуда. либо добавить в ASMDF
    using Code.Core.SelectionScreen.Model;
    using Core.UiElements.CloseButton.View;
    using Core.UiElements.SelectionScreen.View;
    using Reflex.Core;
    using UnityEngine;

    public class GameplayInstaller : MonoBehaviour, IInstaller
    {
        public void InstallBindings(ContainerBuilder containerBuilder)
        {
            containerBuilder.AddScoped(typeof(SelectionScreenModel));
            containerBuilder.AddTransient(typeof(CloseButtonModel));
        }
    }
}