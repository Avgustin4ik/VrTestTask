namespace Code.Core.Views
{
    using System;
    using Abstract;
    using Models;
    using TMPro;
    using UniRx;
    using UnityEngine;

    public class LapTimeView : UiView<LapTimeModel>
    {
        public TextMeshProUGUI Index;
        public TextMeshProUGUI Global;
        public TextMeshProUGUI Difference;

        protected override void Initialize(LapTimeModel model)
        {
            model.LapTime.Subscribe(x =>
            {
                DiplayTime(x);
            }).AddTo(this);
            
            base.Initialize(model);
        }

        private void DiplayTime(LapTime x)
        {
            Index.text = "# " + x.Index;
            Global.text = TimeSpan.FromSeconds(x.Global).ToString(@"hh\:mm\:ss\,fff");
            Difference.text = TimeSpan.FromSeconds(x.Difference).ToString(@"hh\:mm\:ss\,fff");
        }

        // public class Factory : PlaceholderFactory<LapTimeView>
        // {
        // }
    }
}