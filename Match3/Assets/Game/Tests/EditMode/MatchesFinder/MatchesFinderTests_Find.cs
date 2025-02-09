using System.Collections.Generic;
using Game.Common;
using Game.Gameplay;
using NUnit.Framework;
using UnityEngine;

namespace Game.Tests
{
    public partial class MatchesFinderTests
    {
        [TestCaseSource(nameof(FindCases))]
        public void Find(ItemType[,] boardMatrix, List<MatchesFinder.Match> expectedMatches)
        {
            //Arrange:
            var board = new GameBoard(boardMatrix);
            var matchesFinder = new MatchesFinder(board);

            //Act:
            List<MatchesFinder.Match> result = matchesFinder.Find();

            //Assert:
            Assert.AreEqual(expectedMatches.Count, result.Count);
            for (var i = 0; i < result.Count; i++)
            {
                var expectedMatch = expectedMatches[i];
                var actualMatch = result[i];

                Assert.AreEqual(expectedMatch, actualMatch);
                /*Assert.AreEqual(expectedMatch.Item, actualMatch.Item);
                Assert.AreEqual(expectedMatch.Positions.Count, actualMatch.Positions.Count);
                for (var y = 0; y < expectedMatch.Positions.Count; y++)
                {
                    Assert.AreEqual(expectedMatch.Positions[y], actualMatch.Positions[y]);
                }*/
            }
        }

        private static IEnumerable<TestCaseData> FindCases()
        {
            yield return new TestCaseData(
                new ItemType[,]
                {
                    { ItemType.Red, ItemType.Orange },
                    { ItemType.Red, ItemType.Green },
                    { ItemType.Red, ItemType.Blue }
                }.Transpose(),
                new List<MatchesFinder.Match>
                {
                    new MatchesFinder.Match(
                        ItemType.Red,
                        new List<Vector2Int>
                        {
                            new Vector2Int(0, 0),
                            new Vector2Int(1, 0),
                            new Vector2Int(2, 0)
                        }
                    )
                }
            );

            yield return new TestCaseData(
                new ItemType[,]
                {
                    { ItemType.Red, ItemType.Orange },
                    { ItemType.Blue, ItemType.Green },
                    { ItemType.Red, ItemType.Blue }
                }.Transpose(),
                new List<MatchesFinder.Match>()
            );

            yield return new TestCaseData(
                new ItemType[,]
                {
                    { ItemType.Yellow, ItemType.Orange, ItemType.Red, },
                    { ItemType.Red, ItemType.Red, ItemType.Red, },
                    { ItemType.Green, ItemType.Blue, ItemType.Red },
                }.Transpose(),
                new List<MatchesFinder.Match>
                {
                    new MatchesFinder.Match(
                        ItemType.Red,
                        new List<Vector2Int>
                        {
                            new Vector2Int(0, 2),
                            new Vector2Int(1, 2),
                            new Vector2Int(1, 1),
                            new Vector2Int(1, 0),
                            new Vector2Int(2, 2)
                        }
                    )
                }
            );

            yield return new TestCaseData(
                new ItemType[,]
                {
                    { ItemType.Yellow, ItemType.Red, ItemType.Green, },
                    { ItemType.Red, ItemType.Red, ItemType.Red, },
                    { ItemType.Green, ItemType.Red, ItemType.Yellow },
                }.Transpose(),
                new List<MatchesFinder.Match>
                {
                    new MatchesFinder.Match(
                        ItemType.Red,
                        new List<Vector2Int>
                        {
                            new Vector2Int(0, 1),
                            new Vector2Int(1, 1),
                            new Vector2Int(1, 0),
                            new Vector2Int(1, 2),
                            new Vector2Int(2, 1)
                        }
                    )
                }
            );

            yield return new TestCaseData(
                new ItemType[,]
                {
                    { ItemType.Green, ItemType.Red, ItemType.Yellow, },
                    { ItemType.Green, ItemType.Red, ItemType.Yellow, },
                    { ItemType.Green, ItemType.Red, ItemType.Yellow },
                }.Transpose(),
                new List<MatchesFinder.Match>
                {
                    new MatchesFinder.Match(
                        ItemType.Green,
                        new List<Vector2Int>
                        {
                            new Vector2Int(0, 0),
                            new Vector2Int(1, 0),
                            new Vector2Int(2, 0)
                        }
                    ),
                    new MatchesFinder.Match(
                        ItemType.Red,
                        new List<Vector2Int>
                        {
                            new Vector2Int(0, 1),
                            new Vector2Int(1, 1),
                            new Vector2Int(2, 1)
                        }
                    ),
                    new MatchesFinder.Match(
                        ItemType.Yellow,
                        new List<Vector2Int>
                        {
                            new Vector2Int(0, 2),
                            new Vector2Int(1, 2),
                            new Vector2Int(2, 2)
                        }
                    )
                }
            );
        }
    }
}