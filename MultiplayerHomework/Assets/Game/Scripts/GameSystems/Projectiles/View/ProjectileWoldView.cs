using Fusion;
using UnityEngine;
using Zenject;

namespace Game
{
    public sealed class ProjectileWorldView : NetworkBehaviour
    {
        [SerializeField]
        private ProjectileWorld _world;

        [SerializeField]
        private Transform _container;

        private ProjectileView[] _projectileViews;

        private ProjectileViewPool _viewPool;

        [Inject]
        public void Construct(ProjectileViewPool viewPool)
        {
            _viewPool = viewPool;
        }
        
        private void Awake()
        {
            _projectileViews = new ProjectileView[_world.Length];
        }

        public override void Render()
        {
            NetworkRunner runner = this.Runner;
            float renderTime = this.Object.IsProxy 
                ? this.Runner.RemoteRenderTime 
                : this.Runner.LocalRenderTime + this.Runner.DeltaTime;
            
            PlayerRef player = this.Object.InputAuthority;

            for (int i = 0; i < _world.Length; i++)
            {
                ProjectileState projectile = _world.GetProjectile(i);
                bool hasProjectile = projectile.IsActive;

                ProjectileView projectileView = _projectileViews[i];
                bool hasView = projectileView != null;

                if (hasProjectile && !hasView)
                {
                    //Spawn view
                    projectileView = _viewPool.Rent(projectile.type, _container);
                    projectileView.OnSpawn(in projectile, in runner, in player, in renderTime);
                    _projectileViews[i] = projectileView;
                }
                else if (hasView && !hasProjectile)
                {
                    //Unspawn view:
                    projectileView.OnUnspawn(in runner, in player);
                    _viewPool.Return(projectileView);
                    _projectileViews[i] = null;
                }
                else if (hasProjectile)
                {
                    //Update view:
                    projectileView.OnUpdate(in projectile, in runner, in player, in renderTime);
                }
            }
        }
    }
}