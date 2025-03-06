using UnityEngine;

namespace SampleGame
{
    public sealed class ProgressBarView : MonoBehaviour
    {
        [SerializeField] private RectTransform _fill;

        public void SetFill(float value)
        {
            var anchorMax = _fill.anchorMax;
            anchorMax.x = value;
            _fill.anchorMax = anchorMax;
        }
    }
}