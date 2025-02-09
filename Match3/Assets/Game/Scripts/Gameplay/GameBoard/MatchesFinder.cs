using System.Collections.Generic;
using Game.Common;
using UnityEngine;

namespace Game.Gameplay
{
    public sealed class MatchesFinder
    {
        private readonly GameBoard _board;

        public MatchesFinder(GameBoard board)
        {
            _board = board;
        }

        public List<Match> Find()
        {
            var result = new List<Match>();

            for (var col = 0; col < _board.Width; col++)
            {
                for (var row = 0; row < _board.Height; row++)
                {
                    var checkPosition = new Vector2Int(row, col);
                    var item = _board[row, col];
                    if (TryGetMatch(checkPosition, item, out var match))
                    {
                        if (IsUnique(match, result))
                        {
                            result.Add(match);
                        }
                    }
                }
            }

            return result;
        }

        private bool IsUnique(Match match, List<Match> matches)
        {
            foreach (var compareMatch in matches)
            {
                if (compareMatch.Equals(match))
                {
                    return false;
                }
            }

            return true;
        }

        private bool TryGetMatch(Vector2Int checkPosition, ItemType item, out Match match)
        {
            match = null;
            List<Vector2Int> horizontal = GetHorizontalPositions(checkPosition, item);
            List<Vector2Int> vertical = GetVerticalPositions(checkPosition, item);

            if (horizontal.Count >= 2 || vertical.Count >= 2)
            {
                horizontal.AddRange(vertical);
                horizontal.Add(checkPosition);
                match = new Match(item, horizontal);
                return true;
            }

            return false;
        }

        private List<Vector2Int> GetHorizontalPositions(Vector2Int checkPosition, ItemType item)
        {
            var result = new List<Vector2Int>();

            for (int i = checkPosition.y - 1; i >= 0; i--)
            {
                var checkItem = _board[checkPosition.x, i];

                if (checkItem != item)
                {
                    break;
                }

                result.Add(new(checkPosition.x, i));
            }

            for (int i = checkPosition.y + 1; i < _board.Width; i++)
            {
                var checkItem = _board[checkPosition.x, i];

                if (checkItem != item)
                {
                    break;
                }

                result.Add(new(checkPosition.x, i));
            }

            return result;
        }

        private List<Vector2Int> GetVerticalPositions(Vector2Int checkPosition, ItemType item)
        {
            var result = new List<Vector2Int>();

            for (int i = checkPosition.x - 1; i >= 0; i--)
            {
                var checkItem = _board[i, checkPosition.y];

                if (checkItem != item)
                {
                    break;
                }

                result.Add(new(i, checkPosition.y));
            }

            for (int i = checkPosition.x + 1; i < _board.Height; i++)
            {
                var checkItem = _board[i, checkPosition.y];

                if (checkItem != item)
                {
                    break;
                }

                result.Add(new(i, checkPosition.y));
            }

            return result;
        }

        public class Match
        {
            public ItemType Item { get; }
            public List<Vector2Int> Positions { get; }

            public Match(ItemType item, List<Vector2Int> positions)
            {
                Item = item;
                Positions = positions;
            }

            public override bool Equals(object obj)
            {
                if (obj is Match match)
                {
                    if (match.Item != Item)
                    {
                        return false;
                    }

                    if (match.Positions.Count != Positions.Count)
                    {
                        return false;
                    }

                    foreach (var matchPosition in match.Positions)
                    {
                        bool hasPosition = false;

                        foreach (var selfPosition in Positions)
                        {
                            if (selfPosition == matchPosition)
                            {
                                hasPosition = true;
                                break;
                            }
                        }

                        if (hasPosition == false)
                        {
                            return false;
                        }
                    }

                    return true;
                }

                return false;
            }
        }
    }
}