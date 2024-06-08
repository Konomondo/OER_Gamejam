using System;
using System.Collections.Generic;

namespace CCC.Utility
{
    public static class Utility
    {
        private static readonly Random _rng = new Random();

        /// <summary>
        /// Extends lists so that they can be shuffled.
        /// Code from <see href="https://stackoverflow.com/a/1262619">stackoverflow</see>.
        /// Implements <see href="https://en.wikipedia.org/wiki/Fisher%E2%80%93Yates_shuffle">Fisher-Yates shuffle (wikipedia)</see>.
        /// </summary>
        /// <typeparam name="T">Type parameter of the list.</typeparam>
        /// <param name="list">The shuffled list.</param>
        public static void Shuffle<T>(this IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = _rng.Next(n + 1);
                (list[n], list[k]) = (list[k], list[n]);
            }
        }
    }
}