using Atomic.Contexts;
using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace SampleGame
{
    public sealed class CameraFollowController : IInit<IGameContext>, ILateUpdate
    {
        private IEntity _character;
        private Transform _camera;
        private IValue<Vector3> _offset;
        
        public void Init(IGameContext context)
        {
            _character = context.GetCharacter();
            _camera = context.GetCamera().transform;
            _offset = context.GetCameraOffset();
        }

        public void OnLateUpdate(in IEntity entity, in float deltaTime)
        {
            _camera.position = _character.GetTransform().position + _offset.Value;
        }
    }
}