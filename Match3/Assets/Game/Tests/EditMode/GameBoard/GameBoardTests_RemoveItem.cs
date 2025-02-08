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
        [TestCaseSource(nameof(RemoveItemCases))]
        public void RemoveItem(GameBoard board, Vector2Int removePosition, bool expectedResult,
            ItemType expectedRemovedItem)
        {
            //Arrange:
            //Act:
            bool result = board.RemoveItem(removePosition, out ItemType item);

            //Assert:
            Assert.AreEqual(expectedResult, result);
            Assert.AreEqual(expectedRemovedItem, item);
            
            if (result)
            {
                Assert.AreEqual(ItemType.None, board.GetItem(removePosition));
            }
        }

        private static IEnumerable<TestCaseData> RemoveItemCases()
        {
            yield return new TestCaseData(
                CreateGameBoard(),
                Vector2Int.zero,
                true,
                ItemType.Orange
            );

            yield return new TestCaseData(
                CreateGameBoard(),
                new Vector2Int(5, 4),
                true,
                ItemType.Purple
            );

            yield return new TestCaseData(
                new GameBoard(6, 6),
                new Vector2Int(3, 3),
                false,
                ItemType.None
            );
        }
        
        [TestCase(-1, 0)]
        [TestCase(-1, -1)]
        [TestCase(0, -1)]
        [TestCase(6, 4)]
        [TestCase(3, 5)]
        public void WhenRemoveItemAtInvalidPositionThenThrows(int x, int y)
        {
            //Arrange:
            var board = CreateGameBoard();
            var position = new Vector2Int(x, y);

            //Act:
            //Assert:
            Assert.Throws<ArgumentException>(() => board.RemoveItem(position, out _));
        }
    }
}