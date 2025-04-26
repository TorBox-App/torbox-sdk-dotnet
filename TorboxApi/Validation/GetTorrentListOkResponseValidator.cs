namespace TorboxApi.Validation;

using FluentValidation;
using FluentValidation.Results;
using TorboxApi.Models;

public class GetTorrentListOkResponseValidator : AbstractValidator<GetTorrentListOkResponse?>
{
    public GetTorrentListOkResponseValidator() { }
}
