using System;
using System.Collections.Generic;
using System.Linq;

namespace StringFilters
{
    public class PairsStringFilter : IStringFilter
    {
        public IEnumerable<string> Filter(IEnumerable<string> source)
        {
            var pairs = new List<KeyValuePair<string, string>>();
            var results = new List<string>();
            var sourceArray = source.ToArray();

            foreach(var outer in sourceArray)
            {
                if(outer.Length >= 6)
                {
                    continue;
                }

                foreach(var inner in sourceArray)
                {
                    if (inner.Length >= 6 || outer.Equals(inner) || (outer.Length + inner.Length) != 6)
                    {
                        continue;
                    }

                    pairs.Add(new KeyValuePair<string, string>(outer, inner));
                }
            }

            foreach(var pair in pairs)
            {
                foreach(var item in sourceArray)
                {
                    if(item.Length != 6)
                    {
                        continue;
                    }

                    if(item == pair.Key + pair.Value)
                    {
                        results.Add(item);
                    }
                }
            }

            return results;

            /*
             * Have to confess this one is based on a stack flow answer found when searching
             * for a better solution than any I had come up with, elegant but still four loops
             * and iterating source list three times
             */
        }
    }
}