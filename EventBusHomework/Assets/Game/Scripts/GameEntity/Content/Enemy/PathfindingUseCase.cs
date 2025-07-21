using System.Collections.Generic;
using UnityEngine;

namespace SampleGame
{
    public static class PathfindingUseCase
    {
        private static readonly Vector2Int[] Directions = new Vector2Int[]
        {
            new Vector2Int(0, 1), // Up
            new Vector2Int(1, 0), // Right
            new Vector2Int(0, -1), // Down
            new Vector2Int(-1, 0), // Left
            
            new Vector2Int(1, 1),
            new Vector2Int(-1, 1),
            new Vector2Int(-1, -1),
            new Vector2Int(1, -1),
        };

        public static List<Vector2Int> FindPath(in IGameContext gameContext, Vector2Int start, Vector2Int end)
        {
            var gameBoard = gameContext.GetGameBoard();

            int width = gameBoard.Width;
            int height = gameBoard.Height;

            var visited = new HashSet<Vector2Int>();
            var distance = new Dictionary<Vector2Int, int>();
            var previous = new Dictionary<Vector2Int, Vector2Int>();
            var priorityQueue = new PriorityQueue<Vector2Int>();

            // Инициализация
            for (int x = 0; x < width; x++)
            for (int y = 0; y < height; y++)
            {
                Vector2Int pos = new Vector2Int(x, y);
                distance[pos] = int.MaxValue;
            }

            distance[start] = 0;
            priorityQueue.Enqueue(start, 0);

            while (priorityQueue.Count > 0)
            {
                var current = priorityQueue.Dequeue();

                if (current == end)
                    break;

                if (visited.Contains(current))
                    continue;

                visited.Add(current);

                foreach (var dir in Directions)
                {
                    Vector2Int neighbor = current + dir;

                    if (neighbor.x < 0 || neighbor.x >= width || neighbor.y < 0 || neighbor.y >= height)
                        continue;

                    // Пропустить, если клетка занята, НО разрешить старт и финиш
                    if (gameBoard.IsFree(GameBoardPosition.FromVector2Int(neighbor)) == false && neighbor != end)
                        continue;

                    int newDist = distance[current] + 1;

                    if (newDist < distance[neighbor])
                    {
                        distance[neighbor] = newDist;
                        previous[neighbor] = current;
                        priorityQueue.Enqueue(neighbor, newDist);
                    }
                }
            }

            // Восстановление пути
            var path = new List<Vector2Int>();
            Vector2Int? step = end;

            while (step != null && previous.ContainsKey(step.Value))
            {
                path.Add(step.Value);
                step = previous[step.Value];
            }

            if (step != start)
                return null; // Путь не найден

            path.Add(start);
            path.Reverse();
            path.RemoveAt(0);
            return path;
        }

        // Простая очередь с приоритетом
        private class PriorityQueue<T>
        {
            private List<(T item, int priority)> elements = new();

            public int Count => elements.Count;

            public void Enqueue(T item, int priority)
            {
                elements.Add((item, priority));
            }

            public T Dequeue()
            {
                int bestIndex = 0;
                int bestPriority = elements[0].priority;

                for (int i = 1; i < elements.Count; i++)
                {
                    if (elements[i].priority < bestPriority)
                    {
                        bestPriority = elements[i].priority;
                        bestIndex = i;
                    }
                }

                T bestItem = elements[bestIndex].item;
                elements.RemoveAt(bestIndex);
                return bestItem;
            }
        }
    }
}