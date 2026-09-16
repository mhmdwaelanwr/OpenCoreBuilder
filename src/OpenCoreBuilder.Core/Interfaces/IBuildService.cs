using System.Threading.Tasks;
using OpenCoreBuilder.Core.Models;

namespace OpenCoreBuilder.Core.Interfaces;

public interface IBuildService
{
    Task BuildAsync(BuildPlan plan, string outputDirectory);
}
