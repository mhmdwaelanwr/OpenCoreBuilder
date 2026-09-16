using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using OpenCoreBuilder.Application.Services;
using OpenCoreBuilder.Core.Interfaces;
using OpenCoreBuilder.Core.Models;

namespace OpenCoreBuilder.UI.ViewModels;

public partial class HardwareViewModel : ObservableObject
{
    private readonly IHardwareDetector _hardwareDetector;
    private readonly ISessionContext _sessionContext;

    [ObservableProperty]
    private HardwareProfile _profile;

    [ObservableProperty]
    private bool _isLoading;

    public HardwareViewModel(IHardwareDetector hardwareDetector, ISessionContext sessionContext)
    {
        _hardwareDetector = hardwareDetector;
        _sessionContext = sessionContext;
        _profile = _sessionContext.CurrentProfile ?? new HardwareProfile();
    }

    [RelayCommand]
    private async Task DetectHardware()
    {
        IsLoading = true;
        try
        {
            Profile = await _hardwareDetector.DetectHardwareAsync();
            _sessionContext.CurrentProfile = Profile;
        }
        finally
        {
            IsLoading = false;
        }
    }
}
