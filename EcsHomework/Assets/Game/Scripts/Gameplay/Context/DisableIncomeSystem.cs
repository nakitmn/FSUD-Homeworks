using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace SampleGame
{
    public sealed class DisableIncomeSystem : IEcsRunSystem
    {
        private readonly EcsFilterInject<Inc<IncomeTag, IncomeEnabled>> _income;
        private readonly EcsSingletonInject<PlayerData> _playerData;

        public void Run(IEcsSystems systems)
        {
            foreach (var spawnerEntity in _income.Value)
            {
                if (_playerData.Value.isGameOver == false)
                {
                    continue;
                }

                _income.Pools.Inc2.Del(spawnerEntity);
            }
        }
    }
}