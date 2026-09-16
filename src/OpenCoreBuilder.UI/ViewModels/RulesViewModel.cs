using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using OpenCoreBuilder.Application.Services;
using OpenCoreBuilder.Core.Interfaces;
using OpenCoreBuilder.Core.Models;

namespace OpenCoreBuilder.UI.ViewModels;

public partial class RulesViewModel : ObservableObject
{
    private readonly IRuleEngine _ruleEngine;
    private readonly ISessionContext _sessionContext;

    [ObservableProperty]
    private ObservableCollection<ValidationResult> _validationResults = new();

    public RulesViewModel(IRuleEngine ruleEngine, ISessionContext sessionContext)
    {
        _ruleEngine = ruleEngine;
        _sessionContext = sessionContext;
    }

    [RelayCommand]
    private void RunValidation()
    {
        if (_sessionContext.CurrentProfile == null)
        {
            ValidationResults.Clear();
            ValidationResults.Add(new ValidationResult { Severity = Core.Enums.ValidationSeverity.Error, Message = "No hardware profile loaded. Please go to Hardware tab." });
            return;
        }

        var results = _ruleEngine.Validate(_sessionContext.CurrentProfile);
        ValidationResults = new ObservableCollection<ValidationResult>(results);
    }
}
