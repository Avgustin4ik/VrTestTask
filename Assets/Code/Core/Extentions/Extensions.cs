namespace Code.Core.Extentions
{
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
        
    }
}