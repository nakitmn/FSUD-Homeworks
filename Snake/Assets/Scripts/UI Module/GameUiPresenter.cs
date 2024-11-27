using System;
using Modules;
using SnakeGame;
using Zenject;

namespace UI_Module
{
    public sealed class GameUiPresenter : IInitializable, IDisposable
    {
        private readonly IDifficulty _difficulty;
        private readonly IScore _score;
        private readonly IGameUI _gameUI;

        public GameUiPresenter(IDifficulty difficulty, IScore score, IGameUI gameUI)
        {
            _difficulty = difficulty;
            _score = score;
            _gameUI = gameUI;
        }

        void IInitializable.Initialize()
        {
            _difficulty.OnStateChanged += OnLevelChanged;
            _score.OnStateChanged += OnScoreChanged;

            OnLevelChanged();
            OnScoreChanged(_score.Current);
        }

        void IDisposable.Dispose()
        {
            _difficulty.OnStateChanged -= OnLevelChanged;
            _score.OnStateChanged -= OnScoreChanged;
        }

        private void OnLevelChanged()
        {
            _gameUI.SetDifficulty(_difficulty.Current, _difficulty.Max);
        }

        private void OnScoreChanged(int score)
        {
            _gameUI.SetScore(score.ToString());
        }
    }
}