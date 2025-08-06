using Game.View;
using UnityEngine;

namespace SampleGame
{
    public static class GameBoardViewUseCase
    {
        public static Vector3 GetWorldPosition(IViewContext context, GameBoardPosition position)
        {
            return context.GetGameBoardView().ToWorldPosition(position.x, position.y);
        }
    }
}