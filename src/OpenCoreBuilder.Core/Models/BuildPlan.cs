using System.Collections.Generic;

namespace OpenCoreBuilder.Core.Models;

public class BuildPlan
{
    public HardwareProfile TargetHardware { get; set; } = new();
    public List<string> KextsToDownload { get; set; } = new();
    public List<string> DriversToDownload { get; set; } = new();
    public List<string> ACPIPatches { get; set; } = new();
    public Dictionary<string, object> ConfigPlistOverrides { get; set; } = new();
    public List<Explanation> Explanations { get; set; } = new();
}
