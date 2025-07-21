using System;
using System.Collections.Generic;
using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace SampleGame
{
    public sealed class HighlightSpawnCellBehaviour : IInit<IGameEntity>, IEnable, IDisable
    {
        private IReactiveVariable<int> _turn;
        private IReactiveVariable<Material> _currentMaterial;
        private IReactiveVariable<Material> _highlightedMaterial;
        private IReactiveVariable<Material> _defaultMaterial;
        private List<SpawnWave> _waves;
        private IReactiveVariable<GameBoardPosition> _boardPosition;

        public void Init(IGameEntity entity)
        {
            var gameContext = GameContext.Instance;
            _turn = gameContext.GetTurn();
            _waves = gameContext.GetWaves();

            _boardPosition = entity.GetBoardPosition();
            _currentMaterial = entity.GetCurrentMaterial();
            _highlightedMaterial = entity.GetHighlightedMaterial();
            _defaultMaterial = entity.GetDefaultMaterial();
        }

        public void Enable(in IEntity entity)
        {
            _turn.Observe(OnTurnChanged);
        }

        public void Disable(in IEntity entity)
        {
            _turn.Unsubscribe(OnTurnChanged);
        }

        private void OnTurnChanged(int turn)
        {
            foreach (var wave in _waves)
            {
                if (wave.turn - turn == 0)
                {
                    _currentMaterial.Value = Array.Exists(wave.points, point => _boardPosition.Value == point)
                        ? _highlightedMaterial.Value
                        : _defaultMaterial.Value;

                    return;
                }
            }

            _currentMaterial.Value = _defaultMaterial.Value;
        }
    }
}