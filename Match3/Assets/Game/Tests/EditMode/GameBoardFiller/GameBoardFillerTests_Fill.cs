using System.Collections.Generic;
using Game.Common;
using Game.Gameplay;
using NUnit.Framework;
using UnityEngine;

namespace Game.Tests
{
    public partial class GameBoardFillerTests
    {
        [TestCaseSource(nameof(FillCases))]
        public void Fill(ItemType[,] boardMatrix, List<Vector2Int> expectedFillPositions)
        {
            //Arrange:
            var board = new GameBoard(boardMatrix);
            var gameBoardFiller = new GameBoardFiller(board);

            //Act:
            Dictionary<Vector2Int, ItemType> result = gameBoardFiller.Fill();

            //Assert:
            Assert.IsFalse(board.HasItems(ItemType.None));
            Assert.AreEqual(expectedFillPositions.Count, result.Count);
            foreach (var (position, item) in result)
            {
                Assert.IsTrue(expectedFillPositions.Contains(position));
                Assert.AreNotEqual(ItemType.None, item);
            }
        }

        private static IEnumerable<TestCaseData> FillCases()
        {
            yield return new TestCaseData(
                new ItemType[,]
                {
                    { ItemType.Red, ItemType.Orange },
                    { ItemType.Purple, ItemType.None },
                    { ItemType.Yellow, ItemType.Red }
                }.Transpose(),
                new List<Vector2Int>()
                {
                    new Vector2Int(1, 1),
                }
            );

            yield return new TestCaseData(
                new ItemType[,]
                {
                    { ItemType.Red, ItemType.Orange, ItemType.None },
                    { ItemType.Purple, ItemType.None, ItemType.None },
                    { ItemType.None, ItemType.None, ItemType.Blue }
                }.Transpose(),
                new List<Vector2Int>()
                {
                    new Vector2Int(2, 0),

                    new Vector2Int(1, 1),
                    new Vector2Int(2, 1),

                    new Vector2Int(0, 2),
                    new Vector2Int(1, 2)
                }
            );

            yield return new TestCaseData(
                new ItemType[,]
                {
                    { ItemType.Red, ItemType.Orange, ItemType.Red },
                    { ItemType.Purple, ItemType.Red, ItemType.Red },
                    { ItemType.Red, ItemType.Red, ItemType.Blue }
                }.Transpose(),
                new List<Vector2Int>()
            );
        }
    }
}