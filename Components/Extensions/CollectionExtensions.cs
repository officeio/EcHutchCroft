using System.Collections.Generic;

namespace OfficeIO.EcHutchCroft.Website.Components.Extensions
{
    /// <summary>
    /// Extensions used in the project.
    /// </summary>
    public static class CollectionExtensions
    {
        /// <summary>
        /// Adds an enumerable of items to a list of the same element type.
        /// </summary>
        public static void AddRange<T>(this IList<T> target, IEnumerable<T> source)
        {
            foreach (var item in source)
                target.Add(item);
        }
    }
}
