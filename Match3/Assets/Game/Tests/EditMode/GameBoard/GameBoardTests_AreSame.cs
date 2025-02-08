using System.Collections.Generic;
using Game.Common;
using Game.Gameplay;
using NUnit.Framework;

namespace Game.Tests
{
    public partial class GameBoardTests
    {
        [TestCaseSource(nameof(AreSameCases))]
        public bool AreSame(ItemType[,] createMatrix, ItemType[,] compareMatrix)
        {
            //Arrange:
            var gameBoard = new GameBoard(createMatrix);

            //Act:
            //Assert;
            return gameBoard.AreSame(compareMatrix);
        }

        private static IEnumerable<TestCaseData> AreSameCases()
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
                new ItemType[,]
                {
                    { ItemType.Orange, ItemType.Orange, ItemType.Purple, ItemType.Purple, ItemType.Blue },
                    { ItemType.Purple, ItemType.Yellow, ItemType.Purple, ItemType.Green, ItemType.Blue },
                    { ItemType.Yellow, ItemType.Red, ItemType.Blue, ItemType.Purple, ItemType.Orange },
                    { ItemType.Orange, ItemType.Green, ItemType.Green, ItemType.Purple, ItemType.Blue },
                    { ItemType.Orange, ItemType.Green, ItemType.Green, ItemType.Red, ItemType.Red },
                    { ItemType.Blue, ItemType.Orange, ItemType.Yellow, ItemType.Red, ItemType.Purple }
                }.Transpose()
            ).Returns(true);

            yield return new TestCaseData(
                new ItemType[,]
                {
                    { ItemType.Orange, ItemType.Purple },
                    { ItemType.Purple, ItemType.Yellow }
                }.Transpose(),
                new ItemType[,]
                {
                    { ItemType.None, ItemType.Purple },
                    { ItemType.Purple, ItemType.Yellow }
                }.Transpose()
            ).Returns(false);

            yield return new TestCaseData(
                new ItemType[,]
                {
                    { ItemType.Orange, ItemType.Purple },
                    { ItemType.Purple, ItemType.Yellow }
                }.Transpose(),
                new ItemType[,]
                {
                    { ItemType.Orange, ItemType.Purple, ItemType.Green },
                    { ItemType.Purple, ItemType.Yellow, ItemType.None }
                }.Transpose()
            ).Returns(false);

            yield return new TestCaseData(
                new ItemType[,]
                {
                    { ItemType.Orange, ItemType.Purple, ItemType.Green },
                    { ItemType.Purple, ItemType.Yellow, ItemType.None }
                }.Transpose(),
                new ItemType[,]
                {
                    { ItemType.Orange, ItemType.Purple, ItemType.Green },
                    { ItemType.Purple, ItemType.Yellow, ItemType.None }
                }.Transpose()
            ).Returns(true);
        }
    }
}