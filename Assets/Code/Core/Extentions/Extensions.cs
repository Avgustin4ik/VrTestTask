namespace Code.Core.Extentions
{
    using Abstract;
    using UnityEngine;

    public static class Extensions
    {
        public static T GetParentComponent<T>(this GameObject gameObject) where T : Component
        {
            foreach (var element in gameObject.GetComponentsInParent<T>())
            {
                if (element.gameObject.GetHashCode() != gameObject.GetHashCode())
                {
                    return element;
                }
            }
            return null;
        }
        
        public static TModel TryGetModel<TModel>(this MonoBehaviour monoBehaviour) where TModel : IModel
        {
            return monoBehaviour.GetComponent<TModel>() ?? monoBehaviour.GetComponentInParent<TModel>();
        }
        
    }
}