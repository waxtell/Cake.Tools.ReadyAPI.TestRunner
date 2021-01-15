using System.Linq;
using Xunit;

namespace Cake.Tools.ReadyAPI.TestRunner.Tests
{
    public partial class TestRunnerRunnerTests
    {
        [Fact]
        public void GetArguments_DigestPasswordTypeProvidedHasArgument()
        {
            var settings = new TestRunnerSettings
            {
                PasswordType = PasswordType.Digest
            };

            var args = TestRunnerRunner.GetArguments(string.Empty, settings);

            Assert.Equal(1, args.Count(argument => argument.Render() == "-wDigest"));
        }

        [Fact]
        public void GetArguments_TextPasswordTypeProvidedHasArgument()
        {
            var settings = new TestRunnerSettings
            {
                PasswordType = PasswordType.Text
            };

            var args = TestRunnerRunner.GetArguments(string.Empty, settings);

            Assert.Equal(1, args.Count(argument => argument.Render() == "-wText"));
        }

        [Fact]
        public void GetArguments_NullPasswordTypeNoArgument()
        {
            var settings = new TestRunnerSettings
            {
                PasswordType = null
            };

            var args = TestRunnerRunner.GetArguments(string.Empty, settings);

            Assert.Equal(0, args.Count(argument => argument.Render().StartsWith("-w")));
        }
    }
}
