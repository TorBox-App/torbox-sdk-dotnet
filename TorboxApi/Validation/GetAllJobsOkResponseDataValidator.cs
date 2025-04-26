namespace TorboxApi.Validation;

using FluentValidation;
using FluentValidation.Results;
using TorboxApi.Models;

public class GetAllJobsOkResponseDataValidator : AbstractValidator<GetAllJobsOkResponseData?>
{
    public GetAllJobsOkResponseDataValidator() { }
}
