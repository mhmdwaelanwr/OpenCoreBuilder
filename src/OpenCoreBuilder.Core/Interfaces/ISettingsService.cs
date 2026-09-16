using System.Threading.Tasks;
using OpenCoreBuilder.Core.Models;

namespace OpenCoreBuilder.Core.Interfaces;

public interface ISettingsService
{
    AppSettings CurrentSettings { get; }
    Task LoadSettingsAsync();
    Task SaveSettingsAsync(AppSettings settings);
}
