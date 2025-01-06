namespace Code
{
    using Core.Service;
    using UnityEngine;

    public abstract class ServiceSourceBase : ScriptableObject
    {
        public abstract Service CreateService();
    }
}