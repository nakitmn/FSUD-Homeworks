using System;
using Atomic.Events;
using UnityEngine;

namespace SampleGame
{
    public sealed class HighlightSpawnPositionsController : MonoBehaviour
    {
        [SerializeField] private GameBoardPresenter _presenter;
        [SerializeField] private Material _highlightMaterial;

        private GameContext _gameContext;
        private IEventBus _eventBus;

        private void Awake()
        {
            _gameContext = GameContext.Instance;
            _eventBus = _gameContext.GetEventBus();
        }

        private void Start()
        {
            OnTurnStarted();
        }

        private void OnEnable()
        {
            _eventBus.SubscribeStartTurn(OnTurnStarted);
        }

        private void OnDisable()
        {
            _eventBus.UnsubscribeStartTurn(OnTurnStarted);
        }

        private void OnTurnStarted()
        {
            Clear();

            if (WaveUseCase.TryGetCurrentWave(_gameContext, out var wave) == false)
            {
                return;
            }

            var views = _presenter.Views;
            var points = wave.points;

            for (var x = 0; x < views.GetLength(0); x++)
            for (var y = 0; y < views.GetLength(1); y++)
            {
                if (Array.Exists(points, p => p.x == x && p.y == y))
                {
                    views[x, y].SetMaterial(_highlightMaterial);
                }
            }
        }

        private void Clear()
        {
            _presenter.ClearMaterials();
        }
    }
}