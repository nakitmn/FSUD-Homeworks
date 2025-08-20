using System.Collections.Generic;
using Atomic.Elements;
using Atomic.Entities;
using Atomic.Events;
using UnityEngine;

namespace Game.Core
{
    [CreateAssetMenu(menuName = "Game/GameContextInstaller")]
    public sealed class GameContextInstaller : ScriptableEntityInstaller<IGameContext>
    {
        [SerializeField] private Vector2Int _gameBoardSize;
        [SerializeField] private EntitySpawnConfig[] _characterSpawnConfigs;
        [SerializeField] private EnemyWaveConfig[] _waves;
        
        protected override void Install(IGameContext entity)
        {
            entity.AddEventBus(new EventBus());
            entity.AddGameBoard(new GameBoard(_gameBoardSize.x,_gameBoardSize.y));
            entity.AddTurn(new ReactiveInt(1));
            entity.AddWaves(new List<EnemyWaveConfig>(_waves));
            entity.AddCurrentState(new ReactiveVariable<GameState>(GameState.Running));
            
            entity.AddBehaviour(new GameStartController(_characterSpawnConfigs));
            
            entity.AddBehaviour<StartPlayerTurnHandler>();
            entity.AddBehaviour<EndPlayerTurnHandler>();
            entity.AddBehaviour<StartEnemyTurnHandler>();
            entity.AddBehaviour<EndEnemyTurnHandler>();
        }
    }
}