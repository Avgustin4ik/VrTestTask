namespace Code.Core.Abstract
{
    using Reflex.Attributes;

    public class UiView<TModel> : BaseView where TModel : IModel
    {
        public TModel Model { get; private set; }
        [Inject]
        public virtual void Initialize(TModel model)
        {
            Model = model;
#if DEBUG
            UnityEngine.Debug.Log($"UiView.Initialize: model hash {model.GetHashCode()}, view hash {GetHashCode()}");
#endif
            base.Initialize();
        }
    }
}