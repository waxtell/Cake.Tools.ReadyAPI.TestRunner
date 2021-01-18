using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Cake.Tools.ReadyAPI.TestRunner.Tests
{
    public partial class TestRunnerRunnerTests
    {
        [Fact]
        public void GetArguments_SingleGlobalPropertiesProvidedHasSingleArgument()
        {
            var settings = new TestRunnerSettings
            {
                GlobalProperties = new Dictionary<string, string>
                    {{ "Hello", "World" }}
            };

            var args = TestRunnerRunner.GetArguments(string.Empty, settings);

            Assert.Equal(1, args.Count(argument => argument.Render() == "-GHello=\"World\""));
        }

        [Fact]
        public void GetArguments_MultipleGlobalPropertiesProvidedHasMultipleArguments()
        {
            var settings = new TestRunnerSettings
            {
                GlobalProperties = new Dictionary<string, string>
                {
                    { "Hello", "World" },
                    { "World", "Hello" }
                }
            };

            var args = TestRunnerRunner.GetArguments(string.Empty, settings);

            Assert.Equal(1, args.Count(argument => argument.Render() == "-GHello=\"World\""));
            Assert.Equal(1, args.Count(argument => argument.Render() == "-GWorld=\"Hello\""));
        }

        [Fact]
        public void GetArguments_EmptyGlobalPropertiesNoArgument()
        {
            var settings = new TestRunnerSettings
            {
                GlobalProperties = new Dictionary<string, string>()
            };

            var args = TestRunnerRunner.GetArguments(string.Empty, settings);

            Assert.Equal(0, args.Count(argument => argument.Render().StartsWith("-G")));
        }

        [Fact]
        public void GetArguments_NullGlobalPropertiesNoArgument()
        {
            var settings = new TestRunnerSettings
            {
                GlobalProperties = null
            };

            var args = TestRunnerRunner.GetArguments(string.Empty, settings);

            Assert.Equal(0, args.Count(argument => argument.Render().StartsWith("-G")));
        }
    }
}
