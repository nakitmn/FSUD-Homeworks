using System;
using System.Collections.Generic;
using Atomic.Elements;
using Atomic.Entities;
using Atomic.Events;
using UnityEngine;

namespace SampleGame
{
    [CreateAssetMenu(menuName = "Game/GameContextInstaller")]
    public sealed class GameContextInstaller : ScriptableEntityInstaller<IGameContext>
    {
        [Serializable]
        public class CharacterInstaller
        {
            public ScriptableEntityInstaller character;
            public GameBoardPosition position;
        }
        
        [SerializeField] private Vector2Int _gameBoardSize;
        [SerializeField] private CharacterInstaller[] _characterInstallers;
        [SerializeField] private SpawnWave[] _waves;
        
        protected override void Install(IGameContext entity)
        {
            entity.AddEventBus(new EventBus());
            entity.AddGameBoard(new GameBoard(_gameBoardSize.x,_gameBoardSize.y));
            entity.AddTurn(new ReactiveInt(1));
            entity.AddWaves(new List<SpawnWave>(_waves));
            entity.AddCurrentState(new ReactiveVariable<GameState>(GameState.Running));
            
            entity.AddBehaviour<StartPlayerTurnHandler>();
            entity.AddBehaviour<EndPlayerTurnHandler>();
            entity.AddBehaviour<StartEnemyTurnHandler>();
            entity.AddBehaviour<EndEnemyTurnHandler>();

            entity.WhenEnable(() =>
            {
                foreach (var installer in _characterInstallers)
                {
                    SpawnEntityUseCase.Spawn(entity, installer.character, installer.position);
                }
                
                entity.GetEventBus().InvokeStartPlayerTurn();
            });
        }
    }
}