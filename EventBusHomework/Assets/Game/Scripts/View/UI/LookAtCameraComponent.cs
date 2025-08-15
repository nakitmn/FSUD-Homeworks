using Game.View;
using UnityEngine;

namespace SampleGame
{
    public sealed class LookAtCameraComponent : MonoBehaviour
    {
        private Transform _camera;

        private void Awake()
        {
            _camera = ViewContext.Instance.GetCamera().transform;
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