using UnityEngine;

namespace SampleGame
{
    public static class InputUseCase
    {
        public static bool IsInputAllowed(in IGameContext context)
        {
            // TODO: condition
            // return context.GetInputCondition().Value;
            
            return true;
        }

        public static bool IsAttack(in IGameContext context)
        {
            return Input.GetMouseButtonDown(1) && IsInputAllowed(context);
        }
        
        public static bool IsMove(in IGameContext context)
        {
            return Input.GetMouseButtonDown(0) && IsInputAllowed(context);
        }
        
        public static bool IsSelect(in IGameContext context)
        {
            return Input.GetMouseButtonDown(0) && IsInputAllowed(context);
        }
    }
}