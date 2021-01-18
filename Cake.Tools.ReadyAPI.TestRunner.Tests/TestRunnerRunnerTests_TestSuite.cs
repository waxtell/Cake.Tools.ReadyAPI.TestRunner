using System.Linq;
using Xunit;

namespace Cake.Tools.ReadyAPI.TestRunner.Tests
{
    public partial class TestRunnerRunnerTests
    {
        [Fact]
        public void GetArguments_TestSuiteProvidedHasArgument()
        {
            var settings = new TestRunnerSettings
            {
                TestSuite = "Test Suite 1"
            };

            var args = TestRunnerRunner.GetArguments(string.Empty, settings);

            Assert.Equal(1, args.Count(argument => argument.Render() == "\"-sTest Suite 1\""));
        }

        [Fact]
        public void GetArguments_EmptyTestSuiteNoArgument()
        {
            var settings = new TestRunnerSettings
            {
                TestSuite = string.Empty
            };

            var args = TestRunnerRunner.GetArguments(string.Empty, settings);

            Assert.Equal(0, args.Count(argument => argument.Render().StartsWith("-s")));
        }

        [Fact]
        public void GetArguments_NullTestSuiteNoArgument()
        {
            var settings = new TestRunnerSettings
            {
                TestSuite = null
            };

            var args = TestRunnerRunner.GetArguments(string.Empty, settings);

            Assert.Equal(0, args.Count(argument => argument.Render().StartsWith("-s")));
        }
    }
}
