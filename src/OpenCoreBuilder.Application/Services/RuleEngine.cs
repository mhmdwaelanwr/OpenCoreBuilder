using System.Collections.Generic;
using System.Linq;
using OpenCoreBuilder.Core.Interfaces;
using OpenCoreBuilder.Core.Models;

namespace OpenCoreBuilder.Application.Services;

public class RuleEngine : IRuleEngine
{
    private readonly IEnumerable<IRule> _rules;

    public RuleEngine(IEnumerable<IRule> rules)
    {
        _rules = rules;
    }

    public IEnumerable<ValidationResult> Validate(HardwareProfile profile)
    {
        var results = new List<ValidationResult>();

        foreach (var rule in _rules)
        {
            if (rule.AppliesTo(profile))
            {
                results.Add(rule.Validate(profile));
            }
        }

        return results;
    }

    public BuildPlan GeneratePlan(HardwareProfile profile)
    {
        // In a real app, this would be much more complex, using the rules to determine kexts/drivers
        var plan = new BuildPlan
        {
            TargetHardware = profile
        };

        // Example logic
        plan.KextsToDownload.Add("Lilu.kext");
        plan.KextsToDownload.Add("VirtualSMC.kext");

        if (profile.AudioCodec != "None")
        {
            plan.KextsToDownload.Add("AppleALC.kext");
            plan.Explanations.Add(new Explanation
            {
                Title = "Audio Support",
                Description = "AppleALC added for audio support.",
                TechnicalDetails = $"Detected Codec: {profile.AudioCodec}"
            });
        }

        if (profile.EthernetController.Contains("Realtek"))
        {
            plan.KextsToDownload.Add("RealtekRTL8111.kext");
        }

        return plan;
    }
}
