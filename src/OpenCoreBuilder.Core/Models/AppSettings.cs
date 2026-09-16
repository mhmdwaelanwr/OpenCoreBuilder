using OpenCoreBuilder.Core.Enums;

namespace OpenCoreBuilder.Core.Models;

public class AppSettings
{
    public AppTheme Theme { get; set; } = AppTheme.System;
    public TargetOS DefaultTargetOS { get; set; } = TargetOS.Sonoma;
    public string DefaultOutputFolder { get; set; } = string.Empty;
    public bool StrictValidation { get; set; } = false;
    public string ProperTreePath { get; set; } = string.Empty;
}
