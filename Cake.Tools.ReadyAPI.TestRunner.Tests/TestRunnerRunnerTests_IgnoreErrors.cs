using System.Linq;
using Xunit;

namespace Cake.Tools.ReadyAPI.TestRunner.Tests
{
    public partial class TestRunnerRunnerTests
    {
        [Fact]
        public void GetArguments_IgnoreErrorsTrueHasArgument()
        {
            var settings = new TestRunnerSettings
            {
                IgnoreErrors = true
            };

            var args = TestRunnerRunner.GetArguments(string.Empty, settings);

            Assert.Equal(1, args.Count(argument => argument.Render() == "-I" ));
        }

        [Fact]
        public void GetArguments_IgnoreErrorsFalseNoArgument()
        {
            var settings = new TestRunnerSettings
            {
                IgnoreErrors = false
            };

            var args = TestRunnerRunner.GetArguments(string.Empty, settings);

            Assert.Equal(0, args.Count(argument => argument.Render() == "-I"));
        }
    }
}
