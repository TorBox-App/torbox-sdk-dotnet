namespace TorboxApi.Validation;

using FluentValidation;
using FluentValidation.Results;
using TorboxApi.Models;

public class GetAllJobsOkResponseValidator : AbstractValidator<GetAllJobsOkResponse?>
{
    public GetAllJobsOkResponseValidator() { }
}
