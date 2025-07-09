using System;
using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace SampleGame
{
    [Serializable]
    public sealed class CameraSystemInstaller : IEntityInstaller<IGameContext>
    {
        [SerializeField]
        private Vector3 _cameraOffset = new Vector3(0, 5, -5);

        [SerializeField]
        private Camera _camera;
        
        public void Install(IGameContext context)
        {
            context.AddCameraOffset(new Const<Vector3>(_cameraOffset));
            context.AddCamera(_camera);
            context.AddBehaviour<CameraFollowController>();
        }
    }
}