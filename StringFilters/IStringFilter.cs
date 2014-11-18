using System;
using System.Collections.Generic;

namespace StringFilters
{
    public interface IStringFilter
    {
        IEnumerable<string> Filter(IEnumerable<string> source);
    }
}