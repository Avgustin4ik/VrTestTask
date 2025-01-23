namespace Code.Core.Abstract.Service
{
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