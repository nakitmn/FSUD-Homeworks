using Game.Gameplay;

namespace Game.Tests
{
    public partial class ItemArrangerTests
    {
        private static ItemArranger CreateItemArranger()
        {
            return new ItemArranger(GameBoardTests.CreateGameBoard());
        }
    }
}