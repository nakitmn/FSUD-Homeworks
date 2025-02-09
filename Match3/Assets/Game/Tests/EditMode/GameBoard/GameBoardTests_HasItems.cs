using System.Collections.Generic;
using Game.Common;
using Game.Gameplay;
using NUnit.Framework;

namespace Game.Tests
{
    public partial class GameBoardTests
    {
        [TestCaseSource(nameof(HasItemsCases))]
        public bool HasItems(GameBoard board, ItemType item)
        {
            //Arrange:
            //Act:
            //Assert:
            return board.HasItems(item);
        }

        private static IEnumerable<TestCaseData> HasItemsCases()
        {
            yield return new TestCaseData(CreateGameBoard(), ItemType.None).Returns(false);
            yield return new TestCaseData(CreateGameBoard(), ItemType.Blue).Returns(true);
            yield return new TestCaseData(CreateGameBoard(), ItemType.Green).Returns(true);
            yield return new TestCaseData(CreateGameBoard(), ItemType.Orange).Returns(true);
            yield return new TestCaseData(CreateGameBoard(), ItemType.Purple).Returns(true);
            yield return new TestCaseData(CreateGameBoard(), ItemType.Red).Returns(true);
            yield return new TestCaseData(CreateGameBoard(), ItemType.Yellow).Returns(true);
        }
    }
}