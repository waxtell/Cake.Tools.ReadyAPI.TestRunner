using System.Collections.Generic;
using Cake.Core.Tooling;

namespace Cake.Tools.ReadyAPI.TestRunner
{
    /// <summary>
    /// Contains the settings used by TestRunner.bat
    /// Please see <a href="https://support.smartbear.com/readyapi/docs/functional/running/automating/cli.html">Command-Line SystemProperties</a> for additional information
    /// </summary>
    public class TestRunnerSettings : ToolSettings
    {
        /// <summary>
        /// Commands the runner to create an XML file with brief test results.
        /// </summary>
        public bool BriefResults { get; set; }

        /// <summary>
        /// Commands the runner to create a coverage report (HTML format).
        /// </summary>
        public bool CreateCoverageReport { get; set; } = false;

        /// <summary>
        /// Commands the runner to create JUnit-compatible reports.
        /// </summary>
        public bool CreateJUnitCompatibleReports { get; set; } = false;

        /// <summary>
        /// Specifies the domain that ReadyAPI will use for authorization.
        /// <para>This argument overrides the authorization domain you have specified for test steps in your project.</para>
        /// </summary>
        public string Domain { get; set; }

        /// <summary>
        /// Commands the runner to enable UI components. Use this command-line argument if you use the <code>UISupport</code> class in your tests.
        /// </summary>
        public bool EnableUIComponents { get; set; } = false;

        /// <summary>
        /// Specifies the endpoint to be used in test requests. The specified endpoint should include the protocol part (for example, https://).
        /// <para>This argument overrides the endpoints you have specified for test steps in your project.See the -h argument description.</para>
        /// <para>Note:	The runner ignores this parameter if <see cref="Environment"/> is specified.In this case, the endpoint is taken from the environment settings.</para>
        /// </summary>
        public string EndPoint { get; set; }

        /// <summary>
        /// Specifies the environment to be used in the test run. If specified, Environment overrides the <see cref="EndPoint"/>, <see cref="Username"/>, and <see cref="Password"/> parameters so that the values are taken from the environment.
        /// </summary>
        public string Environment { get; set; }

        /// <summary>
        /// Commands the runner to export all test results. Otherwise, it exports only information about errors.
        /// </summary>
        public bool ExportResults { get; set; }

        /// <summary>
        /// Turns on exporting of all results using folders instead of long filenames
        /// </summary>
        public bool ExportResultsUsingFolders { get; set; }

        /// <summary>
        /// Specifies a value of the global property for the test run. This value will override the variable’s value during the run.
        /// </summary>
        public IDictionary<string, string> GlobalProperties { get; set; }

        /// <summary>
        /// Use this argument to add a custom HTTP header to all simulated requests.
        /// </summary>
        public IDictionary<string, string> Headers { get; set; }

        /// <summary>
        /// Specifies the host and port to be used in test requests.
        /// <para>You can specify the host by using its IP address or name.</para>
        /// <para>This argument overrides the endpoints you have specified in the project file.  See the <see cref="EndPoint"/> argument description.</para>
        /// </summary>
        public string Host { get; set; }

        /// <summary>
        /// Commands the runner to include JUnit XML reports with test properties to the report. 
        /// </summary>
        public bool IncludeTestProperties { get; set; } = false;

        /// <summary>
        /// Commands the runner to ignore errors. If you put this argument to the command line, the test log will contain no information on errors occurred during the test run.
        /// If you skip this argument, the runner will stop the run after the first error occurs and will post full information about the error to the log.
        /// </summary>
        public bool IgnoreErrors { get; set; } = false;

        /// <summary>
        /// Commands the runner to open the reports ReadyAPI created in your default web browser after the test run is over.
        /// </summary>
        public bool OpenReportsInBrowser { get; set; } = false;

        /// <summary>
        /// Sets the output folder to export results to
        /// </summary>
        public string OutputFolder { get; set; }

        /// <summary>
        /// Sets password for readyapi-settings.xml file
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Sets the WSS password type, either 'Text' or 'Digest'
        /// </summary>
        public PasswordType? PasswordType { get; set; }

        /// <summary>
        /// Prints a small summary report
        /// </summary>
        public bool PrintSummaryReport { get; set; } = false;

