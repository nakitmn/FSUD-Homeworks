using Atomic.Entities;
using UnityEngine;

namespace SampleGame
{
    public sealed class AbilitySelectBehaviour : IInit<IGameContext>, IUpdate<IGameContext>
    {
        private PlayerAbilitiesPresenter _abilitiesPresenter;

        public void Init(IGameContext context)
        {
            _abilitiesPresenter = context.GetAbilitiesPresenter();
        }

        public void OnUpdate(IGameContext context, in float deltaTime)
        {
            if (InputUseCase.TryGetAbilitySelectButtonIndex(context, out var index))
            {
                _abilitiesPresenter.SelectActivePresenter(index);
            }
        }
    }
}