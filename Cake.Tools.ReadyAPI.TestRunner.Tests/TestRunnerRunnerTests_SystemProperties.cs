using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Cake.Tools.ReadyAPI.TestRunner.Tests
{
    public partial class TestRunnerRunnerTests
    {
        [Fact]
        public void GetArguments_SingleSystemPropertiesProvidedHasSingleArgument()
        {
            var settings = new TestRunnerSettings
            {
                SystemProperties = new Dictionary<string, string>
                    {{ "Hello", "World" }}
            };

            var args = TestRunnerRunner.GetArguments(string.Empty, settings);

            Assert.Equal(1, args.Count(argument => argument.Render() == "-DHello=\"World\""));
        }

        [Fact]
        public void GetArguments_MultipleSystemPropertiesProvidedHasMultipleArguments()
        {
            var settings = new TestRunnerSettings
            {
                SystemProperties = new Dictionary<string, string>
                {
                    { "Hello", "World" },
                    { "World", "Hello" }
                }
            };

            var args = TestRunnerRunner.GetArguments(string.Empty, settings);

            Assert.Equal(1, args.Count(argument => argument.Render() == "-DHello=\"World\""));
            Assert.Equal(1, args.Count(argument => argument.Render() == "-DWorld=\"Hello\""));
        }

        [Fact]
        public void GetArguments_EmptySystemPropertiesNoArgument()
        {
            var settings = new TestRunnerSettings
            {
                SystemProperties = new Dictionary<string, string>()
            };

            var args = TestRunnerRunner.GetArguments(string.Empty, settings);

            Assert.Equal(0, args.Count(argument => argument.Render().StartsWith("-D")));
        }

        [Fact]
        public void GetArguments_NullSystemPropertiesNoArgument()
        {
            var settings = new TestRunnerSettings
            {
                SystemProperties = null
            };

            var args = TestRunnerRunner.GetArguments(string.Empty, settings);

            Assert.Equal(0, args.Count(argument => argument.Render().StartsWith("-D")));
        }
    }
}
