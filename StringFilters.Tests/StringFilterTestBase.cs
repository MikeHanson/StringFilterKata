using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace StringFilters.Tests
{
    [TestFixture]
    public abstract class StringFilterTestBase<TFilter>
        where TFilter: IStringFilter, new()
    {
        [SetUp]
        public void SetUp()
        {
            this.filter = new TFilter();
        }

        [Test]
        public void ImplementStringFilterInterface()
        {
            this.filter.Should()
                .BeAssignableTo<IStringFilter>();
        }

        [Test]
        public void NotIncludeCandidatesThatCannotBeFormedWithNonCandidates()
        {
            var extraCandidates = new[] {"aaaaaa", "bbbbbb"};
            var newSource = this.source.Concat(extraCandidates);
            this.filter.Filter(newSource)
                .Should()
                .NotContain(extraCandidates);
        }

        [Test]
        public void ReturnCorrectResults()
        {
            this.filter.Filter(this.source)
                .ShouldBeEquivalentTo(this.expected);
        }

        private readonly IEnumerable<string> source = new[]
                                                      {
                                                          "al", "albums", "aver", "bar", "barely", "be", "befoul", "bums",
                                                          "by", "cat", "con", "convex", "ely", "foul", "here", "hereby",
                                                          "jig", "jigsaw", "or", "saw", "tail", "tailor", "vex", "we",
                                                          "weaver"
                                                      };

        private readonly IEnumerable<string> expected = new[]
                                                        {
                                                            "albums", "barely", "befoul", "convex", "hereby", "jigsaw",
                                                            "tailor", "weaver"
                                                        };

        private IStringFilter filter;
    }
}