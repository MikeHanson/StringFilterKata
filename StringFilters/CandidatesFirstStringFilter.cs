using System;
using System.Collections.Generic;

namespace StringFilters
{
    public class CandidatesFirstStringFilter : IStringFilter
    {
        public IEnumerable<string> Filter(IEnumerable<string> source)
        {
            yield break;
        }
    }
}