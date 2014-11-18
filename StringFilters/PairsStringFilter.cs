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
             * Have to confess this one is based on this http://stackoverflow.com/questions/7662589/filter-a-list-of-strings-in-c-sharp stack flow answer I found when searching for a better solution than the two I had come up with, elegant but still four loops
             * and iterating source list three times.
             * 
             * Turns out to be the consistently faster than any of the other approaches, although only
             * marginally better than the potentials approach, however I am not sure I like the use
             * of KeyValuePair, if I picked this up in six months I would be wondering why, but can't argue
             * with the performance
             */
        }
    }
}