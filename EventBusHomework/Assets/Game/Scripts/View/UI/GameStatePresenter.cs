using Atomic.Elements;
using Atomic.Entities;
using Game.View;
using TMPro;

namespace SampleGame
{
    public sealed class GameStatePresenter : IEnable<IViewContext>, IDisable
    {
        private readonly TMP_Text _view;

        private IReactiveVariable<GameState> _currentState;

        public GameStatePresenter(TMP_Text view)
        {
            _view = view;
        }

        public void Enable(IViewContext entity)
        {
            var gameContext = GameContext.Instance;
            _currentState = gameContext.GetCurrentState();

            _currentState.Observe(OnStateChanged);
        }

        public void Disable(in IEntity entity)
        {
            _currentState.Unsubscribe(OnStateChanged);
        }

        private void OnStateChanged(GameState gameState)
        {
            _view.text = $"Game State: {gameState}";
        }
    }
}