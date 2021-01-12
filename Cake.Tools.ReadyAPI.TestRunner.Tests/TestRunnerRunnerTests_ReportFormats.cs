using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Cake.Tools.ReadyAPI.TestRunner.Tests
{
    public partial class TestRunnerRunnerTests
    {
        [Fact]
        public void GetArguments_ReportFormatsProvidedHasArgument()
        {
            var settings = new TestRunnerSettings
            {
                ReportFormats = new []{"PDF","XLS"}
            };

            var args = TestRunnerRunner.GetArguments(string.Empty, settings);

            Assert.Equal(1, args.Count(argument => argument.Render() == "-FPDF,XLS"));
        }

        [Fact]
        public void GetArguments_EmptyReportFormatsNoArgument()
        {
            var settings = new TestRunnerSettings
            {
                ReportFormats = new List<string>()
            };

            var args = TestRunnerRunner.GetArguments(string.Empty, settings);

            Assert.Equal(0, args.Count(argument => argument.Render().StartsWith("-F")));
        }

        [Fact]
        public void GetArguments_NullReportFormatsNoArgument()
        {
            var settings = new TestRunnerSettings
            {
                ReportFormats = null
            };

            var args = TestRunnerRunner.GetArguments(string.Empty, settings);

            Assert.Equal(0, args.Count(argument => argument.Render().StartsWith("-F")));
        }
    }
}
