using System.Diagnostics;
using System.IO;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using OpenCoreBuilder.Core.Interfaces;
using OpenCoreBuilder.UI.Services;

namespace OpenCoreBuilder.UI.ViewModels;

public partial class MainViewModel : ObservableObject
{
    private readonly INavigationService _navigationService;
    private readonly ISettingsService _settingsService;

    public INavigationService NavigationService => _navigationService;

    public MainViewModel(INavigationService navigationService, ISettingsService settingsService)
    {
        _navigationService = navigationService;
        _settingsService = settingsService;

        NavigateToDashboardCommand = new RelayCommand(() => _navigationService.NavigateTo<DashboardViewModel>());
        NavigateToHardwareCommand = new RelayCommand(() => _navigationService.NavigateTo<HardwareViewModel>());
        NavigateToRulesCommand = new RelayCommand(() => _navigationService.NavigateTo<RulesViewModel>());
        NavigateToBuildCommand = new RelayCommand(() => _navigationService.NavigateTo<BuildViewModel>());
        NavigateToSettingsCommand = new RelayCommand(() => _navigationService.NavigateTo<SettingsViewModel>());
        NavigateToAboutCommand = new RelayCommand(() => _navigationService.NavigateTo<AboutViewModel>());

        OpenRepoCommand = new RelayCommand(() => OpenUrl("https://github.com/mhmdwaelanwr/OpenCoreBuilder")); // Example URL
        LaunchProperTreeCommand = new RelayCommand(LaunchProperTree);
    }

    public IRelayCommand NavigateToDashboardCommand { get; }
    public IRelayCommand NavigateToHardwareCommand { get; }
    public IRelayCommand NavigateToRulesCommand { get; }
    public IRelayCommand NavigateToBuildCommand { get; }
    public IRelayCommand NavigateToSettingsCommand { get; }
    public IRelayCommand NavigateToAboutCommand { get; }

    public IRelayCommand OpenRepoCommand { get; }
    public IRelayCommand LaunchProperTreeCommand { get; }

    private void LaunchProperTree()
    {
        var path = _settingsService.CurrentSettings.ProperTreePath;
        if (!string.IsNullOrEmpty(path) && File.Exists(path))
        {
            Process.Start(new ProcessStartInfo { FileName = path, UseShellExecute = true });
        }
        else
        {
            // Show error or navigate to settings
            _navigationService.NavigateTo<SettingsViewModel>();
        }
    }

    private void OpenUrl(string url)
    {
        Process.Start(new ProcessStartInfo { FileName = url, UseShellExecute = true });
    }
}
