# Cake.Tools.ReadyAPI.TestRunner

A Cake AddIn that extends Cake with the [SmartBear ReadyAPI TestRunner](https://support.smartbear.com/readyapi/docs/functional/running/automating/cli.html) command line tool.

![Publish to nuget](https://github.com/waxtell/Cake.Tools.ReadyAPI.TestRunner/workflows/Publish%20to%20nuget/badge.svg)
![Build](https://github.com/waxtell/Cake.Tools.ReadyAPI.TestRunner/workflows/Build/badge.svg)

## Including addin
First, add the extension in the usual way:
```c#
#addin "Cake.Tools.ReadyAPI.TestRunner"
```
## Usage

```csharp
#addin "Cake.Tools.ReadyAPI.TestRunner"

...

Task("FunctionalTest")
    .Does
    (
        () =>
        {
            var result = LaunchTestRunner
            (
                "demo-readyapi-project.xml",
                new TestRunnerSettings()
                {
                    PrintSummaryReport = true,
                    ...
                    SuppressUsageStatistics = true
                }
            );

            if(result != 0)
            {
                throw new Exception("One or more functional tests failed!");
            }
        }
    );
```
The extension expects TestRunner.bat to be available in the system path, but you may explicitly set the tool location as such

```csharp
Setup(context => {
    context.Tools.RegisterFile("C:/Program Files/SmartBear/ReadyAPI-3.5.1/bin/testrunner.bat");
});
```
