using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using StringFilters;

namespace StringFilter.Perf
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var source = new[]
                         {
                             "al", "albums", "aver", "bar", "barely", "be", "befoul", "bums", "by", "cat", "con", "convex",
                             "ely", "foul", "here", "hereby", "jig", "jigsaw", "or", "saw", "tail", "tailor", "vex", "we",
                             "weaver"
                         };
            var filters = new IStringFilter[]
                          {
                              new CandidatesFirstStringFilter(), new PotentialsFirstStringFilter(), new PairsStringFilter(),
                              new LinqStringFilter()
                          };

            foreach(var filter in filters)
            {
                var stopwatch = new Stopwatch();
                stopwatch.Start();
                filter.Filter(source);
                stopwatch.Stop();
                Console.WriteLine("{0}: {1}", filter.GetType().Name, stopwatch.Elapsed);
            }
            Console.ReadLine();
        }
    }
}