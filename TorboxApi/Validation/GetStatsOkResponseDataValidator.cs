namespace TorboxApi.Validation;

using FluentValidation;
using FluentValidation.Results;
using TorboxApi.Models;

public class GetStatsOkResponseDataValidator : AbstractValidator<GetStatsOkResponseData?>
{
    public GetStatsOkResponseDataValidator() { }
}
