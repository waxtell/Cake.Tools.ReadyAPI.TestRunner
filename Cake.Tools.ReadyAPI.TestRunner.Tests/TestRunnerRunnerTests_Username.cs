using System.Linq;
using Xunit;

namespace Cake.Tools.ReadyAPI.TestRunner.Tests
{
    public partial class TestRunnerRunnerTests
    {
        [Fact]
        public void GetArguments_UsernameProvidedHasArgument()
        {
            var settings = new TestRunnerSettings
            {
                Username = "Username"
            };

            var args = TestRunnerRunner.GetArguments(string.Empty, settings);

            Assert.Equal(1, args.Count(argument => argument.Render() == "-uUsername"));
        }

        [Fact]
        public void GetArguments_EmptyUsernameNoArgument()
        {
            var settings = new TestRunnerSettings
            {
                Username = string.Empty
            };

            var args = TestRunnerRunner.GetArguments(string.Empty, settings);

            Assert.Equal(0, args.Count(argument => argument.Render().StartsWith("-u")));
        }

        [Fact]
        public void GetArguments_NullUsernameNoArgument()
        {
            var settings = new TestRunnerSettings
            {
                Username = null
            };

            var args = TestRunnerRunner.GetArguments(string.Empty, settings);

            Assert.Equal(0, args.Count(argument => argument.Render().StartsWith("-u")));
        }
    }
}
