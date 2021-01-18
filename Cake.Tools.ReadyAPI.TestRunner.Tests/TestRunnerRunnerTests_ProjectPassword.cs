using System.Linq;
using Xunit;

namespace Cake.Tools.ReadyAPI.TestRunner.Tests
{
    public partial class TestRunnerRunnerTests
    {
        [Fact]
        public void GetArguments_ProjectPasswordProvidedHasArgument()
        {
            var settings = new TestRunnerSettings
            {
                ProjectPassword = "password"
            };

            var args = TestRunnerRunner.GetArguments(string.Empty, settings);

            Assert.Equal(1, args.Count(argument => argument.Render() == "-xpassword"));
        }

        [Fact]
        public void GetArguments_EmptyProjectPasswordNoArgument()
        {
            var settings = new TestRunnerSettings
            {
                ProjectPassword = string.Empty
            };

            var args = TestRunnerRunner.GetArguments(string.Empty, settings);

            Assert.Equal(0, args.Count(argument => argument.Render().StartsWith("-x")));
        }

        [Fact]
        public void GetArguments_NullProjectPasswordNoArgument()
        {
            var settings = new TestRunnerSettings
            {
                ProjectPassword = null
            };

            var args = TestRunnerRunner.GetArguments(string.Empty, settings);

            Assert.Equal(0, args.Count(argument => argument.Render().StartsWith("-x")));
        }
    }
}
