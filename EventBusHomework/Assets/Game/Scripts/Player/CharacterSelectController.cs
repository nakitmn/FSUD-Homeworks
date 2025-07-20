using Atomic.Entities;
using UnityEngine;

namespace SampleGame
{
    public sealed class CharacterSelectController : IUpdate<IGameContext>
    {
        public void OnUpdate(IGameContext context, in float deltaTime)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (RaycastUseCase.RaycastTarget(context,Input.mousePosition, out var target))
                {
                    context.GetSelectedCharacter().Value = target;
                }
            }
        }
    }
}