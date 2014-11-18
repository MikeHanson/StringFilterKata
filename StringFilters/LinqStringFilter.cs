using System;
using System.Collections.Generic;
using System.Linq;

namespace StringFilters
{
    public class LinqStringFilter : IStringFilter
    {
        public IEnumerable<string> Filter(IEnumerable<string> source)
        {
            var sourceArray = source.ToArray();
            var query = from outer in sourceArray
                        from inner in sourceArray
                        where outer.Length < 6 && inner.Length < 6
                        select new {outer = outer, inner = inner};

            return from pair in query
                   let paired = pair.outer + pair.inner
                   from candidate in sourceArray
                   where candidate.Length == 6 && candidate == paired
                   select candidate;

            /*
             *  My preferred approach, but LINQ isn't always the most performant
             *  Could probably be optimised some more or converted to method syntax
             *  if this is preferred
             */
        }
    }
}