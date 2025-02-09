using System.Collections.Generic;

namespace Game.Common
{
    public static class Extensions
    {
        public static T[,] Transpose<T>(this T[,] matrix)
        {
            var rows    = matrix.GetLength(0);
            var columns = matrix.GetLength(1);

            var result = new T[columns, rows];

            for (var c = 0; c < columns; c++)
            {
                for (var r = 0; r < rows; r++)
                {
                    result[c, r] = matrix[r, c];
                }
            }

            return result;
        }

        public static bool AreSame<T, M>(this Dictionary<T, M> dictionary, Dictionary<T, M> compareDictionary)
        {
            if (dictionary.Count != compareDictionary.Count)
            {
                return false;
            }
            
            foreach (var (origin, target) in compareDictionary)
            {
                if (target.Equals(dictionary[origin]) == false)
                {
                    return false;
                }
            }

            return true;
        }
    }
}