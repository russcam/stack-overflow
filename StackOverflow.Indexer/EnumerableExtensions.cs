using System.Collections.Generic;
using System.Linq;

namespace StackOverflow.Indexer
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<IEnumerable<T>> Batch<T>(
            this IEnumerable<T> source, int size)
        {
            T[] bucket = null;
            var count = 0;

            foreach (var item in source)
            {
                if (bucket == null)
                    bucket = new T[size];

                bucket[count++] = item;

                if (count != size)                
                    continue;

                yield return bucket.Select(x => x);

                bucket = null;
                count = 0;
            }
            
            if (bucket != null && count > 0)            
                yield return bucket.Take(count);            
        }
    }
}