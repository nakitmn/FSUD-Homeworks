using Atomic.Entities;
using UnityEngine;

namespace SampleGame
{
    public static class AbilityUseCase
    {
        public static bool Use(in Ability ability)
        {
            if (!ability.HasBaseTag())
                return false;

            if (!ability.GetBaseCondition().Invoke())
                return false;
            
            ability.GetBaseAction().Invoke();
            ability.GetBaseEvent().Invoke();
            return true;
        }
        
        public static bool Use(in Ability ability, in Vector3 point)
        {
            if (!ability.HasPointTag())
                return false;

            if (!ability.GetPointCondition().Invoke(point))
                return false;
            
            ability.GetPointAction().Invoke(point);
            ability.GetPointEvent().Invoke(point);
            return true;
        }
        
        public static bool Use(in Ability ability, in IEntity target)
        {
            if (!ability.HasTargetTag())
                return false;

            if (!ability.GetTargetCondition().Invoke(target))
                return false;
            
            ability.GetTargetAction().Invoke(target);
            ability.GetTargetEvent().Invoke(target);
            return true;
        }
    }
}