using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShiftwiseTestCsharp
{
    public static class ListExtension
    {
        public static List<T> Shuffle<T>(this List<T> list)
        {
            var r = new Random();
            return Shuffle<T>(list, r);
        }

        public static List<T> Shuffle<T>(this List<T> list, int seed)
        {
            var r = new Random(seed);
            return Shuffle<T>(list, r);
        }

        public static List<T> Shuffle<T>(this List<T> list, Random rand)
        {
            List<Tuple<T, int>> reindexedList = new List<Tuple<T, int>>();

            foreach (var item in list)
                reindexedList.Add(Tuple.Create(item, rand.Next()));

            // LINQ would also work here
            reindexedList.Sort(delegate(Tuple<T, int> first, Tuple<T, int> second)
            {
                return first.Item2.CompareTo(second.Item2);
            });

            List<T> shuffledList = new List<T>();

            foreach (var item in reindexedList)
                shuffledList.Add(item.Item1);

            return shuffledList;
        }
    }
}
