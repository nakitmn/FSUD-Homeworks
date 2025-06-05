using UnityEngine;

namespace Game
{
    public sealed class CameraController : MonoBehaviour
    {
        [SerializeField] private Transform _follower;
        [SerializeField] private float _speed;
        
        private Transform _target;

        public void SetTarget(Transform target)
        {
            _target = target;
        }

        private void LateUpdate()
        {
            if (_target == null)
            {
                return;
            }

            _follower.position = Vector3.Lerp(_follower.position, _target.position, _speed * Time.deltaTime);
        }
    }
}