using System.Linq;
using Xunit;

namespace Cake.Tools.ReadyAPI.TestRunner.Tests
{
    public partial class TestRunnerRunnerTests
    {
        [Fact]
        public void GetArguments_TestCaseProvidedHasArgument()
        {
            var settings = new TestRunnerSettings
            {
                TestCase = "HelloWorld"
            };

            var args = TestRunnerRunner.GetArguments(string.Empty, settings);

            Assert.Equal(1, args.Count(argument => argument.Render() == "-cHelloWorld"));
        }

        [Fact]
        public void GetArguments_EmptyTestCaseNoArgument()
        {
            var settings = new TestRunnerSettings
            {
                TestCase = string.Empty
            };

            var args = TestRunnerRunner.GetArguments(string.Empty, settings);

            Assert.Equal(0, args.Count(argument => argument.Render().StartsWith("-c")));
        }

        [Fact]
        public void GetArguments_NullTestCaseNoArgument()
        {
            var settings = new TestRunnerSettings
            {
                TestCase = null
            };

            var args = TestRunnerRunner.GetArguments(string.Empty, settings);

            Assert.Equal(0, args.Count(argument => argument.Render().StartsWith("-c")));
        }
    }
}
