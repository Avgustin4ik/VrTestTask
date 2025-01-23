namespace Code.Core.Abstract.Service
{
    using UnityEngine;

    public abstract class ServiceSourceBase : ScriptableObject
    {
        public abstract Service CreateService();
    }
}