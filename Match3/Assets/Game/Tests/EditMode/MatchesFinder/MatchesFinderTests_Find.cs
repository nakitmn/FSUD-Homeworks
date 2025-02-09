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
            Assert.IsTrue(
                result.TrueForAll(
                    match => expectedMatches.Exists(it => it.Equals(match))
                )
            );
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

            yield return new TestCaseData(
                new ItemType[,]
                {
                    { ItemType.Red, ItemType.Red, ItemType.Red, ItemType.Red, ItemType.Red },
                    { ItemType.Blue, ItemType.Blue, ItemType.Red, ItemType.Green, ItemType.Red },
                    { ItemType.Red, ItemType.Red, ItemType.Red, ItemType.Red, ItemType.Red },
                }.Transpose(),
                new List<MatchesFinder.Match>
                {
                    new MatchesFinder.Match(
                        ItemType.Red,
                        new List<Vector2Int>
                        {
                            new Vector2Int(0, 0),
                            new Vector2Int(0, 1),
                            new Vector2Int(0, 2),
                            new Vector2Int(0, 3),
                            new Vector2Int(0, 4),

                            new Vector2Int(1, 2),
                            new Vector2Int(1, 4),

                            new Vector2Int(2, 0),
                            new Vector2Int(2, 1),
                            new Vector2Int(2, 2),
                            new Vector2Int(2, 3),
                            new Vector2Int(2, 4),
                        }
                    )
                }
            );

            yield return new TestCaseData(
                new ItemType[,]
                {
                    { ItemType.Yellow, ItemType.None, ItemType.None, },
                    { ItemType.None, ItemType.Yellow, ItemType.None, },
                    { ItemType.None, ItemType.None, ItemType.Yellow },
                }.Transpose(),
                new List<MatchesFinder.Match>()
            );

            yield return new TestCaseData(
                new ItemType[,]
                {
                    { ItemType.Yellow, ItemType.Yellow, ItemType.None, },
                    { ItemType.None, ItemType.Yellow, ItemType.None, },
                    { ItemType.None, ItemType.Yellow, ItemType.Yellow },
                }.Transpose(),
                new List<MatchesFinder.Match>
                {
                    new MatchesFinder.Match(
                        ItemType.Yellow,
                        new List<Vector2Int>
                        {
                            new Vector2Int(0, 0),
                            new Vector2Int(0, 1),

                            new Vector2Int(1, 1),

                            new Vector2Int(2, 1),
                            new Vector2Int(2, 2),
                        }
                    ),
                }
            );

            yield return new TestCaseData(
                new ItemType[,]
                {
                    { ItemType.None, ItemType.None, ItemType.None, },
                    { ItemType.None, ItemType.None, ItemType.None, },
                    { ItemType.None, ItemType.None, ItemType.None },
                }.Transpose(),
                new List<MatchesFinder.Match>()
            );

            yield return new TestCaseData(
                new ItemType[,]
                {
                    { ItemType.Red, ItemType.Red, ItemType.Red, ItemType.Red, ItemType.Red },
                    { ItemType.Blue, ItemType.Blue, ItemType.Green, ItemType.Green, ItemType.Green },
                    { ItemType.Blue, ItemType.Blue, ItemType.Blue, ItemType.Yellow, ItemType.Green },
                }.Transpose(),
                new List<MatchesFinder.Match>
                {
                    new MatchesFinder.Match(
                        ItemType.Red,
                        new List<Vector2Int>
                        {
                            new Vector2Int(0, 0),
                            new Vector2Int(0, 1),
                            new Vector2Int(0, 2),
                            new Vector2Int(0, 3),
                            new Vector2Int(0, 4),
                        }
                    ),
                    new MatchesFinder.Match(
                        ItemType.Blue,
                        new List<Vector2Int>
                        {
                            new Vector2Int(1, 0),
                            new Vector2Int(1, 1),

                            new Vector2Int(2, 0),
                            new Vector2Int(2, 1),
                            new Vector2Int(2, 2),
                        }
                    ),
                    new MatchesFinder.Match(
                        ItemType.Green,
                        new List<Vector2Int>
                        {
                            new Vector2Int(1, 2),
                            new Vector2Int(1, 3),
                            new Vector2Int(1, 4),

                            new Vector2Int(2, 4),
                        }
                    ),
                }
            );
        }
    }
}