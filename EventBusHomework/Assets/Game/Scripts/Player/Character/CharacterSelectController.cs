using Atomic.Entities;
using UnityEngine;

namespace SampleGame
{
    public sealed class CharacterSelectController : IUpdate<IGameContext>
    {
        public void OnUpdate(IGameContext context, in float deltaTime)
        {
            if (InputUseCase.IsSelect(context) &&
                RaycastUseCase.RaycastTarget(context, Input.mousePosition, out IGameEntity target) &&
                target.HasCharacterTag())
            {
                context.GetSelectedCharacter().Value = target;
            }
        }
    }
}