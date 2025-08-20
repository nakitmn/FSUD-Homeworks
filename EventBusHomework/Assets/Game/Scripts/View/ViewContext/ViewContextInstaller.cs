using Atomic.Elements;
using Atomic.Entities;
using Game.Core;
using SampleGame;
using UnityEngine;

namespace Game.View
{
    public sealed class ViewContextInstaller : SceneEntityInstaller<IViewContext>
    {
        [SerializeField] private Transform _poolContainer;
        [SerializeField] private GameObject _waterSplash;
        [SerializeField] private GameObject _deathEffect;
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
            entity.AddPrefabPool(new GenericPrefabPool(_poolContainer));
            entity.AddWaterSplashEffect(_waterSplash);
            entity.AddDeathEffect(_deathEffect);
            
            entity.AddSelectedCharacter(new ReactiveVariable<IGameEntity>());
            entity.AddInputCondition(new BaseFunction<bool>(() => entity.GetAnimationQueue().IsActive == false));
            
            _gameBoardInstaller.Install(entity);
            _uiInstaller.Install(entity);
            
            entity.AddBehaviour(new SelectedMarkerPresenter(_markerView));

            entity.AddBehaviour<PlayerTurnStartObserver>();
            entity.AddBehaviour<EnemyTurnStartObserver>();
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
            
            entity.AddBehaviour<SelectedCharacterCellsPresenter>();
        }
    }
}