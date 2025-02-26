using UnityEngine;
using Zenject;

namespace Game.Gameplay
{
    public sealed class FaceComponent : ITickable
    {
        private readonly Transform _transform;
        
        private float _direction;

        public FaceComponent(Transform transform)
        {
            _transform = transform;
        }

        void ITickable.Tick()
        {
            if (Mathf.Approximately(0f , _direction))
            {
                return;
            }

            var scale = _transform.localScale;
            scale.x = _direction > 0f
                ? Mathf.Abs(scale.x)
                : Mathf.Abs(scale.x) * -1f;
            
            _transform.localScale = scale;
        }

        public void SetDirection(float direction)
        {
            _direction = direction;
        }
    }
}