using Leopotam.EcsLite;
using UnityEngine;

namespace SampleGame
{
    [CreateAssetMenu(
        fileName = "TowerPrototype",
        menuName = "SampleGame/Entities/New TowerPrototype"
    )]
    public sealed class TowerPrototype : EcsPrototype
    {
        [SerializeField]
        private int _health = 10;

        [SerializeField]
        private int _incomeAmount = 10;

        [SerializeField]
        private float _incomePeriod = 1;

        protected override void Install(in EcsWorld world, in int entity)
        {
            world.GetPool<TowerTag>().Add(entity);
            world.GetPool<Health>().Add(entity) = new Health
            {
                current = _health,
                max = _health
            };

            world.GetPool<IncomeTag>().Add(entity);
            world.GetPool<IncomeAmount>().Add(entity).value = _incomeAmount;
            world.GetPool<IncomePeriod>().Add(entity).duration = _incomePeriod;
        }
    }
}