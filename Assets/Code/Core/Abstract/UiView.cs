namespace Code.Core.Abstract
{
    using Reflex.Attributes;
    using UnityEngine;

    public class UiView<TModel> : BaseView where TModel : IModel
    {
        public TModel Model { get; private set; }
        
        public virtual void Initialize(TModel model)
        {
            Model = model;
#if DEBUG
            UnityEngine.Debug.Log($"UiView.Initialize {name}: model hash {model.GetHashCode()}, view hash {GetHashCode()}");
#endif
            base.Initialize();
        }

        public void UpdateModel(TModel model)
        {
            Model = model;
        }
    }
}