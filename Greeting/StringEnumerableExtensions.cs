using System.Collections.Generic;
using System.Linq;

namespace Greeting
{
    public static class StringEnumerableExtensions
    {
        public static string JoinWithDifferentLastSeparator(this IEnumerable<string> iter, string separator, string lastSeparator)
        {
            var allButLastItem = iter.Take(iter.Count() - 1);
            return $"{string.Join(separator, allButLastItem)}" +
                $"{ (iter.Count() > 1 ? lastSeparator : string.Empty) }" +
                $"{iter.Last()}";
        }
    }
}
