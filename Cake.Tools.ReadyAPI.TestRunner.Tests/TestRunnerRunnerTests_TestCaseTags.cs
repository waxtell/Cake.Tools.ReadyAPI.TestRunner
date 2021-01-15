using System.Linq;
using Xunit;

namespace Cake.Tools.ReadyAPI.TestRunner.Tests
{
    public partial class TestRunnerRunnerTests
    {
        [Fact]
        public void GetArguments_TestCaseTagsProvidedHasArgument()
        {
            var settings = new TestRunnerSettings
            {
                TestCaseTags = "Tag3 || Tag4"
            };

            var args = TestRunnerRunner.GetArguments(string.Empty, settings);

            Assert.Equal(1, args.Count(argument => argument.Render() == "\"-TTestCase Tag3 || Tag4\""));
        }

        [Fact]
        public void GetArguments_EmptyTestCaseTagsNoArgument()
        {
            var settings = new TestRunnerSettings
            {
                TestCaseTags = string.Empty
            };

            var args = TestRunnerRunner.GetArguments(string.Empty, settings);

            Assert.Equal(0, args.Count(argument => argument.Render().StartsWith("-TTestCase")));
        }

        [Fact]
        public void GetArguments_NullTestCaseTagsNoArgument()
        {
            var settings = new TestRunnerSettings
            {
                TestCaseTags = null
            };

            var args = TestRunnerRunner.GetArguments(string.Empty, settings);

            Assert.Equal(0, args.Count(argument => argument.Render().StartsWith("-TTestCase")));
        }
    }
}
