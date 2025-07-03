using Xunit.Abstractions;
using Xunit.Sdk;

namespace Ambev.DeveloperEvaluation.Integration
{
    public class PriorityOrderer : ITestCaseOrderer
    {
        public IEnumerable<TTestCase> OrderTestCases<TTestCase>(IEnumerable<TTestCase> testCases) where TTestCase : ITestCase
        {
            var sortedMethods = testCases.OrderBy(tc =>
            {
                var attr = tc.TestMethod.Method
                    .GetCustomAttributes(typeof(TestPriorityAttribute).AssemblyQualifiedName)
                    .FirstOrDefault();

                return attr?.GetNamedArgument<int>("Priority") ?? 0;
            });

            return sortedMethods;
        }
    }
}
