using Atomic.Elements;
using Atomic.Entities;
using SampleGame;

namespace Game.View
{
    public sealed class GameEntityHealthPresenter : IInit<IGameEntity>
    {
        private readonly ProgressBarPro _progressBarPro;

        private IReactiveVariable<int> _maxHealth;

        public GameEntityHealthPresenter(ProgressBarPro progressBarPro)
        {
            _progressBarPro = progressBarPro;
        }

        public void Init(IGameEntity entity)
        {
            _progressBarPro.Value = HealthUseCase.GetNormalizedHealth(entity);
        }
    }
}