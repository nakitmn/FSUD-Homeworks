using UnityEngine;

namespace SampleGame
{
    public sealed class ProgressBarProFiller : ProgressBarFiller
    {
        [SerializeField] private ProgressBarPro _progressBarPro;

        public override float FillAmount
        {
            get => _progressBarPro.Value;
            set => _progressBarPro.Value = value;
        }
    }
}