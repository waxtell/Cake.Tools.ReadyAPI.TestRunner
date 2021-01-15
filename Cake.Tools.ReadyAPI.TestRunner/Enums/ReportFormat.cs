using System;

// ReSharper disable once CheckNamespace
namespace Cake.Tools.ReadyAPI.TestRunner
{
    [Flags]
    public enum ReportFormat
    {
        PDF = 1, 
        XLS = 2, 
        HTML = 4, 
        RTF = 8, 
        CSV = 16, 
        TXT = 32,
        XML = 64
    }
}
