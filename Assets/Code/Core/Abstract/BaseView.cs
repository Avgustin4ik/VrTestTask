namespace Code.Core.Abstract
{
    using System;
    using UnityEngine;

    public class BaseView : MonoBehaviour, IDisposable
    {
        private CanvasGroup _canvasGroup;
        
        protected virtual void Initialize()
        {
            if (gameObject.TryGetComponent(typeof(CanvasGroup), out var canvas))
            {
                _canvasGroup = (CanvasGroup)canvas;
            }
            else
            {
                _canvasGroup = gameObject.AddComponent<CanvasGroup>();
            }
        }

        public virtual void Dispose()
        {
        }

        public virtual void Display(bool value = true)
        {
            _canvasGroup.alpha = value ? 1 : 0;
            _canvasGroup.blocksRaycasts = value;
            _canvasGroup.interactable = value;
        }

        public virtual void Hide()
        {
            Display(false);
        }

        public virtual void Show()
        {
            Display(true);
        }

        public virtual void Close()
        {
            Hide();
            Destroy();
        }

        public virtual void Destroy()
        {
            Destroy(gameObject);
        }

        public virtual void SetParent(Transform parent)
        {
            transform.SetParent(parent);
        }

    }
}