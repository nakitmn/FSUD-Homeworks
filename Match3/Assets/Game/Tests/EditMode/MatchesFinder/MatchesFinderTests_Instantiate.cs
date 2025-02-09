using Game.Gameplay;
using NUnit.Framework;

namespace Game.Tests
{
    public partial class MatchesFinderTests
    {
        [Test]
        public void Instantiate()
        {
            //Arrange:
            var board = GameBoardTests.CreateGameBoard();
            
            //Act:
            var matchesFinder = new MatchesFinder(board);
            
            //Assert:
            Assert.NotNull(matchesFinder);
        }
    }
}