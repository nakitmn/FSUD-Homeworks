using Game.View;
using UnityEngine;

namespace SampleGame
{
    public static class GameBoardViewUseCase
    {
        /*public static Vector3 GetWorldPosition(IViewContext context, IGameEntity entity)
        {
            var gameBoard = context.GetGameBoardPresenter();
            gameBoard.TryGetPosition(entity, out var entityPosition);
            return GetWorldPosition(context, entityPosition);
        }*/

        public static Vector3 GetWorldPosition(IViewContext context, GameBoardPosition position)
        {
            var presenter = context.GetGameBoardPresenter();
            return presenter.ToWorldPosition(position.x, position.y);
        }
    }
}