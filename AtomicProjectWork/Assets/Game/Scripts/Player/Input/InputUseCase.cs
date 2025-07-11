using Atomic.Contexts;
using Atomic.Entities;
using UnityEngine;
using UnityEngine.EventSystems;

namespace SampleGame
{
    public static class InputUseCase
    {
        public static bool IsMove(in IGameContext context, EventSystem eventSystem)
        {
            var mouseButton = context.GetInputMap().MoveMouseButton;
            return Input.GetMouseButtonDown(mouseButton) && 
                   eventSystem.IsPointerOverGameObject() == false;
        }

        public static bool IsUseAbility(in IGameContext context, EventSystem eventSystem)
        {
            var mouseButton = context.GetInputMap().UseAbilityMouseButton;
            return Input.GetMouseButtonDown(mouseButton) &&
                   eventSystem.IsPointerOverGameObject() == false;
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