using System.Linq;
using Xunit;

namespace Cake.Tools.ReadyAPI.TestRunner.Tests
{
    public partial class TestRunnerRunnerTests
    {
        [Fact]
        public void GetArguments_EndPointProvidedHasArgument()
        {
            var settings = new TestRunnerSettings
            {
                EndPoint = "localhost:8080"
            };

            var args = TestRunnerRunner.GetArguments(string.Empty, settings);

            Assert.Equal(1, args.Count(argument => argument.Render() == "-dlocalhost:8080"));
        }

        [Fact]
        public void GetArguments_EmptyEndPointNoArgument()
        {
            var settings = new TestRunnerSettings
            {
                EndPoint = string.Empty
            };

            var args = TestRunnerRunner.GetArguments(string.Empty, settings);

            Assert.Equal(0, args.Count(argument => argument.Render().StartsWith("-d")));
        }

        [Fact]
        public void GetArguments_NullEndPointNoArgument()
        {
            var settings = new TestRunnerSettings
            {
                EndPoint = null
            };

            var args = TestRunnerRunner.GetArguments(string.Empty, settings);

            Assert.Equal(0, args.Count(argument => argument.Render().StartsWith("-d")));
        }
    }
}
