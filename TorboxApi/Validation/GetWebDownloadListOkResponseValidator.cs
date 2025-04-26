namespace TorboxApi.Validation;

using FluentValidation;
using FluentValidation.Results;
using TorboxApi.Models;

public class GetWebDownloadListOkResponseValidator
    : AbstractValidator<GetWebDownloadListOkResponse?>
{
    public GetWebDownloadListOkResponseValidator() { }
}
