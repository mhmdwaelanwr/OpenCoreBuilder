using OpenCoreBuilder.Core.Models;

namespace OpenCoreBuilder.Application.Services;

public interface ISessionContext
{
    HardwareProfile? CurrentProfile { get; set; }
    BuildPlan? CurrentPlan { get; set; }
}

public class SessionContext : ISessionContext
{
    public HardwareProfile? CurrentProfile { get; set; }
    public BuildPlan? CurrentPlan { get; set; }
}
