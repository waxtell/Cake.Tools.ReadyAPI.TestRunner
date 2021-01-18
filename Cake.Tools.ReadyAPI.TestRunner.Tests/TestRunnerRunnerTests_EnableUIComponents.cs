using System.Linq;
using Xunit;

namespace Cake.Tools.ReadyAPI.TestRunner.Tests
{
    public partial class TestRunnerRunnerTests
    {
        [Fact]
        public void GetArguments_EnableUIComponentsTrueHasArgument()
        {
            var settings = new TestRunnerSettings
            {
                EnableUIComponents = true
            };

            var args = TestRunnerRunner.GetArguments(string.Empty, settings);

            Assert.Equal(1, args.Count(argument => argument.Render() == "-i" ));
        }

        [Fact]
        public void GetArguments_EnableUIComponentsFalseNoArgument()
        {
            var settings = new TestRunnerSettings
            {
                EnableUIComponents = false
            };

            var args = TestRunnerRunner.GetArguments(string.Empty, settings);

            Assert.Equal(0, args.Count(argument => argument.Render() == "-i"));
        }
    }
}
