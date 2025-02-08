using System;
using System.Collections.Generic;
using Game.Common;
using Game.Gameplay;
using NUnit.Framework;
using UnityEngine;

namespace Game.Tests
{
    public partial class GameBoardTests
    {
        [TestCaseSource(nameof(SetItemCases))]
        public void SetItem(GameBoard board, Vector2Int setPosition, ItemType setItem)
        {
            //Arrange:
            //Act:
            board.SetItem(setItem, setPosition);

            //Assert:
            Assert.AreEqual(setItem, board.GetItem(setPosition));
        }

        private static IEnumerable<TestCaseData> SetItemCases()
        {
            yield return new TestCaseData(
                new GameBoard(5, 6),
                Vector2Int.zero,
                ItemType.Red
            );

            yield return new TestCaseData(
                new GameBoard(5, 6),
                new Vector2Int(5, 4),
                ItemType.Green
            );

            yield return new TestCaseData(
                new GameBoard(5, 1),
                new Vector2Int(0, 4),
                ItemType.Yellow
            );

            yield return new TestCaseData(
                new GameBoard(1, 10),
                new Vector2Int(9, 0),
                ItemType.Blue
            );
        }

        [TestCase(-1, 0)]
        [TestCase(-1, -1)]
        [TestCase(0, -1)]
        [TestCase(6, 4)]
        [TestCase(3, 5)]
        public void WhenSetItemAtInvalidPositionThenThrows(int x, int y)
        {
            //Arrange:
            var board = CreateGameBoard();
            var position = new Vector2Int(x, y);

            //Act:
            //Assert:
            Assert.Throws<ArgumentException>(() => board.SetItem(ItemType.Red, position));
        }
    }
}