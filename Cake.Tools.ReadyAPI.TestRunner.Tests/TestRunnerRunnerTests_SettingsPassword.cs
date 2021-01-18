using System.Linq;
using Xunit;

namespace Cake.Tools.ReadyAPI.TestRunner.Tests
{
    public partial class TestRunnerRunnerTests
    {
        [Fact]
        public void GetArguments_SettingsPasswordProvidedHasArgument()
        {
            var settings = new TestRunnerSettings
            {
                SettingsPassword = "password"
            };

            var args = TestRunnerRunner.GetArguments(string.Empty, settings);

            Assert.Equal(1, args.Count(argument => argument.Render() == "-vpassword"));
        }

        [Fact]
        public void GetArguments_EmptySettingsPasswordNoArgument()
        {
            var settings = new TestRunnerSettings
            {
                SettingsPassword = string.Empty
            };

            var args = TestRunnerRunner.GetArguments(string.Empty, settings);

            Assert.Equal(0, args.Count(argument => argument.Render().StartsWith("-v")));
        }

        [Fact]
        public void GetArguments_NullSettingsPasswordNoArgument()
        {
            var settings = new TestRunnerSettings
            {
                SettingsPassword = null
            };

            var args = TestRunnerRunner.GetArguments(string.Empty, settings);

            Assert.Equal(0, args.Count(argument => argument.Render().StartsWith("-v")));
        }
    }
}
