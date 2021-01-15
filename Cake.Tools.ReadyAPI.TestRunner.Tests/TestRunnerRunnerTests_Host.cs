using System.Linq;
using Xunit;

namespace Cake.Tools.ReadyAPI.TestRunner.Tests
{
    public partial class TestRunnerRunnerTests
    {
        [Fact]
        public void GetArguments_HostProvidedHasArgument()
        {
            var settings = new TestRunnerSettings
            {
                Host = "localhost"
            };

            var args = TestRunnerRunner.GetArguments(string.Empty, settings);

            Assert.Equal(1, args.Count(argument => argument.Render() == "-hlocalhost"));
        }

        [Fact]
        public void GetArguments_EmptyHostNoArgument()
        {
            var settings = new TestRunnerSettings
            {
                Host = string.Empty
            };

            var args = TestRunnerRunner.GetArguments(string.Empty, settings);

            Assert.Equal(0, args.Count(argument => argument.Render().StartsWith("-h")));
        }

        [Fact]
        public void GetArguments_NullHostNoArgument()
        {
            var settings = new TestRunnerSettings
            {
                Host = null
            };

            var args = TestRunnerRunner.GetArguments(string.Empty, settings);

            Assert.Equal(0, args.Count(argument => argument.Render().StartsWith("-h")));
        }
    }
}
