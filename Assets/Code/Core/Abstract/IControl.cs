namespace Code.Core
{
    public interface IControl
    {
        public abstract void Stop();
        
        public abstract void Pause();

        public abstract void Reset();
    }
}