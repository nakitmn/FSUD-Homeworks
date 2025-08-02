using Atomic.Entities;
using UnityEngine;

namespace SampleGame
{
    public sealed class CharacterSelectController : IInit, IUpdate<IGameContext>
    {
        private Camera _camera;

        public void Init(in IEntity entity)
        {
            _camera = Camera.main;
        }

        public void OnUpdate(IGameContext context, in float deltaTime)
        {
            if (InputUseCase.IsSelect(context) &&
                RaycastUseCase.RaycastTarget(_camera, Input.mousePosition, out IGameEntity target) &&
                target.HasCharacterTag())
            {
                context.GetSelectedCharacter().Value = target;
            }
        }
    }
}