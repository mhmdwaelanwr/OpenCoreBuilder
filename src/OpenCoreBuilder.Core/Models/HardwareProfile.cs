using System.Collections.Generic;

namespace OpenCoreBuilder.Core.Models;

public class HardwareProfile
{
    public string CPUName { get; set; } = string.Empty;
    public string CPUArchitecture { get; set; } = string.Empty; // e.g., "Comet Lake"
    public string GPUName { get; set; } = string.Empty;
    public string MotherboardModel { get; set; } = string.Empty;
    public string AudioCodec { get; set; } = string.Empty;
    public string EthernetController { get; set; } = string.Empty;
    public string WiFiController { get; set; } = string.Empty;
    public long RAMSizeMB { get; set; }

    // Additional raw data if needed
    public Dictionary<string, string> RawProperties { get; set; } = new();
}