        /// <summary>
        /// Specifies the project password, if you have encrypted the entire project or some of its custom properties. See <a href="https://support.smartbear.com/readyapi/docs/testing/best-practices/secure.html">Protecting Sensitive Data</a>.
        /// </summary>
        public string ProjectPassword { get; set; }

        /// <summary>
        /// Specifies a value of a project property for the test run. This value will override the variable’s value during the run.
        /// </summary>
        public IDictionary<string, string> ProjectProperties { get; set; }

        /// <summary>
        /// Specifies the type of the report data.
        /// <list type="bullet">
        /// <item><term>Project Report:</term><description>Generates a report in the format the -F argument specifies.The runner will save the report files to the directory that the <see cref="OutputFolder"/> argument specifies.Depending on the <see cref="ExportResultsUsingFolders"/> argument value, the runner can organize files into subdirectories.</description></item>
        /// <item><term>TestSuite Report:</term><description>As above, but for test suites.</description></item>
        /// <item><term>TestCase Report:</term><description>As above, but for test cases.</description></item>
        /// <item><term>JUnit-Style HTML Report:</term><description>Generates a report as JUnit-style HTML files. See JUnit-Style HTML Reports For Automation. When you use this value, the runner ignores the <see cref="ReportFormats"/> and <see cref="ExportResultsUsingFolders"/> arguments.</description></item>
        /// <item><term>Data Export:</term><description>Generates XML files with report data. See Data Export For Automation.</description></item>
        /// <item><term>Allure Report:</term><description>Generates Allure results.Use the Allure framework to generate an actual report.See Allure Report.</description></item>
        /// </list>
        /// </summary>
        public ReportType? Report { get; set; }

        /// <summary>
        /// Specifies the format of the reports ReadyAPI exports.
        /// <para>ReadyAPI supports the following formats: PDF, XLS, HTML, RTF, CSV, TXT and XML.If you have not specified the parameter, ReadyAPI will use the PDF format.</para>
        /// </summary>
        public ReportFormat? ReportFormats { get; set; }

        /// <summary>
        /// Commands the runner to save the test project after the test run finishes. Use this command-line argument if you store data within the project during the test.
        /// </summary>
        public bool SaveProject { get; set; }

        /// <summary>
        /// Sets the readyapi-settings.xml file to use
        /// </summary>
        public string SettingsFile { get; set; }

        /// <summary>
        /// Your Slack bot authentication token
        /// </summary>
        public string SlackAccessToken { get; set; }

        /// <summary>
        /// List of Slack channels in the #channel-name format, or the IDs of the users the test results will be sent to. You can specify both channels and user IDs.
        /// </summary>
        public IEnumerable<string> SlackChannels { get; set; }

        /// <summary>
        /// Commands the runner to renounce collecting and sending usage statistics.
        /// </summary>
        public bool SuppressUsageStatistics { get; set; }

        /// <summary>
        /// Specifies the password for your XML setting file.
        /// </summary>
        public string SettingsPassword { get; set; }

        /// <summary>
        /// Specifies a value of a system property for the test run. This value will override the variable’s value during the run.
        /// </summary>
        public IDictionary<string, string> SystemProperties { get; set; }

        /// <summary>
        /// Specifies the test case to be run. If you skip this argument, the runner will execute all test cases in your test project.
        /// </summary>
        public string TestCase { get; set; }

        /// <summary>
        /// Runs only the test cases whose tags are specified
        /// </summary>
        public string TestCaseTags { get; set; }

        /// <summary>
        /// Specifies the test suite to be run. If you skip this argument, the runner will execute all test suites in your project.
        /// </summary>
        public string TestSuite { get; set; }

        /// <summary>
        /// Runs only the test cases or test suites whose tags are specified.Format: "TestCase tag1[,tag2...]" or "TestSuite tag1[, tag2...]".
        /// </summary>
        public string TestSuiteTags { get; set; }

        /// <summary>
        /// Specifies the user name to be used in test request authorizations.
        /// This argument overrides user names in your test project.
        /// <para>
        /// Note: The runner ignores this parameter if -E is specified.In this case, the user name is taken from the environment settings.
        /// </para>
        /// </summary>
        public string Username { get; set; }
    }
}
