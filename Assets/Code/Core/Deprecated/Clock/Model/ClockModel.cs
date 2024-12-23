namespace Code.Core.Models
{
    using System;
    using Code.Core.Abstract;
    using UniRx;

    public class ClockModel : IModel, IClock
    {
        public IReactiveProperty<TimeSpan> Time = new ReactiveProperty<TimeSpan>();
        public IReactiveProperty<string> TimeZone = new ReactiveProperty<string>();
        
        private IDisposable _timeRx;
        private string GetSymbol(int var) => var < 0 ? "-" : "+";
        private ClockModel()
        {
            var localBaseUtcOffset = TimeZoneInfo.Local.BaseUtcOffset.Hours;
            TimeZone.Value ="UTC "+GetSymbol(localBaseUtcOffset) + localBaseUtcOffset.ToString();
            _timeRx = Observable.EveryUpdate().Subscribe(x => Time.Value = DateTime.Now.TimeOfDay);
        }
        
        ~ClockModel()
        {
            _timeRx.Dispose();
        }

        public TimeSpan GetCurrentTime() => Time.Value;
    }
}