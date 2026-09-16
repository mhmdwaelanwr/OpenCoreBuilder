using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using OpenCoreBuilder.Core.Interfaces;
using OpenCoreBuilder.Core.Models;

namespace OpenCoreBuilder.Infrastructure.Services;

public class SettingsService : ISettingsService
{
    private readonly string _settingsPath;
    public AppSettings CurrentSettings { get; private set; } = new();

    public SettingsService()
    {
        var appData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        var appFolder = Path.Combine(appData, "OpenCoreBuilder");
        Directory.CreateDirectory(appFolder);
        _settingsPath = Path.Combine(appFolder, "settings.json");
    }

    public async Task LoadSettingsAsync()
    {
        if (File.Exists(_settingsPath))
        {
            try
            {
                var json = await File.ReadAllTextAsync(_settingsPath);
                var settings = JsonSerializer.Deserialize<AppSettings>(json);
                if (settings != null)
                {
                    CurrentSettings = settings;
                }
            }
            catch
            {
                // Ignore errors, use defaults
            }
        }
    }

    public async Task SaveSettingsAsync(AppSettings settings)
    {
        CurrentSettings = settings;
        var json = JsonSerializer.Serialize(settings, new JsonSerializerOptions { WriteIndented = true });
        await File.WriteAllTextAsync(_settingsPath, json);
    }
}
