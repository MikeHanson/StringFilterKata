using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace StringFilters.Tests
{
    [TestFixture]
    public class CandidatesFirstStringFilterShould
    {
        [SetUp]
        public void SetUp()
        {
            this.filter = new CandidatesFirstStringFilter();
        }

        [Test]
        public void ImplementStringFilterInterface()
        {
            this.filter.Should()
                .BeAssignableTo<IStringFilter>();
        }

        [Test]
        public void ReturnCorrectResults()
        {
            this.filter.Filter(this.source).ShouldBeEquivalentTo(this.expected);
        }

        [Test]
        public void NotIncludeCandidatesThatCannotBeFormedWithNonCandidates()
        {
            var extraCandidates = new []
                          {
                              "aaaaaa",
                              "bbbbbb"
                          };
            var newSource = this.source.Concat(extraCandidates);
            this.filter.Filter(newSource)
                .Should()
                .NotContain(extraCandidates);
        }

        private IEnumerable<string> source = new[]
                                             {
                                                 "al", "albums", "aver", "bar", "barely", "be", "befoul", "bums", "by",
                                                 "cat", "con", "convex", "ely", "foul", "here", "hereby", "jig", "jigsaw",
                                                 "or", "saw", "tail", "tailor", "vex", "we", "weaver"
                                             };

        private IEnumerable<string> expected = new[]
                                               {
                                                   "albums", "barely", "befoul", "convex", "hereby", "jigsaw", "tailor",
                                                   "weaver"
                                               };

        private CandidatesFirstStringFilter filter;
    }
}