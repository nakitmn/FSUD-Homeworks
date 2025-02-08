using Game.Gameplay;
using NUnit.Framework;

namespace Game.Tests
{
    public partial class ItemArrangerTests
    {
        [Test]
        public void Instantiate()
        {
            //Arrange:
            var gameBoard = GameBoardTests.CreateGameBoard();
            
            //Act:
            var itemArranger = new ItemArranger(gameBoard);
            
            //Assert:
            Assert.NotNull(itemArranger);
        }
    }
}