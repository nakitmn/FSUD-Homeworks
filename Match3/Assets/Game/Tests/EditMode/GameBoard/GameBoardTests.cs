using Game.Common;
using Game.Gameplay;

namespace Game.Tests
{
    public partial class GameBoardTests
    {
        private static GameBoard CreateGameBoard()
        {
            var matrix = new ItemType[,]
            {
                { ItemType.Orange, ItemType.Orange, ItemType.Purple, ItemType.Purple, ItemType.Blue },
                { ItemType.Purple, ItemType.Yellow, ItemType.Purple, ItemType.Green, ItemType.Blue },
                { ItemType.Yellow, ItemType.Red, ItemType.Blue, ItemType.Purple, ItemType.Orange },
                { ItemType.Orange, ItemType.Green, ItemType.Green, ItemType.Purple, ItemType.Blue },
                { ItemType.Orange, ItemType.Green, ItemType.Green, ItemType.Red, ItemType.Red },
                { ItemType.Blue, ItemType.Orange, ItemType.Yellow, ItemType.Red, ItemType.Purple }
            }.Transpose();

            return new GameBoard(matrix);
        }
    }
}