using System;
using CommunityToolkit.Mvvm.ComponentModel;

namespace OpenCoreBuilder.UI.Services;

public interface INavigationService
{
    ObservableObject CurrentView { get; }
    void NavigateTo<T>() where T : ObservableObject;
}
