using System.Collections.Generic;
using System.Linq;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace app.tests.integration.Middleware
{
    public class CustomOrderer : ITestCaseOrderer
    {
        public const string TypeName = "app.tests.integration.Middleware.CustomOrderer";

        public const string AssembyName = "app.tests.integration";

        public IEnumerable<TTestCase> OrderTestCases<TTestCase>(IEnumerable<TTestCase> testCases) where TTestCase : ITestCase
        {
            var sortedTestList = new SortedDictionary<int, TTestCase>();
            foreach (var item in testCases)
            {
                var testOrderAttributes = item.TestMethod.Method.GetCustomAttributes(typeof(TestOrderAttribute)).ToList();
                if (testOrderAttributes?.FirstOrDefault() != null)
                {
                    var order = testOrderAttributes.First().GetNamedArgument<int>("Order");
                    sortedTestList.Add(order, item);
                }
            }
            return sortedTestList.Values;
        }
    }
}