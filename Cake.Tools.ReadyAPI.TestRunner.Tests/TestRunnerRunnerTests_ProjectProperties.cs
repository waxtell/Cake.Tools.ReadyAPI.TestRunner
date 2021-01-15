using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Cake.Tools.ReadyAPI.TestRunner.Tests
{
    public partial class TestRunnerRunnerTests
    {
        [Fact]
        public void GetArguments_SingleProjectPropertiesProvidedHasSingleArgument()
        {
            var settings = new TestRunnerSettings
            {
                ProjectProperties = new Dictionary<string, string>
                    {{ "project.property", "Hello World" }}
            };

            var args = TestRunnerRunner.GetArguments(string.Empty, settings);

            Assert.Equal(1, args.Count(argument => argument.Render() == "-Pproject.property=\"Hello World\""));
        }

        [Fact]
        public void GetArguments_MultipleProjectPropertiesProvidedHasMultipleArguments()
        {
            var settings = new TestRunnerSettings
            {
                ProjectProperties = new Dictionary<string, string>
                {
                    { "project.property", "Hello World" },
                    { "project.otherproperty", "Hello" }
                }
            };

            var args = TestRunnerRunner.GetArguments(string.Empty, settings);

            Assert.Equal(1, args.Count(argument => argument.Render() == "-Pproject.property=\"Hello World\""));
            Assert.Equal(1, args.Count(argument => argument.Render() == "-Pproject.otherproperty=\"Hello\""));
        }

        [Fact]
        public void GetArguments_EmptyProjectPropertiesNoArgument()
        {
            var settings = new TestRunnerSettings
            {
                ProjectProperties = new Dictionary<string, string>()
            };

            var args = TestRunnerRunner.GetArguments(string.Empty, settings);

            Assert.Equal(0, args.Count(argument => argument.Render().StartsWith("-P")));
        }

        [Fact]
        public void GetArguments_NullProjectPropertiesNoArgument()
        {
            var settings = new TestRunnerSettings
            {
                ProjectProperties = null
            };

            var args = TestRunnerRunner.GetArguments(string.Empty, settings);

            Assert.Equal(0, args.Count(argument => argument.Render().StartsWith("-P")));
        }
    }
}
