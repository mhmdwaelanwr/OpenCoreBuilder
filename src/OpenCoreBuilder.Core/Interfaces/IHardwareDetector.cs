using System.Threading.Tasks;
using OpenCoreBuilder.Core.Models;

namespace OpenCoreBuilder.Core.Interfaces;

public interface IHardwareDetector
{
    Task<HardwareProfile> DetectHardwareAsync();
}
