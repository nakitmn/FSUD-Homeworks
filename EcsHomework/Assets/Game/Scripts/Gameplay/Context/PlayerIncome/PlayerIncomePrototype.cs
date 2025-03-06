using Leopotam.EcsLite;
using SampleGame.TeamSpawner;
using UnityEngine;

namespace SampleGame
{
    [CreateAssetMenu(
        fileName = "PlayerIncome",
        menuName = "SampleGame/Entities/New PlayerIncome"
    )]
    public sealed class PlayerIncomePrototype : EcsPrototype
    {
        [SerializeField] private float _cooldown;
        [SerializeField] private int _amountPerStep = 1;
        
        protected override void Install(in EcsWorld world, in int entity)
        {
            world.GetPool<NonViewTag>().Add(entity);
            world.GetPool<IncomeTag>().Add(entity);
            world.GetPool<IncomeAmount>().Add(entity).value = _amountPerStep;
            world.GetPool<IncomePeriod>().Add(entity) = new IncomePeriod()
            {
                duration = _cooldown,
                time = 0f
            };
        }
    }
}