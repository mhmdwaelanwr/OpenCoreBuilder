using OpenCoreBuilder.Core.Models;

namespace OpenCoreBuilder.Core.Interfaces;

public interface IRule
{
    string Id { get; }
    string Description { get; }
    ValidationResult Validate(HardwareProfile profile);
    bool AppliesTo(HardwareProfile profile);
}
