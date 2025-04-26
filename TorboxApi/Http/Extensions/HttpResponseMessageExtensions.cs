using TorboxApi.Http.Exceptions;

namespace TorboxApi.Http.Extensions;

public static class HttpResponseMessageExtensions
{
    public static HttpResponseMessage EnsureSuccessfulResponse(this HttpResponseMessage response)
    {
        if (!response.IsSuccessStatusCode)
        {
            throw new ApiException(response);
        }
        return response;
    }
}
