using System.Linq;
using Xunit;

namespace Cake.Tools.ReadyAPI.TestRunner.Tests
{
    public partial class TestRunnerRunnerTests
    {
        [Fact]
        public void GetArguments_SaveProjectTrueHasArgument()
        {
            var settings = new TestRunnerSettings
            {
                SaveProject = true
            };

            var args = TestRunnerRunner.GetArguments(string.Empty, settings);

            Assert.Equal(1, args.Count(argument => argument.Render() == "-S" ));
        }

        [Fact]
        public void GetArguments_SaveProjectFalseNoArgument()
        {
            var settings = new TestRunnerSettings
            {
                SaveProject = false
            };

            var args = TestRunnerRunner.GetArguments(string.Empty, settings);

            Assert.Equal(0, args.Count(argument => argument.Render() == "-S"));
        }
    }
}
