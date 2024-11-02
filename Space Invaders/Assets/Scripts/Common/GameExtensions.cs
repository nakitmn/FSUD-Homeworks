using System.Collections.Generic;
using System.Linq;

namespace Common
{
    public static class GameExtensions
    {
        public static T Random<T>(this IEnumerable<T> collection)
        {
            int index = UnityEngine.Random.Range(0, collection.Count());
            return collection.ElementAt(index);
        }
    }
}