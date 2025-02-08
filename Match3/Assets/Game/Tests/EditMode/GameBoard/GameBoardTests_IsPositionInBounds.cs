using System.Collections.Generic;
using Game.Gameplay;
using NUnit.Framework;
using UnityEngine;

namespace Game.Tests
{
    public partial class GameBoardTests
    {
        [TestCaseSource(nameof(IsPositionInBoundsCases))]
        public void IsPositionInBounds(GameBoard board, Vector2Int position, bool expectedResult)
        {
            //Arrange:
            //Act:
            var result = board.IsPositionInBounds(position);

            //Assert:
            Assert.AreEqual(expectedResult, result);
        }

        private static IEnumerable<TestCaseData> IsPositionInBoundsCases()
        {
            yield return new TestCaseData(CreateGameBoard(), Vector2Int.zero, true);
            yield return new TestCaseData(CreateGameBoard(), new Vector2Int(5, 4), true);
            yield return new TestCaseData(CreateGameBoard(), new Vector2Int(3, 3), true);
            yield return new TestCaseData(CreateGameBoard(), new Vector2Int(4, 5), false);
            yield return new TestCaseData(CreateGameBoard(), new Vector2Int(-1, 3), false);
            yield return new TestCaseData(CreateGameBoard(), new Vector2Int(1, -1), false);
        }
    }
}