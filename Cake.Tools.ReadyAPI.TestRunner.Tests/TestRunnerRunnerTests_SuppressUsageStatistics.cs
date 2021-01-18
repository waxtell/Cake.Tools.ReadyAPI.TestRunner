using System.Linq;
using Xunit;

namespace Cake.Tools.ReadyAPI.TestRunner.Tests
{
    public partial class TestRunnerRunnerTests
    {
        [Fact]
        public void GetArguments_SuppressUsageStatisticsTrueHasArgument()
        {
            var settings = new TestRunnerSettings
            {
                SuppressUsageStatistics = true
            };

            var args = TestRunnerRunner.GetArguments(string.Empty, settings);

            Assert.Equal(1, args.Count(argument => argument.Render() == "-O" ));
        }

        [Fact]
        public void GetArguments_SuppressUsageStatisticsFalseNoArgument()
        {
            var settings = new TestRunnerSettings
            {
                SuppressUsageStatistics = false
            };

            var args = TestRunnerRunner.GetArguments(string.Empty, settings);

            Assert.Equal(0, args.Count(argument => argument.Render() == "-O"));
        }
    }
}
