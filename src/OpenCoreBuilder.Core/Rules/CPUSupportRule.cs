using OpenCoreBuilder.Core.Enums;
using OpenCoreBuilder.Core.Interfaces;
using OpenCoreBuilder.Core.Models;

namespace OpenCoreBuilder.Core.Rules;

public class CPUSupportRule : IRule
{
    public string Id => "CPU-001";
    public string Description => "Checks if the CPU architecture is supported.";

    public bool AppliesTo(HardwareProfile profile)
    {
        return !string.IsNullOrEmpty(profile.CPUArchitecture);
    }

    public ValidationResult Validate(HardwareProfile profile)
    {
        // Simplified logic for example
        if (profile.CPUArchitecture.Contains("Pentium") || profile.CPUArchitecture.Contains("Celeron"))
        {
            return new ValidationResult
            {
                Severity = ValidationSeverity.Warning,
                Message = "Pentium/Celeron CPUs may require FakeCPUID.",
                Recommendation = "Use a supported Core i3/i5/i7/i9 if possible, or configure FakeCPUID.",
                RuleId = Id
            };
        }

        return new ValidationResult { Severity = ValidationSeverity.Info, Message = "CPU Architecture seems supported.", RuleId = Id };
    }
}
