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
        
        protected override void Install(IViewContext entity)
        {
            entity.AddCamera(_camera);
            entity.AddAnimationQueue(new AnimationQueue());
            entity.AddWorldView(_entityWorldView);
            entity.AddGameBoardPresenter(_gameBoardPresenter);
            
            entity.AddBehaviour<TurnAnimationsPresenter>();
            entity.AddBehaviour<DealDamagePresenter>();
            entity.AddBehaviour<MovePresenter>();
            entity.AddBehaviour<PushPresenter>();
        }
    }
}