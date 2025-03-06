using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace SampleGame
{
    public sealed class IncomeSystem : IEcsRunSystem
    {
        private readonly EcsFilterInject<Inc<IncomeTag, IncomeEnabled>> _entities;
        private readonly EcsPoolInject<IncomePeriod> _incomePeriods;
        private readonly EcsPoolInject<IncomeAmount> _incomeAmounts;
        private readonly EcsSingletonInject<PlayerData> _playerData;

        public void Run(IEcsSystems systems)
        {
            float deltaTime = Time.deltaTime;

            foreach (int entity in _entities.Value)
            {
                ref IncomePeriod period = ref _incomePeriods.Value.Get(entity);
                ref IncomeAmount income = ref _incomeAmounts.Value.Get(entity);
                IncomeUseCase.UpdateIncome(ref period, in income, _playerData.Value, in deltaTime);
            }
        }
    }
}