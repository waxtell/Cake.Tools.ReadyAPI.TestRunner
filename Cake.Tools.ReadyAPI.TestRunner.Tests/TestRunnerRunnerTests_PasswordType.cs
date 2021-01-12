using System.Linq;
using Xunit;

namespace Cake.Tools.ReadyAPI.TestRunner.Tests
{
    public partial class TestRunnerRunnerTests
    {
        [Fact]
        public void GetArguments_PasswordTypeProvidedHasArgument()
        {
            var settings = new TestRunnerSettings
            {
                PasswordType = "Text"
            };

            var args = TestRunnerRunner.GetArguments(string.Empty, settings);

            Assert.Equal(1, args.Count(argument => argument.Render() == "-wText"));
        }

        [Fact]
        public void GetArguments_EmptyPasswordTypeNoArgument()
        {
            var settings = new TestRunnerSettings
            {
                PasswordType = string.Empty
            };

            var args = TestRunnerRunner.GetArguments(string.Empty, settings);

            Assert.Equal(0, args.Count(argument => argument.Render().StartsWith("-w")));
        }

        [Fact]
        public void GetArguments_NullPasswordTypeNoArgument()
        {
            var settings = new TestRunnerSettings
            {
                PasswordType = null
            };

            var args = TestRunnerRunner.GetArguments(string.Empty, settings);

            Assert.Equal(0, args.Count(argument => argument.Render().StartsWith("-w")));
        }
    }
}
