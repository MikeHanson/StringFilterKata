using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace StringFilters
{
    public class PotentialsFirstStringFilter : IStringFilter
    {
        public IEnumerable<string> Filter(IEnumerable<string> source)
        {
            var potentials = new List<string>();
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

                    potentials.Add(outer + inner);
                }
            }

            foreach(var item in sourceArray)
            {
                if(item.Length != 6)
                {
                    continue;
                }

                foreach(var potential in potentials)
                {
                    if(item.Equals(potential))
                    {
                        Debug.Print(item + ":" + potential);
                        results.Add(item);  
                    }
                }
            }

            return results;

            /*
             *  Again not sure I like four loops, especially since this solution iterates the entire
             *  list twice
             *  
             *  Better tha I don't have to uglify code to protect against duplicates
             *  
             *  It's readable though
             * */
        }
    }
}