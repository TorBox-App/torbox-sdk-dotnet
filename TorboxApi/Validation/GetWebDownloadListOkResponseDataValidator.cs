namespace TorboxApi.Validation;

using FluentValidation;
using FluentValidation.Results;
using TorboxApi.Models;

public class GetWebDownloadListOkResponseDataValidator
    : AbstractValidator<GetWebDownloadListOkResponseData?>
{
    public GetWebDownloadListOkResponseDataValidator() { }
}
