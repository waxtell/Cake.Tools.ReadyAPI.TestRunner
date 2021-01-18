using System.Linq;
using Xunit;

namespace Cake.Tools.ReadyAPI.TestRunner.Tests
{
    public partial class TestRunnerRunnerTests
    {
        [Fact]
        public void GetArguments_DomainProvidedHasArgument()
        {
            var settings = new TestRunnerSettings
            {
                Domain = "HelloWorld"
            };

            var args = TestRunnerRunner.GetArguments(string.Empty, settings);

            Assert.Equal(1, args.Count(argument => argument.Render() == "-dHelloWorld"));
        }

        [Fact]
        public void GetArguments_EmptyDomainNoArgument()
        {
            var settings = new TestRunnerSettings
            {
                Domain = string.Empty
            };

            var args = TestRunnerRunner.GetArguments(string.Empty, settings);

            Assert.Equal(0, args.Count(argument => argument.Render().StartsWith("-d")));
        }

        [Fact]
        public void GetArguments_NullDomainNoArgument()
        {
            var settings = new TestRunnerSettings
            {
                Domain = null
            };

            var args = TestRunnerRunner.GetArguments(string.Empty, settings);

            Assert.Equal(0, args.Count(argument => argument.Render().StartsWith("-d")));
        }
    }
}
