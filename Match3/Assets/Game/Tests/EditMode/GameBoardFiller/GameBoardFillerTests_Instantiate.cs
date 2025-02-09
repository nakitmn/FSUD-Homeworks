using Game.Gameplay;
using NUnit.Framework;

namespace Game.Tests
{
    public partial class GameBoardFillerTests
    {
        [Test]
        public void Instantiate()
        {
            //Arrange:
            var gameBoard = GameBoardTests.CreateGameBoard();
            
            //Act:
            var gameBoardFiller = new GameBoardFiller(gameBoard);
            
            //Assert:
            Assert.NotNull(gameBoardFiller);
        }
    }
}