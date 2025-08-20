using Atomic.Elements;
using Atomic.Entities;
using Game.Core;
using TMPro;

namespace Game.View
{
    public sealed class CurrentTurnPresenter : IEnable<IViewContext>, IDisable
    {
        private readonly TMP_Text _view;

        private IReactiveVariable<int> _turn;

        public CurrentTurnPresenter(TMP_Text view)
        {
            _view = view;
        }

        public void Enable(IViewContext entity)
        {
            var gameContext = GameContext.Instance;
            _turn = gameContext.GetTurn();

            _turn.Observe(OnTurnChanged);
        }

        public void Disable(in IEntity entity)
        {
            _turn.Unsubscribe(OnTurnChanged);
        }

        private void OnTurnChanged(int turn)
        {
            _view.text = $"Turn: {turn}";
        }
    }
}