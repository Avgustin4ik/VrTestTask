namespace Code.Core.Views
{
    using Abstract;
    using Models;
    using UniRx;

    public class LapTimeModel : IModel
    {
        public IReactiveProperty<LapTime> LapTime = new ReactiveProperty<LapTime>();
    }
}