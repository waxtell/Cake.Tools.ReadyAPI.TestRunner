// ReSharper disable once CheckNamespace
namespace Cake.Tools.ReadyAPI.TestRunner
{
    /// <summary>
    /// Specifies the type of the report data.
    /// </summary>
    public enum ReportType
    {
        /// <summary>
        /// Generates a report in the format the -F argument specifies.The runner will save the report files to the directory that the <see cref="OutputFolder"/> argument specifies.Depending on the <see cref="ExportResultsUsingFolders"/> argument value, the runner can organize files into subdirectories.
        /// </summary>
        Project,
        /// <summary>
        /// As above, but for test suites.
        /// </summary>
        TestSuite,
        /// <summary>
        /// As above, but for test cases.
        /// </summary>
        TestCase,
        /// <summary>
        /// Generates a report as JUnit-style HTML files. See JUnit-Style HTML Reports For Automation. When you use this value, the runner ignores the <see cref="ReportFormats"/> and <see cref="ExportResultsUsingFolders"/> arguments.
        /// </summary>
        JUnitStyleHtml,
        /// <summary>
        /// Generates XML files with report data. See Data Export For Automation.
        /// </summary>
        DataExport,
        /// <summary>
        /// Generates Allure results.Use the Allure framework to generate an actual report.See Allure Report.
        /// </summary>
        Allure
    }
}
