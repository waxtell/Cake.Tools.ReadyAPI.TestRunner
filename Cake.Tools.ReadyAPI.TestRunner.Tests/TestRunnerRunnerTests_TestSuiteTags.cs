using System.Linq;
using Xunit;

namespace Cake.Tools.ReadyAPI.TestRunner.Tests
{
    public partial class TestRunnerRunnerTests
    {
        [Fact]
        public void GetArguments_TestSuiteTagsProvidedHasArgument()
        {
            var settings = new TestRunnerSettings
            {
                TestSuiteTags = "1"
            };

            var args = TestRunnerRunner.GetArguments(string.Empty, settings);

            Assert.Equal(1, args.Count(argument => argument.Render() == "\"-TTestSuite 1\""));
        }

        [Fact]
        public void GetArguments_EmptyTestSuiteTagsNoArgument()
        {
            var settings = new TestRunnerSettings
            {
                TestSuiteTags = string.Empty
            };

            var args = TestRunnerRunner.GetArguments(string.Empty, settings);

            Assert.Equal(0, args.Count(argument => argument.Render().StartsWith("-TTestSuite")));
        }

        [Fact]
        public void GetArguments_NullTestSuiteTagsNoArgument()
        {
            var settings = new TestRunnerSettings
            {
                TestSuiteTags = null
            };

            var args = TestRunnerRunner.GetArguments(string.Empty, settings);

            Assert.Equal(0, args.Count(argument => argument.Render().StartsWith("-TTestSuite")));
        }
    }
}
