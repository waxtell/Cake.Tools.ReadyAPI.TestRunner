using System.Linq;
using Xunit;

namespace Cake.Tools.ReadyAPI.TestRunner.Tests
{
    public partial class TestRunnerRunnerTests
    {
        [Fact]
        public void GetArguments_CreateJUnitCompatibleReportsTrueHasArgument()
        {
            var settings = new TestRunnerSettings
            {
                CreateJUnitCompatibleReports = true
            };

            var args = TestRunnerRunner.GetArguments(string.Empty, settings);

            Assert.Equal(1, args.Count(argument => argument.Render() == "-j" ));
        }

        [Fact]
        public void GetArguments_CreateJUnitCompatibleReportsFalseNoArgument()
        {
            var settings = new TestRunnerSettings
            {
                CreateJUnitCompatibleReports = false
            };

            var args = TestRunnerRunner.GetArguments(string.Empty, settings);

            Assert.Equal(0, args.Count(argument => argument.Render() == "-j"));
        }
    }
}
