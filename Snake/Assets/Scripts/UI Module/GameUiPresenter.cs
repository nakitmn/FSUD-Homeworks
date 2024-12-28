using System;
using Level_Module;
using Modules;
using SnakeGame;
using Zenject;

namespace UI_Module
{
    public sealed class GameUiPresenter : IInitializable, IDisposable
    {
        private readonly LevelManager _levelManager;
        private readonly IScore _score;
        private readonly IGameUI _gameUI;

        public GameUiPresenter(LevelManager levelManager, IScore score, IGameUI gameUI)
        {
            _levelManager = levelManager;
            _score = score;
            _gameUI = gameUI;
        }

        void IInitializable.Initialize()
        {
            _levelManager.OnGameOver += _gameUI.GameOver;
            _levelManager.OnLevelChanged += OnLevelChanged;
            _score.OnStateChanged += OnScoreChanged;

            OnLevelChanged();
            OnScoreChanged(_score.Current);
        }

        void IDisposable.Dispose()
        {
            _levelManager.OnGameOver -= _gameUI.GameOver;
            _levelManager.OnLevelChanged -= OnLevelChanged;
            _score.OnStateChanged -= OnScoreChanged;
        }

        private void OnLevelChanged()
        {
            _gameUI.SetDifficulty(_levelManager.CurrentLevel, _levelManager.MaxLevel);
        }

        private void OnScoreChanged(int score)
        {
            _gameUI.SetScore(score.ToString());
        }
    }
}