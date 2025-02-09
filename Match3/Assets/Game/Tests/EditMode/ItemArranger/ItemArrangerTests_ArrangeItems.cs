using System.Collections.Generic;
using Game.Common;
using Game.Gameplay;
using NUnit.Framework;
using UnityEngine;

namespace Game.Tests
{
    public partial class ItemArrangerTests
    {
        [TestCaseSource(nameof(ArrangeItemsCases))]
        public void ArrangeItems(ItemType[,] boardMatrix, ItemType[,] targetMatrix,
            Dictionary<Vector2Int, Vector2Int> targetResult)
        {
            //Arrange:
            var gameBoard = new GameBoard(boardMatrix);
            var itemArranger = new ItemArranger(gameBoard);

            //Act:
            Dictionary<Vector2Int, Vector2Int> result = itemArranger.Arrange();

            //Assert:
            Assert.IsTrue(gameBoard.AreSame(targetMatrix));
            Assert.IsTrue(targetResult.AreSame(result));
        }

        private static IEnumerable<TestCaseData> ArrangeItemsCases()
        {
            yield return new TestCaseData(
                new ItemType[,]
                {
                    { ItemType.Red, ItemType.Orange, ItemType.None },
                    { ItemType.Purple, ItemType.None, ItemType.None },
                    { ItemType.None, ItemType.None, ItemType.Blue }
                }.Transpose(),
                new ItemType[,]
                {
                    { ItemType.None, ItemType.None, ItemType.None },
                    { ItemType.Red, ItemType.None, ItemType.None },
                    { ItemType.Purple, ItemType.Orange, ItemType.Blue }
                }.Transpose(),
                new Dictionary<Vector2Int, Vector2Int>()
                {
                    { new Vector2Int(1, 0), new Vector2Int(2, 0) },
                    { new Vector2Int(0, 0), new Vector2Int(1, 0) },
                    { new Vector2Int(0, 1), new Vector2Int(2, 1) }
                }
            );
            
            yield return new TestCaseData(
                new ItemType[,]
                {
                    { ItemType.Orange, ItemType.Orange, ItemType.Blue },
                    { ItemType.None, ItemType.Green, ItemType.None },
                    { ItemType.Blue, ItemType.Green, ItemType.None },
                    { ItemType.Red, ItemType.Orange, ItemType.Red },
                    { ItemType.Purple, ItemType.None, ItemType.None },
                    { ItemType.None, ItemType.None, ItemType.Blue }
                }.Transpose(),
                new ItemType[,]
                {
                    { ItemType.None, ItemType.None, ItemType.None },
                    { ItemType.None, ItemType.None, ItemType.None },
                    { ItemType.Orange, ItemType.Orange, ItemType.None },
                    { ItemType.Blue, ItemType.Green, ItemType.Blue },
                    { ItemType.Red, ItemType.Green, ItemType.Red },
                    { ItemType.Purple, ItemType.Orange, ItemType.Blue }
                }.Transpose(),
                new Dictionary<Vector2Int, Vector2Int>()
                {
                    { new Vector2Int(4, 0), new Vector2Int(5, 0) },
                    { new Vector2Int(3, 0), new Vector2Int(4, 0) },
                    { new Vector2Int(2, 0), new Vector2Int(3, 0) },
                    { new Vector2Int(0, 0), new Vector2Int(2, 0) },
                    
                    { new Vector2Int(3, 1), new Vector2Int(5, 1) },
                    { new Vector2Int(2, 1), new Vector2Int(4, 1) },
                    { new Vector2Int(1, 1), new Vector2Int(3, 1) },
                    { new Vector2Int(0, 1), new Vector2Int(2, 1) },
                    
                    { new Vector2Int(3, 2), new Vector2Int(4, 2) },
                    { new Vector2Int(0, 2), new Vector2Int(3, 2) },
                }
            );
        }
    }
}