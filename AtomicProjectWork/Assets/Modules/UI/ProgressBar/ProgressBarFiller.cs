using UnityEngine;

namespace SampleGame
{
    public abstract class ProgressBarFiller : MonoBehaviour
    {
        public abstract float FillAmount { get; set; }
    }
}