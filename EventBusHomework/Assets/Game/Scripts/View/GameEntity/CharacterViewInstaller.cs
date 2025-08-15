using Atomic.Entities;
using UnityEngine;

namespace Game.View
{
    public sealed class CharacterViewInstaller : EntityViewInstaller
    {
        [SerializeField] private ProgressBarPro _healthBar;
        
        public override void Install(EntityView view)
        {
            var entity = view.Entity;
            
            view.AddBehaviour(new GameEntityHealthPresenter(_healthBar));
        }
    }
}