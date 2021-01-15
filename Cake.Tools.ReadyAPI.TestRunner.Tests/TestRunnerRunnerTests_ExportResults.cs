using System.Linq;
using Xunit;

namespace Cake.Tools.ReadyAPI.TestRunner.Tests
{
    public partial class TestRunnerRunnerTests
    {
        [Fact]
        public void GetArguments_ExportResultsTrueHasArgument()
        {
            var settings = new TestRunnerSettings
            {
                ExportResults = true
            };

            var args = TestRunnerRunner.GetArguments(string.Empty, settings);

            Assert.Equal(1, args.Count(argument => argument.Render() == "-a" ));
        }

        [Fact]
        public void GetArguments_ExportResultsFalseNoArgument()
        {
            var settings = new TestRunnerSettings
            {
                ExportResults = false
            };

            var args = TestRunnerRunner.GetArguments(string.Empty, settings);

            Assert.Equal(0, args.Count(argument => argument.Render() == "-a"));
        }
    }
}
