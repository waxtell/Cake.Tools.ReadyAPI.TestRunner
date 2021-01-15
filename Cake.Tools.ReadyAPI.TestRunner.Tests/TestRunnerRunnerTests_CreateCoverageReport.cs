using System.Linq;
using Xunit;

namespace Cake.Tools.ReadyAPI.TestRunner.Tests
{
    public partial class TestRunnerRunnerTests
    {
        [Fact]
        public void GetArguments_CreateCoverageReportTrueHasArgument()
        {
            var settings = new TestRunnerSettings
            {
                CreateCoverageReport = true
            };

            var args = TestRunnerRunner.GetArguments(string.Empty, settings);

            Assert.Equal(1, args.Count(argument => argument.Render() == "-g" ));
        }

        [Fact]
        public void GetArguments_CreateCoverageReportFalseNoArgument()
        {
            var settings = new TestRunnerSettings
            {
                CreateCoverageReport = false
            };

            var args = TestRunnerRunner.GetArguments(string.Empty, settings);

            Assert.Equal(0, args.Count(argument => argument.Render() == "-g"));
        }
    }
}
