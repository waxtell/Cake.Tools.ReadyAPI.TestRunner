using System;
using System.Collections.Generic;
using System.Linq;
using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.Tools.ReadyAPI.TestRunner
{
    internal sealed class TestRunnerRunner : Tool<TestRunnerSettings>
    {
        public TestRunnerRunner(IFileSystem fileSystem, ICakeEnvironment environment, IProcessRunner processRunner, IToolLocator tools)
            : base(fileSystem, environment, processRunner, tools)
        {
        }

        public int RunFunctionalTests(string projectFile, TestRunnerSettings settings)
        {
            if (string.IsNullOrWhiteSpace(projectFile))
            {
                throw new ArgumentNullException(nameof(projectFile));
            }

            if (settings == null)
            {
                throw new ArgumentNullException(nameof(settings));
            }

            using (var p = RunProcess(settings, GetArguments(projectFile, settings)))
            {
                p.WaitForExit();

                return p.GetExitCode();
            }
        }

        protected override IEnumerable<string> GetToolExecutableNames()
        {
            return new[] { "testrunner", "testrunner.bat" };
        }

        protected override string GetToolName()
        {
            return "testrunner";
        }

        internal static ProcessArgumentBuilder GetArguments(string projectFile, TestRunnerSettings settings)
        {
            var arguments = new ProcessArgumentBuilder();

            arguments.Append(projectFile);

            if (settings.ExportResults)
            {
                arguments.Append("-a");
            }
            
            if (settings.ExportResultsUsingFolders)
            {
                arguments.Append("-A");
            }

            if (!string.IsNullOrWhiteSpace(settings.TestCase))
            {
                arguments.Append($"-c{settings.TestCase}");
            }

            if (!string.IsNullOrWhiteSpace(settings.Domain))
            {
                arguments.Append($"-d{settings.Domain}");
            }

            if (settings.SystemProperties != null)
            {
                foreach (var arg in settings.SystemProperties)
                {
                    arguments.Append($"-D{arg.Key}=\"{arg.Value}\"");
                }
            }

            if (!string.IsNullOrWhiteSpace(settings.EndPoint))
            {
                arguments.Append($"-e{settings.EndPoint}");
            }

            if (!string.IsNullOrWhiteSpace(settings.Environment))
            {
                arguments.Append($"-E{settings.Environment}");
            }

            if (!string.IsNullOrWhiteSpace(settings.OutputFolder))
            {
                arguments.Append($"-f{settings.OutputFolder}");
            }

            if (settings.ReportFormats != null)
            {
                arguments.Append($"-F{string.Join(",", settings.ReportFormats)}");
            }

            if (settings.CreateCoverageReport)
            {
                arguments.Append("-g");
            }

            if (settings.GlobalProperties != null)
            {
                foreach (var arg in settings.GlobalProperties)
                {
                    arguments.Append($"-G{arg.Key}=\"{arg.Value}\"");
                }
            }

            if (!string.IsNullOrWhiteSpace(settings.Host))
            {
                arguments.Append($"-h{settings.Host}");
            }

            if (settings.Headers != null)
            {
                foreach (var header in settings.Headers)
                {
                    arguments.Append($"-H{header.Key}={header.Value}");
                }
            }

            if (settings.EnableUIComponents)
            {
                arguments.Append("-i");
            }

            if (settings.IgnoreErrors)
            {
                arguments.Append("-I");
            }

            if (settings.CreateJUnitCompatibleReports)
            {
                arguments.Append("-j");
            }

            if (settings.IncludeTestProperties)
            {
                arguments.Append("-J");
            }

            if (settings.BriefResults)
            {
                arguments.Append("-M");
            }

            if (settings.OpenReportsInBrowser)
            {
                arguments.Append("-o");
            }

            if (settings.SuppressUsageStatistics)
            {
                arguments.Append("-O");
            }

            if (settings.ProjectProperties != null)
            {
                foreach (var arg in settings.ProjectProperties)
                {
                    arguments.Append($"-P{arg.Key}=\"{arg.Value}\"");
                }
            }

            if (!string.IsNullOrWhiteSpace(settings.Password))
            {
                arguments.Append($"-p{settings.Password}");
            }

            if (settings.PrintSummaryReport)
            {
                arguments.Append("-r");
            }
            
            if (!string.IsNullOrWhiteSpace(settings.Report))
            {
                arguments.Append($"\"-R{settings.Report}\"");
            }

            if (!string.IsNullOrWhiteSpace(settings.TestSuite))
            {
                arguments.Append($"-s{settings.TestSuite}");
            }

            if (settings.SaveProject)
            {
                arguments.Append("-S");
            }

            if (!string.IsNullOrWhiteSpace(settings.SettingsFile))
            {
                arguments.Append($"-t{settings.SettingsFile}");
            }

            if (!string.IsNullOrWhiteSpace(settings.TestSuiteTags))
            {
                arguments.Append($"\"-TTestSuite {settings.TestSuiteTags}\"");
            }

            if (!string.IsNullOrWhiteSpace(settings.TestCaseTags))
            {
                arguments.Append($"\"-TTestCase {settings.TestCaseTags}\"");
            }

            if (!string.IsNullOrWhiteSpace(settings.Username))
            {
                arguments.Append($"-u{settings.Username}");
            }

            if (!string.IsNullOrWhiteSpace(settings.Password))
            {
                arguments.Append($"-v{settings.Password}");
            }

            if (!string.IsNullOrWhiteSpace(settings.PasswordType))
            {
                arguments.Append($"-w{settings.PasswordType}");
            }

            if (!string.IsNullOrWhiteSpace(settings.SlackAccessToken) && settings.SlackChannels != null && settings.SlackChannels.Any())
            {
                arguments.Append($"-W{settings.SlackAccessToken}/{string.Join(",", settings.SlackChannels)}");
            }

            if (!string.IsNullOrWhiteSpace(settings.ProjectPassword))
            {
                arguments.Append($"-x{settings.ProjectPassword}");
            }

            return arguments;
        }
    }
}
