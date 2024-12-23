namespace Code.Core
{
    using System;

    public interface ITimer : IControl
    {
        public abstract TimeSpan GetCurrentTime();
        public abstract void Run(TimeSpan time);
    }
}