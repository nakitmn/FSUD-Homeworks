namespace SampleGame
{
    public static class GameBoardSetUseCase
    {
        public static bool Set(in IGameContext gameContext, in IGameEntity entity, in GameBoardPosition position)
        {
            var gameBoard = gameContext.GetGameBoard();
            if (gameBoard.Move(entity, position))
            {
                var worldPosition = GameBoardMoveUseCase.GetWorldPosition(gameContext,position);
                entity.GetTransform().position = worldPosition;
                return true;
            }

            return false;
        }
    }
}