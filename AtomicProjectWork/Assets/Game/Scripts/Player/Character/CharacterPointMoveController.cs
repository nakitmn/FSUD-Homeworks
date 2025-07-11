using Atomic.Entities;
using UnityEngine;

namespace SampleGame
{
    public class CharacterPointMoveController : IInit<IGameContext>, IUpdate<IGameContext>
    {
        private IGameEntity _character;

        public void Init(IGameContext context)
        {
            _character = context.GetCharacter();
        }

        public void OnUpdate(IGameContext context, in float deltaTime)
        {
            if (InputUseCase.IsMove(context) == false)
            {
                return;
            }
            
            if (RaycastUseCase.RaycastPlaneGround(context, Input.mousePosition, out Vector3 point))
            {
                _character.GetMovePointAction().Invoke(point);
            }
        }
    }
}