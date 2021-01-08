using Cake.Core;
using Cake.Core.Annotations;

namespace Cake.Tools.ReadyAPI.TestRunner
{
    /// <summary>
    /// <para>
    /// <code>#addin Cake.Tools.ReadyAPI.TestRunner</code>
    /// </para>
    /// <para>
    /// If TestRunner.bat is not included in the PATH you will have to provide the location of TestRunner.bat as such
    /// <example>
    /// <code>
    /// Setup(context => {
    ///     context.Tools.RegisterFile("C:/Program Files/SmartBear/ReadyAPI-3.5.1/bin/testrunner.bat");
    /// });
    /// </code>
    /// </example>
    /// </para>
    /// </summary>
    [CakeAliasCategory("ReadyAPITestRunner")]
    public static class TestRunnerAliases
    {
        /// <summary>
        /// Run your ReadyAPI functional test(s).
        /// <example>
        /// <code>
        /// var result = LaunchTestRunner
        /// (
        ///     "your-readyapi-project.xml",
        ///     new TestRunnerSettings()
        ///     {
        ///         EndPoint = "http://localhost",
        ///         PrintSummaryReport = true
        ///     }
        /// );
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="context">The Cake context.</param>
        /// <param name="projectFile">The ReadyAPI project.</param>
        /// <param name="settings">The settings that will be provided to TestRunner.bat.</param>
        /// <returns>0 for success.  Please see <a href="https://support.smartbear.com/readyapi/docs/functional/running/automating/exit-codes.html">Exit Codes</a> for additional information</returns>
        [CakeMethodAlias]
        public static int LaunchTestRunner(this ICakeContext context, string projectFile, TestRunnerSettings settings)
        {
            return
                new TestRunnerRunner
                (
                    context.FileSystem,
                    context.Environment,
                    context.ProcessRunner,
                    context.Tools
                )
                .RunFunctionalTests
                (
                    projectFile, 
                    settings
                );
        }
    }
}
