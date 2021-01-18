using System.Linq;
using Xunit;

namespace Cake.Tools.ReadyAPI.TestRunner.Tests
{
    public partial class TestRunnerRunnerTests
    {
        [Fact]
        public void GetArguments_OutputFolderProvidedHasArgument()
        {
            var settings = new TestRunnerSettings
            {
                OutputFolder = "HelloWorld"
            };

            var args = TestRunnerRunner.GetArguments(string.Empty, settings);

            Assert.Equal(1, args.Count(argument => argument.Render() == "-fHelloWorld"));
        }

        [Fact]
        public void GetArguments_EmptyOutputFolderNoArgument()
        {
            var settings = new TestRunnerSettings
            {
                OutputFolder = string.Empty
            };

            var args = TestRunnerRunner.GetArguments(string.Empty, settings);

            Assert.Equal(0, args.Count(argument => argument.Render().StartsWith("-f")));
        }

        [Fact]
        public void GetArguments_NullOutputFolderNoArgument()
        {
            var settings = new TestRunnerSettings
            {
                OutputFolder = null
            };

            var args = TestRunnerRunner.GetArguments(string.Empty, settings);

            Assert.Equal(0, args.Count(argument => argument.Render().StartsWith("-f")));
        }
    }
}
