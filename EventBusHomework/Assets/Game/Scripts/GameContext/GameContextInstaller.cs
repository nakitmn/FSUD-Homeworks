using System.Collections.Generic;
using System.Linq;
using Atomic.Elements;
using Atomic.Entities;
using Atomic.Events;
using UnityEngine;

namespace SampleGame
{
    public sealed class GameContextInstaller : SceneEntityInstaller<IGameContext>
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private SceneEventBus _eventBus;
        [SerializeField] private Vector2Int _gameBoardSize;
        [SerializeField] private GameBoardView _gameBoardView;
        [SerializeField] private CharacterSetController.CharacterInstaller[] _characterInstallers;
        [SerializeField] private SpawnWave[] _waves;
        
        protected override void Install(IGameContext entity)
        {
            entity.AddEventBus(_eventBus);
            entity.AddGameBoard(new GameBoard(_gameBoardSize.x,_gameBoardSize.y));
            entity.AddGameBoardView(_gameBoardView);
            entity.AddCamera(_camera);
            entity.AddSelectedCharacter(new ReactiveVariable<IGameEntity>());
            entity.AddAnimationQueue(new AnimationQueue());
            entity.AddTurn(new ReactiveInt(1));
            entity.AddCharacters(_characterInstallers.Select(x=>x.character).ToArray());
            
            entity.AddEnemies(new());
            entity.AddWaves(new List<SpawnWave>(_waves));
            
            entity.AddBehaviour(new CharacterSetController(_characterInstallers));
            entity.AddBehaviour<CharacterSelectController>();
            entity.AddBehaviour<CharacterMoveController>();
            entity.AddBehaviour<CharacterAttackController>();
            entity.AddBehaviour<StartTurnHandler>();
            entity.AddBehaviour<EndTurnHandler>();
            
            entity.AddCurrentState(new ReactiveVariable<GameState>(GameState.Running));
        }
    }
}