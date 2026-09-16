using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using OpenCoreBuilder.Application.Services;
using OpenCoreBuilder.Core.Interfaces;
using OpenCoreBuilder.Core.Models;

namespace OpenCoreBuilder.UI.ViewModels;

public partial class BuildViewModel : ObservableObject
{
    private readonly IBuildService _buildService;
    private readonly IRuleEngine _ruleEngine;
    private readonly ISessionContext _sessionContext;
    private readonly ISettingsService _settingsService;

    [ObservableProperty]
    private string _statusMessage = "Ready to build.";

    [ObservableProperty]
    private bool _isBuilding;

    public BuildViewModel(IBuildService buildService, IRuleEngine ruleEngine, ISessionContext sessionContext, ISettingsService settingsService)
    {
        _buildService = buildService;
        _ruleEngine = ruleEngine;
        _sessionContext = sessionContext;
        _settingsService = settingsService;
    }

    [RelayCommand]
    private async Task BuildEFI()
    {
        if (_sessionContext.CurrentProfile == null)
        {
            StatusMessage = "Error: No hardware profile loaded.";
            return;
        }

        IsBuilding = true;
        StatusMessage = "Generating Build Plan...";

        try
        {
            var plan = _ruleEngine.GeneratePlan(_sessionContext.CurrentProfile);
            _sessionContext.CurrentPlan = plan;

            StatusMessage = "Building EFI...";

            // Use default output folder from settings or a default
            var outputDir = !string.IsNullOrEmpty(_settingsService.CurrentSettings.DefaultOutputFolder)
                ? _settingsService.CurrentSettings.DefaultOutputFolder
                : System.IO.Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop), "OpenCoreBuild");

            await _buildService.BuildAsync(plan, outputDir);

            StatusMessage = $"Build Complete! Output at: {outputDir}";
        }
        catch (System.Exception ex)
        {
            StatusMessage = $"Build Failed: {ex.Message}";
        }
        finally
        {
            IsBuilding = false;
        }
    }
}
