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
        [TestCaseSource(nameof(InstantiateCases))]
        public void Instantiate(int width, int height)
        {
            //Arrange:
            //Act:
            var board = new GameBoard(width, height);

            //Assert:
            Assert.NotNull(board);
            Assert.AreEqual(width, board.Width);
            Assert.AreEqual(height, board.Height);
        }

        private static IEnumerable<TestCaseData> InstantiateCases()
        {
            yield return new TestCaseData(5, 6);
            yield return new TestCaseData(1, 9);
            yield return new TestCaseData(5, 1);
        }

        [TestCaseSource(nameof(InstantiateWithItemsCases))]
        public void InstantiateWithItems(int width, int height, KeyValuePair<ItemType, Vector2Int>[] items)
        {
            //Arrange:
            //Act:
            var board = new GameBoard(width, height, items);

            //Assert:
            Assert.NotNull(board);
            Assert.AreEqual(width, board.Width);
            Assert.AreEqual(height, board.Height);

            foreach (var (item, position) in items)
            {
                Assert.AreEqual(item, board.GetItem(position));
            }
        }

        private static IEnumerable<TestCaseData> InstantiateWithItemsCases()
        {
            yield return new TestCaseData(5, 6,
                new[]
                {
                    new KeyValuePair<ItemType, Vector2Int>(ItemType.Red, new Vector2Int(0, 0)),
                    new KeyValuePair<ItemType, Vector2Int>(ItemType.Yellow, new Vector2Int(1, 0)),
                    new KeyValuePair<ItemType, Vector2Int>(ItemType.Blue, new Vector2Int(1, 1)),
                }
            );
            yield return new TestCaseData(1, 9,
                new[]
                {
                    new KeyValuePair<ItemType, Vector2Int>(ItemType.Red, new Vector2Int(0, 0)),
                    new KeyValuePair<ItemType, Vector2Int>(ItemType.Yellow, new Vector2Int(1, 0)),
                    new KeyValuePair<ItemType, Vector2Int>(ItemType.Blue, new Vector2Int(2, 0)),
                }
            );
            yield return new TestCaseData(5, 1,
                new[]
                {
                    new KeyValuePair<ItemType, Vector2Int>(ItemType.Red, new Vector2Int(0, 0)),
                    new KeyValuePair<ItemType, Vector2Int>(ItemType.Yellow, new Vector2Int(0, 4)),
                    new KeyValuePair<ItemType, Vector2Int>(ItemType.Blue, new Vector2Int(0, 3)),
                }
            );
        }

        [TestCaseSource(nameof(InstantiateWithMatrixCases))]
        public void InstantiateWithMatrix(ItemType[,] matrix, int expectedWidth, int expectedHeight)
        {
            //Arrange:
            //Act:
            var board = new GameBoard(matrix);

            //Assert:
            Assert.NotNull(board);
            Assert.AreEqual(expectedWidth, board.Width);
            Assert.AreEqual(expectedHeight, board.Height);

            for (var col = 0; col < matrix.GetLength(0); col++)
            {
                for (var row = 0; row < matrix.GetLength(1); row++)
                {
                    var position = new Vector2Int(row, col);
                    Assert.AreEqual(matrix[col, row], board.GetItem(position));
                }
            }
        }

        private static IEnumerable<TestCaseData> InstantiateWithMatrixCases()
        {
            yield return new TestCaseData(
                new ItemType[,]
                {
                    { ItemType.Orange, ItemType.Orange, ItemType.Purple, ItemType.Purple, ItemType.Blue },
                    { ItemType.Purple, ItemType.Yellow, ItemType.Purple, ItemType.Green, ItemType.Blue },
                    { ItemType.Yellow, ItemType.Red, ItemType.Blue, ItemType.Purple, ItemType.Orange },
                    { ItemType.Orange, ItemType.Green, ItemType.Green, ItemType.Purple, ItemType.Blue },
                    { ItemType.Orange, ItemType.Green, ItemType.Green, ItemType.Red, ItemType.Red },
                    { ItemType.Blue, ItemType.Orange, ItemType.Yellow, ItemType.Red, ItemType.Purple }
                }.Transpose(),
                5, 6
            );

            yield return new TestCaseData(
                new ItemType[,]
                {
                    { ItemType.Orange, ItemType.Green },
                    { ItemType.Green, ItemType.Yellow }
                }.Transpose(),
                2, 2
            );

            yield return new TestCaseData(
                new ItemType[,]
                {
                    { ItemType.Orange, ItemType.Green, ItemType.Blue },
                    { ItemType.Green, ItemType.Yellow, ItemType.Red }
                }.Transpose(),
                3, 2
            );
        }

        [Test]
        public void WhenInstantiateWithNullItemsThenThrows()
        {
            //Arrange:
            //Act:
            //Assert:
            Assert.Throws<NullReferenceException>(() => new GameBoard(5, 5, null));
        }

        [Test]
        public void WhenInstantiateWithNullMatrixThenThrows()
        {
            //Arrange:
            //Act:
            //Assert:
            Assert.Throws<NullReferenceException>(() => new GameBoard(null));
        }

        [Test]
        public void WhenInstantiateWithInvalidMatrixThenThrows()
        {
            //Arrange:
            //Act:
            //Assert:
            Assert.Throws<ArgumentException>(() =>
            {
                var matrix = new ItemType[0, 0];
                new GameBoard(matrix);
            });

            Assert.Throws<ArgumentException>(() =>
            {
                var matrix = new ItemType[1, 0];
                new GameBoard(matrix);
            });
            
            Assert.Throws<ArgumentException>(() =>
            {
                var matrix = new ItemType[0, 1];
                new GameBoard(matrix);
            });
        }
        
        [Test]
        public void WhenInstantiateWithInvalidSizeThenThrows()
        {
            //Arrange:
            //Act:
            //Assert:
            Assert.Throws<ArgumentException>(() => new GameBoard(0, 0));
            Assert.Throws<ArgumentException>(() => new GameBoard(1, 0));
            Assert.Throws<ArgumentException>(() => new GameBoard(0, 1)); 
        }
    }
}