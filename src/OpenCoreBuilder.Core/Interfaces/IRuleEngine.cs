using System.Collections.Generic;
using OpenCoreBuilder.Core.Models;

namespace OpenCoreBuilder.Core.Interfaces;

public interface IRuleEngine
{
    IEnumerable<ValidationResult> Validate(HardwareProfile profile);
    BuildPlan GeneratePlan(HardwareProfile profile);
}
