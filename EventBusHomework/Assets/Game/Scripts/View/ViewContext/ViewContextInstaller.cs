using Atomic.Elements;
using Atomic.Entities;
using SampleGame;
using UnityEngine;

namespace Game.View
{
    public sealed class ViewContextInstaller : SceneEntityInstaller<IViewContext>
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private EntityWorldView _entityWorldView;
        [SerializeField] private SelectedMarkerView _markerView;
        [SerializeField] private GameBoardInstaller _gameBoardInstaller;
        [SerializeField] private UiInstaller _uiInstaller;
        
        protected override void Install(IViewContext entity)
        {
            entity.AddCamera(_camera);
            entity.AddAnimationQueue(new AnimationQueue());
            entity.AddWorldView(_entityWorldView);
           
            entity.AddSelectedCharacter(new ReactiveVariable<IGameEntity>());
            entity.AddInputCondition(new BaseFunction<bool>(() => entity.GetAnimationQueue().IsActive == false));
            
            _gameBoardInstaller.Install(entity);
            _uiInstaller.Install(entity);
            
            entity.AddBehaviour(new SelectedCharacterPresenter(_markerView));

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
        }
    }
}