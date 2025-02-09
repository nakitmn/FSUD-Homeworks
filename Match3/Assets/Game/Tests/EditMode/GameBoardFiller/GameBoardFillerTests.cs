using Game.Gameplay;

namespace Game.Tests
{
    public partial class GameBoardFillerTests
    {
        private static GameBoardFiller CreateGameBoardFiller()
        {
            return new(GameBoardTests.CreateGameBoard());
        }
    }
}