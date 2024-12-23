namespace Code.Core
{
    using System;

    public interface IClock
    {
        public abstract TimeSpan GetCurrentTime();
    }
}