using System.Linq;
using Xunit;

namespace Cake.Tools.ReadyAPI.TestRunner.Tests
{
    public partial class TestRunnerRunnerTests
    {
        [Fact]
        public void GetArguments_IncludeTestPropertiesTrueHasArgument()
        {
            var settings = new TestRunnerSettings
            {
                IncludeTestProperties = true
            };

            var args = TestRunnerRunner.GetArguments(string.Empty, settings);

            Assert.Equal(1, args.Count(argument => argument.Render() == "-J" ));
        }

        [Fact]
        public void GetArguments_IncludeTestPropertiesFalseNoArgument()
        {
            var settings = new TestRunnerSettings
            {
                IncludeTestProperties = false
            };

            var args = TestRunnerRunner.GetArguments(string.Empty, settings);

            Assert.Equal(0, args.Count(argument => argument.Render() == "-J"));
        }
    }
}
