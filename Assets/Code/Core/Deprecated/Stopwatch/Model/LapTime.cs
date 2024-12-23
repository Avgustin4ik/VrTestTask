namespace Code.Core.Models
{
    using System;

    [Serializable]
    public struct LapTime
    {
        public int Index;
        public double Global;
        public double Difference;
    }
}