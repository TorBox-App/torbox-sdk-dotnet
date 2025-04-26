namespace TorboxApi.Validation;

using FluentValidation;
using FluentValidation.Results;
using TorboxApi.Models;

public class GetStatsOkResponseValidator : AbstractValidator<GetStatsOkResponse?>
{
    public GetStatsOkResponseValidator() { }
}
