using UnityEngine;

namespace Game.Gameplay
{
    public sealed class ReloadComponent 
    {
        private readonly float _duration;

        private float _startTime;
        
        private float CurrentTime => Time.time;

        public ReloadComponent(float duration)
        {
            _duration = duration;
        }

        public bool IsReady()
        {
            return CurrentTime - _startTime >= _duration;
        }

        public void Reload()
        {
            _startTime = Time.time;
        }
    }
}