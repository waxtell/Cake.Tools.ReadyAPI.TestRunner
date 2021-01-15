using System.Linq;
using Xunit;

namespace Cake.Tools.ReadyAPI.TestRunner.Tests
{
    public partial class TestRunnerRunnerTests
    {
        [Fact]
        public void GetArguments_SettingsFileProvidedHasArgument()
        {
            var settings = new TestRunnerSettings
            {
                SettingsFile = "readyapi-settings.xml"
            };

            var args = TestRunnerRunner.GetArguments(string.Empty, settings);

            Assert.Equal(1, args.Count(argument => argument.Render() == "-treadyapi-settings.xml"));
        }

        [Fact]
        public void GetArguments_EmptySettingsFileNoArgument()
        {
            var settings = new TestRunnerSettings
            {
                SettingsFile = string.Empty
            };

            var args = TestRunnerRunner.GetArguments(string.Empty, settings);

            Assert.Equal(0, args.Count(argument => argument.Render().StartsWith("-t")));
        }

        [Fact]
        public void GetArguments_NullSettingsFileNoArgument()
        {
            var settings = new TestRunnerSettings
            {
                SettingsFile = null
            };

            var args = TestRunnerRunner.GetArguments(string.Empty, settings);

            Assert.Equal(0, args.Count(argument => argument.Render().StartsWith("-t")));
        }
    }
}
