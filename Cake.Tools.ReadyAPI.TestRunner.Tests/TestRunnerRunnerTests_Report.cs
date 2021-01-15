using System.Linq;
using Xunit;

namespace Cake.Tools.ReadyAPI.TestRunner.Tests
{
    public partial class TestRunnerRunnerTests
    {
        [Fact]
        public void GetArguments_TestCaseReportProvidedHasArgument()
        {
            var settings = new TestRunnerSettings
            {
                Report = ReportType.TestCase
            };

            var args = TestRunnerRunner.GetArguments(string.Empty, settings);

            Assert.Equal(1, args.Count(argument => argument.Render() == "\"-RTestCase Report\""));
        }

        [Fact]
        public void GetArguments_TestSuiteReportProvidedHasArgument()
        {
            var settings = new TestRunnerSettings
            {
                Report = ReportType.TestSuite
            };

            var args = TestRunnerRunner.GetArguments(string.Empty, settings);

            Assert.Equal(1, args.Count(argument => argument.Render() == "\"-RTestSuite Report\""));
        }

        [Fact]
        public void GetArguments_AllureReportProvidedHasArgument()
        {
            var settings = new TestRunnerSettings
            {
                Report = ReportType.Allure
            };

            var args = TestRunnerRunner.GetArguments(string.Empty, settings);

            Assert.Equal(1, args.Count(argument => argument.Render() == "\"-RAllure Report\""));
        }

        [Fact]
        public void GetArguments_DataExportReportProvidedHasArgument()
        {
            var settings = new TestRunnerSettings
            {
                Report = ReportType.DataExport
            };

            var args = TestRunnerRunner.GetArguments(string.Empty, settings);

            Assert.Equal(1, args.Count(argument => argument.Render() == "\"-RData Export\""));
        }

        [Fact]
        public void GetArguments_JUnitStyleHtmlReportProvidedHasArgument()
        {
            var settings = new TestRunnerSettings
            {
                Report = ReportType.JUnitStyleHtml
            };

            var args = TestRunnerRunner.GetArguments(string.Empty, settings);

            Assert.Equal(1, args.Count(argument => argument.Render() == "\"-RJUnit-Style HTML Report\""));
        }

        [Fact]
        public void GetArguments_ProjectReportProvidedHasArgument()
        {
            var settings = new TestRunnerSettings
            {
                Report = ReportType.Project
            };

            var args = TestRunnerRunner.GetArguments(string.Empty, settings);

            Assert.Equal(1, args.Count(argument => argument.Render() == "\"-RProject Report\""));
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
