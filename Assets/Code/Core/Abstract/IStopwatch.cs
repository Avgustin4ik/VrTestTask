namespace Code.Core
{
    using System;
    using System.Collections.Generic;
    using Models;

    public interface IStopwatch : IControl
    {
        public abstract TimeSpan GetCurrentTime();
        public abstract List<LapTime> GetLapTimes();
        
        public abstract void LapStopwatch();
        public abstract void Run();
    }
}