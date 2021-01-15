using System.Linq;
using Xunit;

namespace Cake.Tools.ReadyAPI.TestRunner.Tests
{
    public partial class TestRunnerRunnerTests
    {
        [Fact]
        public void GetArguments_PasswordProvidedHasArgument()
        {
            var settings = new TestRunnerSettings
            {
                Password = "HelloWorld"
            };

            var args = TestRunnerRunner.GetArguments(string.Empty, settings);

            Assert.Equal(1, args.Count(argument => argument.Render() == "-pHelloWorld"));
        }

        [Fact]
        public void GetArguments_EmptyPasswordNoArgument()
        {
            var settings = new TestRunnerSettings
            {
                Password = string.Empty
            };

            var args = TestRunnerRunner.GetArguments(string.Empty, settings);

            Assert.Equal(0, args.Count(argument => argument.Render().StartsWith("-p")));
        }

        [Fact]
        public void GetArguments_NullPasswordNoArgument()
        {
            var settings = new TestRunnerSettings
            {
                Password = null
            };

            var args = TestRunnerRunner.GetArguments(string.Empty, settings);

            Assert.Equal(0, args.Count(argument => argument.Render().StartsWith("-p")));
        }
    }
}
