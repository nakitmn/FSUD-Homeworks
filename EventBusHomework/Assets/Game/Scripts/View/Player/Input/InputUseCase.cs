using Game.View;
using UnityEngine;

namespace SampleGame
{
    public static class InputUseCase
    {
        public static bool IsInputAllowed(IViewContext context)
        {
            // TODO: condition
            // return context.GetInputCondition().Value;
            
            return true;
        }

        public static bool IsAttack(IViewContext context)
        {
            return Input.GetMouseButtonDown(1) && IsInputAllowed(context);
        }
        
        public static bool IsMove(IViewContext context)
        {
            return Input.GetMouseButtonDown(0) && IsInputAllowed(context);
        }
        
        public static bool IsSelect(IViewContext context)
        {
            return Input.GetMouseButtonDown(0) && IsInputAllowed(context);
        }
    }
}