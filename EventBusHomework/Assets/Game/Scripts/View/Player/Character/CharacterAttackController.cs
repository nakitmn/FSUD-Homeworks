using Atomic.Entities;
using Game.View;
using UnityEngine;

namespace SampleGame
{
    public sealed class CharacterAttackController : IInit<IViewContext>,IUpdate<IViewContext>
    {
        private GameContext _gameContext;

        public void Init(IViewContext context)
        {
            _gameContext = GameContext.Instance;
        }

        public void OnUpdate(IViewContext context, in float deltaTime)
        {
            if (InputUseCase.IsAttack(context) == false)
            {
                return;
            }

            var selectedEntity = context.GetSelectedCharacter().Value;

            if (selectedEntity != null &&
                RaycastUseCase.RaycastTarget(context.GetCamera(), Input.mousePosition, out EntityView target))
            {
                new CharacterAttackCommand(selectedEntity,  
                    GameBoardUseCase.GetBoardPosition(_gameContext, (IGameEntity) target.Entity))
                    .Execute(_gameContext);

                context.GetAnimationQueue().Execute();
            }
        }
    }
}