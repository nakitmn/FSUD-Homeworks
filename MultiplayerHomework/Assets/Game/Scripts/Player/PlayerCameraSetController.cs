using Fusion;
using UnityEngine;

namespace Game
{
    public sealed class PlayerCameraSetController : NetworkBehaviour
    {
        public override void Spawned()
        {
            if (HasInputAuthority == false)
            {
                return;
            }
            
            var cameraController = Camera.main.GetComponent<CameraController>();
            cameraController.SetTarget(transform);
        }
    }
}