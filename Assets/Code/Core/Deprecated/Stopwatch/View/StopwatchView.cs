namespace Code.Core.Views
{
    using System;
    using Abstract;
    using Models;
    using TMPro;
    using UniRx;
    using UnityEngine;
    using UnityEngine.UI;

    public class StopwatchView : UiView<StopwatchModel>
    {
        [Header("Buttons")]
        [SerializeField] private Button startButton;
        [SerializeField] private Button pauseButton;
        [SerializeField] private Button resetButton;
        [SerializeField] private Button lapButton;
        
        [Space(5)]
        [Header("Ui")]
        [SerializeField] private TextMeshProUGUI timeText;
        [SerializeField] private RectTransform lapsContainer;
        // [Inject] private LapTimeView.Factory _lapTimeViewFactory;
        
        private IDisposable _timerRx;

        protected override void Initialize(StopwatchModel model)
        {
            startButton.onClick.AsObservable().Subscribe(x => Run()).AddTo(this);
            pauseButton.onClick.AsObservable().Subscribe(x => Pause()).AddTo(this);
            resetButton.onClick.AsObservable().Subscribe(x => Reset()).AddTo(this);
            lapButton.onClick.AsObservable().Subscribe(x => Lap()).AddTo(this);
            
            model.Time.Subscribe(x=>DisplayTime(x)).AddTo(this);
            
            // model.Laps.ObserveAdd().Subscribe(x =>
            // {
            //     var lapTimeView = _lapTimeViewFactory.Create();
            //     var lapTransform = lapTimeView.transform;
            //     lapTransform.SetParent(lapsContainer);
            //     lapTransform.localScale = Vector3.one;
            //     lapTransform.position = Vector3.zero;
            //     lapTimeView.Model.LapTime.Value = x.Value;
            // }).AddTo(this);
            
            model.Laps.ObserveReset().Subscribe(x => KillAllLaps()).AddTo(this);
            base.Initialize(model);
        }

        private void KillAllLaps()
        {
            foreach (Transform child in lapsContainer)
            {
                Destroy(child.gameObject);
            }
        }
        
        private void Reset()
        {
            startButton.gameObject.SetActive(true);
            pauseButton.gameObject.SetActive(false);
            resetButton.gameObject.SetActive(true);
            lapButton.gameObject.SetActive(false);
            
            Model.Reset();
        }

        private void DisplayTime(TimeSpan timeSpan)
        {
            timeText.text = timeSpan.ToString(@"hh\:mm\:ss\,fff");
        }

        private void Run()
        {
            startButton.gameObject.SetActive(false);
            pauseButton.gameObject.SetActive(true);
            resetButton.gameObject.SetActive(false);
            lapButton.gameObject.SetActive(true);
            
            Model.Run();
        }
        public void Pause()
        {
            startButton.gameObject.SetActive(true);
            pauseButton.gameObject.SetActive(false);
            resetButton.gameObject.SetActive(true);
            lapButton.gameObject.SetActive(false);
            
            Model.Pause();
        }

        private void Lap()
        {
           Model.LapStopwatch();
        }
    }
}
