using System.Linq;
using Xunit;

namespace Cake.Tools.ReadyAPI.TestRunner.Tests
{
    public partial class TestRunnerRunnerTests
    {
        [Fact]
        public void GetArguments_ReportProvidedHasArgument()
        {
            var settings = new TestRunnerSettings
            {
                Report = "TestCase"
            };

            var args = TestRunnerRunner.GetArguments(string.Empty, settings);

            Assert.Equal(1, args.Count(argument => argument.Render() == "\"-RTestCase\""));
        }

        [Fact]
        public void GetArguments_EmptyReportNoArgument()
        {
            var settings = new TestRunnerSettings
            {
                Report = string.Empty
            };

            var args = TestRunnerRunner.GetArguments(string.Empty, settings);

            Assert.Equal(0, args.Count(argument => argument.Render().StartsWith("-R")));
        }

        [Fact]
        public void GetArguments_NullReportNoArgument()
        {
            var settings = new TestRunnerSettings
            {
                Report = null
            };

            var args = TestRunnerRunner.GetArguments(string.Empty, settings);

            Assert.Equal(0, args.Count(argument => argument.Render().StartsWith("-R")));
        }
    }
}
