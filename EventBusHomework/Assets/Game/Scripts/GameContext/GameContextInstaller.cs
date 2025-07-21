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
        [SerializeField] private GameEntity _enemyPrefab;
        [SerializeField] private int _enemyCountPerTurn = 3;
        [SerializeField] private int _spawnTurnRate = 3;
        
        protected override void Install(IGameContext context)
        {
            context.AddEventBus(_eventBus);
            context.AddGameBoard(new GameBoard(_gameBoardSize.x,_gameBoardSize.y));
            context.AddGameBoardView(_gameBoardView);
            context.AddCamera(_camera);
            context.AddSelectedCharacter(new ReactiveVariable<IGameEntity>());
            context.AddAnimationQueue(new AnimationQueue());
            context.AddTurn(new ReactiveInt(1));
            context.AddCharacters(_characterInstallers.Select(x=>x.character).ToArray());
            
            context.AddSpawnCount(new Const<int>(_enemyCountPerTurn));
            context.AddEnemyPrefab(new Const<GameEntity>(_enemyPrefab));
            context.AddSpawnPoints(new());
            context.AddSpawnTurnRate(new Const<int>(_spawnTurnRate));
            
            context.AddBehaviour(new CharacterSetController(_characterInstallers));
            context.AddBehaviour<CharacterSelectController>();
            context.AddBehaviour<CharacterMoveController>();
            context.AddBehaviour<CharacterAttackController>();
            context.AddBehaviour<StartTurnHandler>();
            context.AddBehaviour<EndTurnHandler>();
        }
    }
}