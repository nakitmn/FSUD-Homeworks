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
        [SerializeField] private GameBoardPresenter _gameBoardPresenter;
        [SerializeField] private SelectedMarkerView _markerView;
        
        protected override void Install(IViewContext entity)
        {
            entity.AddCamera(_camera);
            entity.AddAnimationQueue(new AnimationQueue());
            entity.AddWorldView(_entityWorldView);
            entity.AddGameBoardPresenter(_gameBoardPresenter);
            entity.AddSelectedCharacter(new ReactiveVariable<IGameEntity>());
            entity.AddInputCondition(new BaseFunction<bool>(() => entity.GetAnimationQueue().IsActive == false));
            
            entity.AddBehaviour<TurnsObserver>();
            entity.AddBehaviour<DealDamageObserver>();
            entity.AddBehaviour<MoveObserver>();
            entity.AddBehaviour<AttackObserver>();
            entity.AddBehaviour<PushObserver>();
            entity.AddBehaviour<DieObserver>();
            entity.AddBehaviour<SpawnObserver>();
            
            entity.AddBehaviour<CharacterAttackController>();
            entity.AddBehaviour<CharacterMoveController>();
            entity.AddBehaviour<CharacterSelectController>();
            
            entity.AddBehaviour(new SelectedCharacterBehavior(_markerView));
        }
    }
}