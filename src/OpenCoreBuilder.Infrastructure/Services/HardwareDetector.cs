using System;
using System.Management;
using System.Threading.Tasks;
using OpenCoreBuilder.Core.Interfaces;
using OpenCoreBuilder.Core.Models;

namespace OpenCoreBuilder.Infrastructure.Services;

public class HardwareDetector : IHardwareDetector
{
    public async Task<HardwareProfile> DetectHardwareAsync()
    {
        return await Task.Run(() =>
        {
            var profile = new HardwareProfile();

            try
            {
                if (OperatingSystem.IsWindows())
                {
                    // CPU
                    using var cpuSearcher = new ManagementObjectSearcher("Select * from Win32_Processor");
                    foreach (var item in cpuSearcher.Get())
                    {
                        profile.CPUName = item["Name"]?.ToString() ?? "Unknown CPU";
                        // Simple heuristic for architecture
                        if (profile.CPUName.Contains("Intel")) profile.CPUArchitecture = "Intel";
                        else if (profile.CPUName.Contains("AMD")) profile.CPUArchitecture = "AMD";
                    }

                    // GPU
                    using var gpuSearcher = new ManagementObjectSearcher("Select * from Win32_VideoController");
                    foreach (var item in gpuSearcher.Get())
                    {
                        profile.GPUName = item["Name"]?.ToString() ?? "Unknown GPU";
                        break; // Just take the first one for now
                    }

                    // Motherboard
                    using var mbSearcher = new ManagementObjectSearcher("Select * from Win32_BaseBoard");
                    foreach (var item in mbSearcher.Get())
                    {
                        profile.MotherboardModel = $"{item["Manufacturer"]} {item["Product"]}";
                    }

                    // RAM
                    using var ramSearcher = new ManagementObjectSearcher("Select * from Win32_ComputerSystem");
                    foreach (var item in ramSearcher.Get())
                    {
                        long.TryParse(item["TotalPhysicalMemory"]?.ToString(), out long bytes);
                        profile.RAMSizeMB = bytes / 1024 / 1024;
                    }
                }
                else
                {
                    profile.CPUName = "Non-Windows Environment";
                }
            }
            catch (Exception ex)
            {
                profile.CPUName = $"Error detecting hardware: {ex.Message}";
            }

            return profile;
        });
    }
}
