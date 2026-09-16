using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using OpenCoreBuilder.Application.Services;
using OpenCoreBuilder.Core.Interfaces;
using OpenCoreBuilder.Core.Rules;
using OpenCoreBuilder.Infrastructure.Services;
using OpenCoreBuilder.UI.Services;
using OpenCoreBuilder.UI.ViewModels;

namespace OpenCoreBuilder.UI;

public partial class App : System.Windows.Application
{
    public new static App Current => (App)System.Windows.Application.Current;
    public IServiceProvider Services { get; }

    public App()
    {
        Services = ConfigureServices();
    }

    private static IServiceProvider ConfigureServices()
    {
        var services = new ServiceCollection();

        // Core & Application Services
        services.AddSingleton<ISessionContext, SessionContext>();
        services.AddSingleton<IHardwareDetector, HardwareDetector>();
        services.AddSingleton<ISettingsService, SettingsService>();
        services.AddSingleton<IBuildService, BuildService>();

        // Rules
        services.AddSingleton<IRule, CPUSupportRule>();
        services.AddSingleton<IRuleEngine, RuleEngine>();

        // UI Services
        services.AddSingleton<INavigationService, NavigationService>();
        services.AddSingleton<IThemeService, ThemeService>();

        // ViewModels
        services.AddSingleton<MainViewModel>();
        services.AddTransient<DashboardViewModel>();
        services.AddTransient<HardwareViewModel>();
        services.AddTransient<RulesViewModel>();
        services.AddTransient<BuildViewModel>();
        services.AddTransient<SettingsViewModel>();
        services.AddTransient<AboutViewModel>();

        // Main Window
        services.AddSingleton<MainWindow>();

        return services.BuildServiceProvider();
    }

    private void Application_Startup(object sender, StartupEventArgs e)
    {
        var mainWindow = Services.GetRequiredService<MainWindow>();
        mainWindow.Show();
    }
}

