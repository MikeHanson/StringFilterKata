using System;
using System.Collections.Generic;

namespace StringFilters
{
    public class CandidatesFirstStringFilter : IStringFilter
    {
        public IEnumerable<string> Filter(IEnumerable<string> source)
        {
            var candidates = new List<string>();
            var nonCandidates = new List<string>();
            var results = new List<string>();

            foreach(var item in source)
            {
                if(item.Length == 6)
                {
                    candidates.Add(item);
                }
                else
                {
                    nonCandidates.Add(item);
                }
            }

            foreach(var candidate in candidates)
            {
                var added = false;
                foreach(var outer in nonCandidates)
                {
                    foreach(var inner in nonCandidates)
                    {
                        if(added)
                        {
                            continue;
                        }

                        if((!candidate.StartsWith(outer) || !candidate.EndsWith(inner))
                           && (!candidate.StartsWith(inner) || !candidate.EndsWith(outer)))
                        {
                            continue;
                        }
                        results.Add(candidate);
                        added = true;
                    }
                }
            }

            return results;

            /*
             *  Although this solution reduces the number of items in each loop to a minimum first
             *  can't help thinking there are too many loops.
             *  
             *  Don't like that I have to protect against duplicates
             *  
             *  It's readable though
             * */
        }
    }
}