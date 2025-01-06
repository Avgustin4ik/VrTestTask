namespace Code
{
    using Core.Service;
    using Reflex.Attributes;

    //нужен для сериализации исходных данных в редакторе
    public abstract class ServiceSource<T> : ServiceSourceBase where T : Service
    {
        public override Service CreateService()
        {
            return CreateServiceInstance();
        }
        protected abstract T CreateServiceInstance();
    }
}