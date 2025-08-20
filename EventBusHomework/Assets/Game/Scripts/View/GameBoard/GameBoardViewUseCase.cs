using Game.Core;
using UnityEngine;

namespace Game.View
{
    public static class GameBoardViewUseCase
    {
        public static Vector3 GetWorldPosition(IViewContext context, GameBoardPosition position)
        {
            return context.GetGameBoardView().ToWorldPosition(position.x, position.y);
        }
    }
}