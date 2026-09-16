using OpenCoreBuilder.Core.Enums;

namespace OpenCoreBuilder.Core.Models;

public class ValidationResult
{
    public bool IsValid => Severity != ValidationSeverity.Error && Severity != ValidationSeverity.Critical;
    public ValidationSeverity Severity { get; set; }
    public string Message { get; set; } = string.Empty;
    public string Recommendation { get; set; } = string.Empty;
    public string RuleId { get; set; } = string.Empty;
}
