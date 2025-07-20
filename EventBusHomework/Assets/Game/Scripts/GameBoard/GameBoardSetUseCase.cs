namespace SampleGame
{
    public static class GameBoardSetUseCase
    {
        public static bool Set(in IGameContext gameContext, in IGameEntity entity, in int x, in int y)
        {
            var gameBoard = gameContext.GetGameBoard();
            var gameBoardView = gameContext.GetGameBoardView();

            gameBoard.Set(entity, x, y);
            var worldPosition = gameBoardView.ToWorldPosition(x,y);
            entity.GetTransform().position = worldPosition;
            return true;
        }
    }
}