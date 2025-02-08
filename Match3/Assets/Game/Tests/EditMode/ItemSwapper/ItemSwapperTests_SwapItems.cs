using System.Collections.Generic;
using Game.Common;
using Game.Gameplay;
using NUnit.Framework;
using UnityEngine;

namespace Game.Tests
{
    public partial class ItemSwapperTests
    {
        [TestCaseSource(nameof(SwapItemsCases))]
        public void SwapItems(GameBoard gameBoard, Vector2Int first, Vector2Int second, bool expectedResult,
            ItemType firstItem, ItemType secondItem)
        {
            //Arrange:
            var itemSwapper = new ItemSwapper(gameBoard);

            //Act:
            bool result = itemSwapper.SwapItems(first, second);

            //Assert:
            Assert.AreEqual(expectedResult, result);
            
            if (result)
            {
                Assert.AreEqual(firstItem, gameBoard.GetItem(first));
                Assert.AreEqual(secondItem, gameBoard.GetItem(second));
            }
        }

        private static IEnumerable<TestCaseData> SwapItemsCases()
        {
            yield return new TestCaseData(
                GameBoardTests.CreateGameBoard(),
                Vector2Int.zero,
                new Vector2Int(1, 0),
                true,
                ItemType.Purple,
                ItemType.Orange
            );
            
            yield return new TestCaseData(
                GameBoardTests.CreateGameBoard(),
                Vector2Int.zero,
                new Vector2Int(0, -1),
                false,
                ItemType.None,
                ItemType.None
            );      
            
            yield return new TestCaseData(
                GameBoardTests.CreateGameBoard(),
                new Vector2Int(1, 1),
                new Vector2Int(1, 0),
                true,
                ItemType.Purple,
                ItemType.Yellow
            );      
            
            yield return new TestCaseData(
                GameBoardTests.CreateGameBoard(),
                new Vector2Int(1, 1),
                Vector2Int.zero,
                false,
                ItemType.None,
                ItemType.None
            );
        }
    }
}