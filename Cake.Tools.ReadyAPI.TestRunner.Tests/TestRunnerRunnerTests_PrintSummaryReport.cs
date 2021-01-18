using System.Linq;
using Xunit;

namespace Cake.Tools.ReadyAPI.TestRunner.Tests
{
    public partial class TestRunnerRunnerTests
    {
        [Fact]
        public void GetArguments_PrintSummaryReportTrueHasArgument()
        {
            var settings = new TestRunnerSettings
            {
                PrintSummaryReport = true
            };

            var args = TestRunnerRunner.GetArguments(string.Empty, settings);

            Assert.Equal(1, args.Count(argument => argument.Render() == "-r" ));
        }

        [Fact]
        public void GetArguments_PrintSummaryReportFalseNoArgument()
        {
            var settings = new TestRunnerSettings
            {
                PrintSummaryReport = false
            };

            var args = TestRunnerRunner.GetArguments(string.Empty, settings);

            Assert.Equal(0, args.Count(argument => argument.Render() == "-r"));
        }
    }
}
