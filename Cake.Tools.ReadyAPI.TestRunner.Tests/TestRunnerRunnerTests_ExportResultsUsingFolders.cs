using System.Linq;
using Xunit;

namespace Cake.Tools.ReadyAPI.TestRunner.Tests
{
    public partial class TestRunnerRunnerTests
    {
        [Fact]
        public void GetArguments_ExportResultsUsingFoldersTrueHasArgument()
        {
            var settings = new TestRunnerSettings
            {
                ExportResultsUsingFolders = true
            };

            var args = TestRunnerRunner.GetArguments(string.Empty, settings);

            Assert.Equal(1, args.Count(argument => argument.Render() == "-A"));
        }

        [Fact]
        public void GetArguments_ExportResultsUsingFoldersFalseNoArgument()
        {
            var settings = new TestRunnerSettings
            {
                ExportResultsUsingFolders = false
            };

            var args = TestRunnerRunner.GetArguments(string.Empty, settings);

            Assert.Equal(0, args.Count(argument => argument.Render() == "-A"));
        }
    }
}
