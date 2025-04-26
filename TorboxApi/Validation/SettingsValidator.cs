namespace TorboxApi.Validation;

using FluentValidation;
using FluentValidation.Results;
using TorboxApi.Models;

public class SettingsValidator : AbstractValidator<Settings?>
{
    public SettingsValidator() { }
}
