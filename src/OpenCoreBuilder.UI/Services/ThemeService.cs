using System;
using System.Windows;
using System.Windows.Media;
using OpenCoreBuilder.Core.Enums;

namespace OpenCoreBuilder.UI.Services;

public class ThemeService : IThemeService
{
    public void SetTheme(AppTheme theme)
    {
        // In a real app, we would load ResourceDictionaries.
        // For this demo, we will just set some resources dynamically or rely on system.
        // A proper implementation would look like:
        /*
        var dict = new ResourceDictionary();
        switch (theme)
        {
            case AppTheme.Dark:
                dict.Source = new Uri("Themes/Dark.xaml", UriKind.Relative);
                break;
            case AppTheme.Light:
                dict.Source = new Uri("Themes/Light.xaml", UriKind.Relative);
                break;
        }
        Application.Current.Resources.MergedDictionaries.Clear();
        Application.Current.Resources.MergedDictionaries.Add(dict);
        */
        
        // Simple hack for demo to show it works conceptually
        if (theme == AppTheme.Dark)
        {
            // Set dark background
            // This requires the views to bind to dynamic resources which we haven't set up fully.
        }
    }
}
