using Game.Gameplay;
using NUnit.Framework;

namespace Game.Tests
{
    public partial class ItemSwapperTests
    {
        [Test]
        public void Instantiate()
        {
            //Arrange:
            GameBoard gameBoard = GameBoardTests.CreateGameBoard();

            //Act:
            var itemSwapper = new ItemSwapper(gameBoard);
            
            //Assert:
            Assert.NotNull(itemSwapper);
        }
    }
}