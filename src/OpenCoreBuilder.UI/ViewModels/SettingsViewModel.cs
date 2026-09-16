using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using OpenCoreBuilder.Core.Enums;
using OpenCoreBuilder.Core.Interfaces;
using OpenCoreBuilder.Core.Models;
using OpenCoreBuilder.UI.Services;

namespace OpenCoreBuilder.UI.ViewModels;

public partial class SettingsViewModel : ObservableObject
{
    private readonly ISettingsService _settingsService;
    private readonly IThemeService _themeService;

    [ObservableProperty]
    private AppSettings _settings;

    public SettingsViewModel(ISettingsService settingsService, IThemeService themeService)
    {
        _settingsService = settingsService;
        _themeService = themeService;
        _settings = _settingsService.CurrentSettings;
    }

    [RelayCommand]
    private async Task SaveSettings()
    {
        await _settingsService.SaveSettingsAsync(Settings);
        _themeService.SetTheme(Settings.Theme);
    }
}
