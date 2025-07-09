using UnityEngine;

namespace SampleGame
{
    public sealed class Billboard : MonoBehaviour
    {
        private Transform _camera;

        private void Awake()
        {
            _camera = GameContext.Instance.GetCamera().transform;
        }

        private void LateUpdate()
        {
            if (_camera == null)
            {
                return;
            }

            transform.LookAt(transform.position + _camera.forward);
        }
    }
}