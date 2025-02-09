using System.Collections.Generic;
using Game.Common;
using Game.Gameplay;
using NUnit.Framework;
using UnityEngine;

namespace Game.Tests
{
    public partial class GameBoardTests
    {
        [TestCaseSource(nameof(GetPositionsOfItemsCases))]
        public void GetPositionsOfItems(ItemType[,] matrix, ItemType item, List<Vector2Int> expectedPositions)
        {
            //Arrange:
            var board = new GameBoard(matrix);

            //Act:
            List<Vector2Int> positions = board.GetPositionsOfItems(item);

            //Assert:
            Assert.AreEqual(expectedPositions.Count, positions.Count);
            for (var i = 0; i < positions.Count; i++)
            {
                Assert.AreEqual(expectedPositions[i], positions[i]);
            }
        }

        private static IEnumerable<TestCaseData> GetPositionsOfItemsCases()
        {
            yield return new TestCaseData(
                new ItemType[,]
                {
                    { ItemType.Orange, ItemType.Purple },
                    { ItemType.Purple, ItemType.Yellow }
                }.Transpose(),
                ItemType.Purple,
                new List<Vector2Int>()
                {
                    new Vector2Int(1, 0),

                    new Vector2Int(0, 1),
                }
            );

            yield return new TestCaseData(
                new ItemType[,]
                {
                    { ItemType.None, ItemType.None, ItemType.Green },
                    { ItemType.Purple, ItemType.Yellow, ItemType.None }
                }.Transpose(),
                ItemType.None,
                new List<Vector2Int>()
                {
                    new Vector2Int(0, 0),

                    new Vector2Int(0, 1),

                    new Vector2Int(1, 2),
                }
            );

            yield return new TestCaseData(
                new ItemType[,]
                {
                    { ItemType.Orange, ItemType.Purple },
                    { ItemType.Purple, ItemType.Yellow }
                }.Transpose(),
                ItemType.None,
                new List<Vector2Int>()
            );
        }
    }
}