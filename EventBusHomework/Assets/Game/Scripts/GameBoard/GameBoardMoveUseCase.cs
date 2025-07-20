namespace SampleGame
{
    public static class GameBoardMoveUseCase
    {
        public static bool Move(in IGameContext gameContext, in IGameEntity entity, in int x, in int y)
        {
            var gameBoard = gameContext.GetGameBoard();

            if (gameBoard.IsFree(x, y) == false)
            {
                return false;
            }

            return GameBoardSetUseCase.Set(gameContext, entity, x, y);
        }
    }
}