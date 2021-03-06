﻿namespace CSharpDiscovery
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using NFluent;
    using NUnit.Framework;

    [TestFixture]
    public class LinqTests
    {
        [Test]
        public void UseAForeachLoopToSelectItemsStartingWithPlCaseSentitive()
        {
            var items = new[] { "plip", "foo", "bar", "plop", "plup", "Plap" };
            var filteredItems = new List<string>();
            // foreach loop to add
            foreach (string item in items)
            {
                if (item.Substring(0, 2) == "pl")
                    filteredItems.Add(item);
            }
            Check.That(filteredItems).ContainsExactly("plip", "plop", "plup");
        }

        [Test]
        public void TransformPreviousForeachLoopInALinqExpression()
        {
            var items = new[] { "plip", "foo", "bar", "plop", "plup", "Plap" };
            // use from in/where/select LINQ syntax to the same filter as with the foreach loop
            // var filteredItems = from ...
            var filteredItems = items.Where(item => item.Substring(0, 2) == "pl").ToList();
            Check.That(filteredItems).ContainsExactly("plip", "plop", "plup");
        }
        

        [Test]
        public void ReplacePreviousLinqExpressionWithLinqExtensionMethodsOfIEnumerable()
        {
            var items = new[] { "plip", "foo", "bar", "plop", "plup", "Plap" };
            // use System.Linq.Enumerable extension methods
            IEnumerable filteredItems = items.Where(item => item.Substring(0, 2) == "pl").ToList();
            Check.That(filteredItems).ContainsExactly("plip", "plop", "plup");
        }

        [Test]
        public void UseSelectExtensionMethodToTransformFilteredItemsToUpperCase()
        {
            var items = new[] { "plip", "foo", "bar", "plop", "plup", "Plap" };
            // use System.Linq.Enumerable extension methods
            List<string> filteredItems = (from item in items where item.Substring(0, 2) == "pl" select item.ToUpper()).ToList();
            Check.That(filteredItems).ContainsExactly("PLIP", "PLOP", "PLUP");
        }

        [Test]
        public void UseSkipAndTakeToKeepElementsAtAGivenRange()
        {
            var items = new[] { "plip", "foo", "bar", "plop", "plup", "Plap" };
            // use System.Linq.Enumerable extension methods
            var twoElementsStartingAtFourth = items.Skip(3).Take(2);
            Check.That(twoElementsStartingAtFourth).ContainsExactly("plop", "plup");
        }

        [Test]
        public void UseFirstToSelectFirstElementMatchingACondition()
        {
            var items = new[] { "plip", "foo", "bar", "plop", "plup", "Plap" };
            // use First to retrieve the first item having an 'o' at third position
            var firstItemHavingAnOAtThirdPosition = items.First(x => x.Substring(2, 1) == "o");
            Check.That(firstItemHavingAnOAtThirdPosition).Equals("foo");
        }

        [Test]
        public void FirstThrowsAnExceptionWhenConditionMatchesNoElement()
        {
            var items = new[] { "plip", "foo", "bar", "plop", "plup", "Plap" };
            // Action firstWithAConditionMatchingNoElements = lambda using First filtering item == "plep"
            Action firstWithAConditionMatchingNoElements = () => items.First(x => x == "plep");
            Check.That(firstWithAConditionMatchingNoElements).Throws<InvalidOperationException>();
        }

        [Test]
        public void FirstOrDefaultReturnsNullWhenConditionMatchesNoElement()
        {
            var items = new[] { "plip", "foo", "bar", "plop", "plup", "Plap" };
            // use FirstOrDefault filtering item == "plep"
            var firstItemEqualsToPlep = items.FirstOrDefault(x => x == "plep");
            Check.That(firstItemEqualsToPlep).IsNull();
        }

        [Test]
        public void SingleThrowsAnExceptionIfSeveralItemMatches()
        {
            var items = new[] { "plip", "foo", "bar", "plop", "plup", "Plap" };
            // Action singleItemHavingAnOAtThirdPosition = use Single with condition on third character being an 'o'
            Action singleItemHavingAnOAtThirdPosition = () => items.Single(x => x.Substring(2, 1) == "o");
            Check.ThatCode(singleItemHavingAnOAtThirdPosition).Throws<InvalidOperationException>();
        }

        [Test]
        public void UseAggregateToComputeASum()
        {
            var valuesToSum = new[] { 1.2, 1.5, 5.3 };
            // use Aggregate giving a lambda expression that make the sum of two values => 
            //iteration is done by the Aggregate method, using this lambda expression at each iteration
            var sum = valuesToSum.Aggregate((sumAggregate, element) => (sumAggregate + element));
            Check.That(sum).Equals(1.2 + 1.5 + 5.3);
        }

        [Test]
        public void UseAggregateToConcatenateStringsFromArray()
        {
            var strings = new[] { "plip", "plop", "plup" };
            // use Aggregate with a seed value t
            var concatenatedString = strings.Aggregate((sumAggregate, element) => ();
            Check.That(concatenatedString).Equals("Values of array are : , plip, plop, plup");
        }
    }
}
