using Atomic.Elements;
using Atomic.Entities;
using SampleGame;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Game.View
{
    public sealed class ViewContextInstaller : SceneEntityInstaller<IViewContext>
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private EntityWorldView _entityWorldView;
        [SerializeField] private GameBoardView _gameBoardView;
        [SerializeField] private SelectedMarkerView _markerView;
        
        [Header("UI")]
        [SerializeField] private TMP_Text _turnEventsText;
        [SerializeField] private TMP_Text _selectedCharacterInfoText;
        [SerializeField] private TMP_Text _gameStateText;
        [SerializeField] private TMP_Text _currentTurnText;
        [SerializeField] private Button _endTurnButton;
        
        protected override void Install(IViewContext entity)
        {
            entity.AddCamera(_camera);
            entity.AddAnimationQueue(new AnimationQueue());
            entity.AddWorldView(_entityWorldView);
            entity.AddGameBoardView(_gameBoardView);
            entity.AddSelectedCharacter(new ReactiveVariable<IGameEntity>());
            entity.AddInputCondition(new BaseFunction<bool>(() => entity.GetAnimationQueue().IsActive == false));
            
            entity.AddBehaviour<PlayerTurnStartObserver>();
            entity.AddBehaviour<EnemyTurnEndObserver>();
            entity.AddBehaviour<DealDamageEntityObserver>();
            entity.AddBehaviour<MoveEntityObserver>();
            entity.AddBehaviour<AttackEntityObserver>();
            entity.AddBehaviour<PushEntityObserver>();
            entity.AddBehaviour<DieEntityObserver>();
            entity.AddBehaviour<SpawnEntityObserver>();
            
            entity.AddBehaviour<CharacterAttackController>();
            entity.AddBehaviour<CharacterMoveController>();
            entity.AddBehaviour<CharacterSelectController>();
            
            entity.AddBehaviour<GameBoardPresenter>();
            
            entity.AddBehaviour(new SelectedCharacterBehavior(_markerView));
            
            entity.AddBehaviour(new TurnEventsPresenter(_turnEventsText));
            entity.AddBehaviour(new SelectedCharacterPresenter(_selectedCharacterInfoText));
            entity.AddBehaviour(new GameStatePresenter(_gameStateText));
            entity.AddBehaviour(new CurrentTurnPresenter(_currentTurnText));
            entity.AddBehaviour(new EndTurnButtonPresenter(_endTurnButton));
        }
    }
}