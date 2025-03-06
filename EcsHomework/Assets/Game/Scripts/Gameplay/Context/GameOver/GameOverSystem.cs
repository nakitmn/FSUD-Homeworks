using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace SampleGame.GameOver
{
    public sealed class GameOverSystem : IEcsRunSystem
    {
        private readonly EcsPoolInject<CastleTag> _castles;
        private readonly EcsEventInject<DeadEvent> _deadEvent;
        private readonly EcsEventInject<GameOverEvent> _gameOverEvent;
        private readonly EcsWorldInject _world;
        private readonly EcsSingletonInject<PlayerData> _playerData;

        public void Run(IEcsSystems systems)
        {
            while (_deadEvent.Value.Consume(out var deadEvent))
            {
                if (deadEvent.entity.Unpack(_world.Value, out var entity) == false)
                {
                    continue;
                }

                if (_castles.Value.Has(entity) == false)
                {
                    continue;
                }

                _playerData.Value.isGameOver = true;
                _gameOverEvent.Value.Fire(new GameOverEvent());
            }
        }
    }
}