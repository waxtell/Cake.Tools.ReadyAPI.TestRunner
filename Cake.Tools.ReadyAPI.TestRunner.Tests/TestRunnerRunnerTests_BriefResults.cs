using System.Linq;
using Xunit;

namespace Cake.Tools.ReadyAPI.TestRunner.Tests
{
    public partial class TestRunnerRunnerTests
    {
        [Fact]
        public void GetArguments_BriefResultsTrueHasArgument()
        {
            var settings = new TestRunnerSettings
            {
                BriefResults = true
            };

            var args = TestRunnerRunner.GetArguments(string.Empty, settings);

            Assert.Equal(1, args.Count(argument => argument.Render() == "-M" ));
        }

        [Fact]
        public void GetArguments_BriefResultsFalseNoArgument()
        {
            var settings = new TestRunnerSettings
            {
                BriefResults = false
            };

            var args = TestRunnerRunner.GetArguments(string.Empty, settings);

            Assert.Equal(0, args.Count(argument => argument.Render() == "-M"));
        }
    }
}
