using Atomic.Entities;
using UnityEngine;

namespace SampleGame
{
    public sealed class CharacterUseAbilityController : IInit<IGameContext>, IUpdate<IGameContext>
    {
        private IEntity _character;

        public void Init(IGameContext context)
        {
            _character = context.GetCharacter();
        }

        public void OnUpdate(IGameContext context, in float deltaTime)
        {
            if (InputUseCase.IsUseAbility(context) == false)
            {
                return;
            }
            
            var selectedAbility = _character.GetSelectedAbility().Value;
            if (selectedAbility == null)
            {
                return;
            }

            if (selectedAbility.HasBaseTag())
            {
                AbilityUseCase.Use(selectedAbility);
            }
            else if (selectedAbility.HasPointTag())
            {
                if (RaycastUseCase.RaycastPlaneGround(context, Input.mousePosition, out var point))
                {
                    AbilityUseCase.Use(selectedAbility, point);
                }
            }
            else if (selectedAbility.HasTargetTag())
            {
                if (RaycastUseCase.RaycastTarget(context, Input.mousePosition, out var target))
                {
                    AbilityUseCase.Use(selectedAbility, target);
                }
            }
        }
    }
}