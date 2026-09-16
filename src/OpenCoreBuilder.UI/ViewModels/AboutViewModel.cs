using System.Collections.Generic;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace OpenCoreBuilder.UI.ViewModels;

public class SocialLink
{
    public string Platform { get; set; }
    public string Url { get; set; }
    public string Username { get; set; }
}

public partial class AboutViewModel : ObservableObject
{
    public string AuthorName => "mhmdwaelanwr";

    public List<SocialLink> SocialLinks { get; } = new()
    {
        new SocialLink { Platform = "TikTok", Url = "https://tiktok.com/@mhmdwaelanwr", Username = "mhmdwaelanwr" },
        new SocialLink { Platform = "Threads", Url = "https://threads.net/@mhmdwaelanwr", Username = "mhmdwaelanwr" },
        new SocialLink { Platform = "Discord", Url = "#", Username = "mhmdwaelanwr" },
        new SocialLink { Platform = "YouTube", Url = "https://youtube.com/@mhmdwaelanwr", Username = "mhmdwaelanwr" },
        new SocialLink { Platform = "Facebook", Url = "https://facebook.com/mhmdwaelanwr", Username = "mhmdwaelanwr" },
        new SocialLink { Platform = "Twitch", Url = "https://twitch.tv/mhmdwaelanwr", Username = "mhmdwaelanwr" },
        new SocialLink { Platform = "Instagram", Url = "https://instagram.com/mhmdwaelanwr", Username = "mhmdwaelanwr" },
        new SocialLink { Platform = "LinkedIn", Url = "https://linkedin.com/in/mhmdwaelanwr", Username = "mhmdwaelanwr" },
        new SocialLink { Platform = "Telegram", Url = "https://t.me/mhmdwaelanwr", Username = "mhmdwaelanwr" },
        new SocialLink { Platform = "GitLab", Url = "https://gitlab.com/mhmdwaelanwr", Username = "mhmdwaelanwr" },
        new SocialLink { Platform = "Gitea", Url = "#", Username = "mhmdwaelanwr" },
        new SocialLink { Platform = "Google Dev", Url = "#", Username = "mhmdwaelanwr" },
        new SocialLink { Platform = "Reddit", Url = "https://reddit.com/user/mhmdwaelanwr", Username = "mhmdwaelanwr" },
        new SocialLink { Platform = "NGL", Url = "#", Username = "mhmdwaelanwr" },
        new SocialLink { Platform = "Spotify", Url = "#", Username = "mhmdwaelanwr" },
        new SocialLink { Platform = "Snapchat", Url = "https://snapchat.com/add/mhmdwaelanwr", Username = "mhmdwaelanwr" },
    };

    [RelayCommand]
    private void OpenLink(string url)
    {
        if (url != "#")
        {
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = url,
                UseShellExecute = true
            });
        }
    }
}
