using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Cake.Tools.ReadyAPI.TestRunner.Tests
{
    public partial class TestRunnerRunnerTests
    {
        [Fact]
        public void GetArguments_SingleHeadersProvidedHasSingleArgument()
        {
            var settings = new TestRunnerSettings
            {
                Headers = new Dictionary<string, string>
                    {{ "x-content-type-options","nosniff" }}
            };

            var args = TestRunnerRunner.GetArguments(string.Empty, settings);

            Assert.Equal(1, args.Count(argument => argument.Render() == "-Hx-content-type-options=nosniff"));
        }

        [Fact]
        public void GetArguments_MultipleHeadersProvidedHasMultipleArguments()
        {
            var settings = new TestRunnerSettings
            {
                Headers = new Dictionary<string, string>
                {
                    { "x-content-type-options","nosniff" },
                    { "Accept-Language", "de-CH" }
                }
            };

            var args = TestRunnerRunner.GetArguments(string.Empty, settings);

            Assert.Equal(1, args.Count(argument => argument.Render() == "-Hx-content-type-options=nosniff"));
            Assert.Equal(1, args.Count(argument => argument.Render() == "-HAccept-Language=de-CH"));
        }

        [Fact]
        public void GetArguments_EmptyHeadersNoArgument()
        {
            var settings = new TestRunnerSettings
            {
                Headers = new Dictionary<string, string>()
            };

            var args = TestRunnerRunner.GetArguments(string.Empty, settings);

            Assert.Equal(0, args.Count(argument => argument.Render().StartsWith("-H")));
        }

        [Fact]
        public void GetArguments_NullHeadersNoArgument()
        {
            var settings = new TestRunnerSettings
            {
                Headers = null
            };

            var args = TestRunnerRunner.GetArguments(string.Empty, settings);

            Assert.Equal(0, args.Count(argument => argument.Render().StartsWith("-H")));
        }
    }
}
