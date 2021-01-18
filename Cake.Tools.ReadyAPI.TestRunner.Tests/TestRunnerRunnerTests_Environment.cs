using System.Linq;
using Xunit;

namespace Cake.Tools.ReadyAPI.TestRunner.Tests
{
    public partial class TestRunnerRunnerTests
    {
        [Fact]
        public void GetArguments_EnvironmentProvidedHasArgument()
        {
            var settings = new TestRunnerSettings
            {
                Environment = "NewEnvironment"
            };

            var args = TestRunnerRunner.GetArguments(string.Empty, settings);

            Assert.Equal(1, args.Count(argument => argument.Render() == "-ENewEnvironment"));
        }

        [Fact]
        public void GetArguments_EmptyEnvironmentNoArgument()
        {
            var settings = new TestRunnerSettings
            {
                Environment = string.Empty
            };

            var args = TestRunnerRunner.GetArguments(string.Empty, settings);

            Assert.Equal(0, args.Count(argument => argument.Render().StartsWith("-E")));
        }

        [Fact]
        public void GetArguments_NullEnvironmentNoArgument()
        {
            var settings = new TestRunnerSettings
            {
                Environment = null
            };

            var args = TestRunnerRunner.GetArguments(string.Empty, settings);

            Assert.Equal(0, args.Count(argument => argument.Render().StartsWith("-E")));
        }
    }
}
