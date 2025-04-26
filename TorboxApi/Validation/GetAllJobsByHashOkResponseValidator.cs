namespace TorboxApi.Validation;

using FluentValidation;
using FluentValidation.Results;
using TorboxApi.Models;

public class GetAllJobsByHashOkResponseValidator : AbstractValidator<GetAllJobsByHashOkResponse?>
{
    public GetAllJobsByHashOkResponseValidator() { }
}
