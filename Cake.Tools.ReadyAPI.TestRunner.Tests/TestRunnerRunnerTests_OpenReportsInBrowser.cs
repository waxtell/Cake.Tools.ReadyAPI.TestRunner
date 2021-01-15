using System.Linq;
using Xunit;

namespace Cake.Tools.ReadyAPI.TestRunner.Tests
{
    public partial class TestRunnerRunnerTests
    {
        [Fact]
        public void GetArguments_OpenReportsInBrowserTrueHasArgument()
        {
            var settings = new TestRunnerSettings
            {
                OpenReportsInBrowser = true
            };

            var args = TestRunnerRunner.GetArguments(string.Empty, settings);

            Assert.Equal(1, args.Count(argument => argument.Render() == "-o" ));
        }

        [Fact]
        public void GetArguments_OpenReportsInBrowserFalseNoArgument()
        {
            var settings = new TestRunnerSettings
            {
                OpenReportsInBrowser = false
            };

            var args = TestRunnerRunner.GetArguments(string.Empty, settings);

            Assert.Equal(0, args.Count(argument => argument.Render() == "-o"));
        }
    }
}
