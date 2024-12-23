namespace Code.Core.Models
{
    using System;
    using System.Collections.Generic;
    using Code.Core.Abstract;
    using UniRx;

    public class StopwatchModel : IModel, IStopwatch
    {
        public IReactiveProperty<TimeSpan> Time = new ReactiveProperty<TimeSpan>();
        public IReactiveCollection<LapTime> Laps = new ReactiveCollection<LapTime>();

        public float StartTime;
        public float LastPauseTime;
        public float PauseDuration;
        public bool IsClearStart = true;

        private IDisposable _timerRx;

        private void ResetValues()
        {
            Time.Value = TimeSpan.Zero;
            StartTime = 0;
            LastPauseTime = 0;
            PauseDuration = 0;
            IsClearStart = true;
            Laps.Clear();
        }


        public void Stop()
        {
            _timerRx?.Dispose();
        }

        public void Pause()
        {
            IsClearStart = false;
            LastPauseTime = UnityEngine.Time.time;
            Stop();
        }

        public void Reset()
        {
            ResetValues();
            Stop();
        }

        public TimeSpan GetCurrentTime() => Time.Value;

        public List<LapTime> GetLapTimes()
        {
            var laps = new List<LapTime>();
            //todo do not forget to refactor this
            foreach (var lap in Laps)
            {
                laps.Add(new LapTime
                {
                    Index = lap.Index,
                    Global = lap.Global,
                    Difference = lap.Difference
                });
            }
            return laps;
        }

        public void LapStopwatch()
        {
            Laps.Add(new LapTime
            {
                Index = Laps.Count + 1,
                Global = Time.Value.TotalSeconds,
                Difference = Laps.Count > 0 ? Time.Value.TotalSeconds - Laps[^1].Global : 0f
            });
        }

        public void Run()
        {
            if(IsClearStart)
                StartTime = UnityEngine.Time.time;
            else
                PauseDuration += UnityEngine.Time.time - LastPauseTime;
            _timerRx = Observable.EveryUpdate().Subscribe(_ =>
            {
                var time = UnityEngine.Time.time - StartTime - PauseDuration;
                Time.Value = TimeSpan.FromSeconds(time);
            });
        }
    }
}