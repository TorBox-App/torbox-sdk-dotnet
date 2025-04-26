namespace TorboxApi.Validation;

using FluentValidation;
using FluentValidation.Results;
using TorboxApi.Models;

public class AddReferralToAccountOkResponseValidator
    : AbstractValidator<AddReferralToAccountOkResponse?>
{
    public AddReferralToAccountOkResponseValidator() { }
}
