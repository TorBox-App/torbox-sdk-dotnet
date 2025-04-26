namespace TorboxApi.Validation;

using FluentValidation;
using FluentValidation.Results;
using TorboxApi.Models;

public class GetNotificationFeedOkResponseDataValidator
    : AbstractValidator<GetNotificationFeedOkResponseData?>
{
    public GetNotificationFeedOkResponseDataValidator() { }
}
