using Atomic.Contexts;
using Atomic.Entities;
using UnityEngine;

namespace SampleGame
{
    public static class InputUseCase
    {
        public static bool IsMove(in IGameContext context)
        {
            var mouseButton = context.GetInputMap().MoveMouseButton;
            return Input.GetMouseButtonDown(mouseButton);
        }
        
        public static bool IsUseAbility(in IGameContext context)
        {
            var mouseButton = context.GetInputMap().UseAbilityMouseButton;
            return Input.GetMouseButtonDown(mouseButton);
        }
        
        public static bool TryGetAbilitySelectButtonIndex(in IGameContext context, out int index)
        {
            var abilityKeys = context.GetInputMap().Abilities;
            
            for (var i = 0; i < abilityKeys.Length; i++)
            {
                if (Input.GetKeyDown(abilityKeys[i]))
                {
                    index = i;
                    return true;
                }
            }

            index = -1;
            return false;
        }
    }
}