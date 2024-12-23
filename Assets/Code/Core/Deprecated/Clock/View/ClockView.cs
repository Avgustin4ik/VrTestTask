namespace Code.Core.Views
{
    using System;
    using Abstract;
    using Models;
    using TMPro;
    using UniRx;
    using UnityEngine;

    public class ClockView : UiView<ClockModel>
    {
        [SerializeField] private TextMeshProUGUI timeText;
        [SerializeField] private TextMeshProUGUI timeZone;
        protected override void Initialize(ClockModel model)
        {
            model.Time.Subscribe(SetTime).AddTo(this);
            model.TimeZone.Subscribe(x => timeZone.text = x).AddTo(this);
            base.Initialize(model);
        }
        private void SetTime(TimeSpan time)
        {
            timeText.text = time.ToString(@"hh\:mm\:ss");
        }
    }
}