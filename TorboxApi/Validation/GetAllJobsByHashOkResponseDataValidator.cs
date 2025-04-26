namespace TorboxApi.Validation;

using FluentValidation;
using FluentValidation.Results;
using TorboxApi.Models;

public class GetAllJobsByHashOkResponseDataValidator
    : AbstractValidator<GetAllJobsByHashOkResponseData?>
{
    public GetAllJobsByHashOkResponseDataValidator() { }
}
