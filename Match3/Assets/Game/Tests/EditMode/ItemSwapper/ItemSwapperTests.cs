using Game.Gameplay;

namespace Game.Tests
{
    public partial class ItemSwapperTests
    {
        private static ItemSwapper CreateItemSwapper()
        {
            return new ItemSwapper(GameBoardTests.CreateGameBoard());
        }
    }
}