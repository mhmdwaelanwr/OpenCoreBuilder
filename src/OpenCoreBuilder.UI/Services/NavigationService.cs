using System;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Extensions.DependencyInjection;

namespace OpenCoreBuilder.UI.Services;

public class NavigationService : ObservableObject, INavigationService
{
    private readonly IServiceProvider _serviceProvider;
    private ObservableObject _currentView;

    public ObservableObject CurrentView
    {
        get => _currentView;
        private set => SetProperty(ref _currentView, value);
    }

    public NavigationService(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public void NavigateTo<T>() where T : ObservableObject
    {
        var viewModel = _serviceProvider.GetRequiredService<T>();
        CurrentView = viewModel;
    }
}
