![Logo](https://raw.githubusercontent.com/TorBox-App/torbox-sdk-dotnet/main/assets/banner.png)

## Table of Contents

- [Setup \& Configuration](#setup--configuration)
  - [Supported Language Versions](#supported-language-versions)
  - [Installation](#installation)
  - [Authentication](#authentication)
    - [Access Token Authentication](#access-token-authentication)
      - [Setting the Access Token](#setting-the-access-token)
- [Sample Usage](#sample-usage)
  - [Services](#services)
  - [Models](#models)
  - [License](#license)

# Setup & Configuration

## Supported Language Versions

This SDK is compatible with the following versions: `C# >= .NET 6`

## Installation

To get started with the SDK, we recommend installing using `nuget`:

```bash
dotnet add package TorboxApi
```

## Authentication

### Access Token Authentication

The TorboxApi API uses an Access Token for authentication.

This token must be provided to authenticate your requests to the API.

#### Setting the Access Token

When you initialize the SDK, you can set the access token as follows:

```cs
using TorboxApi;
using TorboxApi.Config;

var config = new TorboxApiConfig()
{
	AccessToken = "YOUR_ACCESS_TOKEN"
};

var client = new TorboxApiClient(config);
```

If you need to set or update the access token after initializing the SDK, you can use:

```cs
client.SetAccessToken("YOUR_ACCESS_TOKEN")
```

# Sample Usage

Below is a comprehensive example demonstrating how to authenticate and call a simple endpoint:

```cs
using TorboxApi;
using TorboxApi.Config;
using Environment = TorboxApi.Http.Environment;

var config = new TorboxApiConfig
{
  Environment = Environment.Default,
  AccessToken = "YOUR_ACCESS_TOKEN"
};

var client = new TorboxApiClient(config);

var response = await client.General.GetUpStatusAsync();

Console.WriteLine(response);

```

## Services

The SDK provides various services to interact with the API.

<details> 
<summary>Below is a list of all available services with links to their detailed documentation:</summary>

| Name                                                                             |
| :------------------------------------------------------------------------------- |
| [TorrentsService](documentation/services/TorrentsService.md)                     |
| [UsenetService](documentation/services/UsenetService.md)                         |
| [WebDownloadsDebridService](documentation/services/WebDownloadsDebridService.md) |
| [GeneralService](documentation/services/GeneralService.md)                       |
| [NotificationsService](documentation/services/NotificationsService.md)           |
| [UserService](documentation/services/UserService.md)                             |
| [RssFeedsService](documentation/services/RssFeedsService.md)                     |
| [IntegrationsService](documentation/services/IntegrationsService.md)             |
| [QueuedService](documentation/services/QueuedService.md)                         |

</details>

## Models

The SDK includes several models that represent the data structures used in API requests and responses. These models help in organizing and managing the data efficiently.

<details> 
<summary>Below is a list of all available models with links to their detailed documentation:</summary>

| Name                                                                                                             | Description |
| :--------------------------------------------------------------------------------------------------------------- | :---------- |
| [CreateTorrentRequest](documentation/models/CreateTorrentRequest.md)                                             |             |
| [CreateTorrentOkResponse](documentation/models/CreateTorrentOkResponse.md)                                       |             |
| [ControlTorrentOkResponse](documentation/models/ControlTorrentOkResponse.md)                                     |             |
| [RequestDownloadLinkOkResponse](documentation/models/RequestDownloadLinkOkResponse.md)                           |             |
| [GetTorrentListOkResponse](documentation/models/GetTorrentListOkResponse.md)                                     |             |
| [GetTorrentCachedAvailabilityOkResponse](documentation/models/GetTorrentCachedAvailabilityOkResponse.md)         |             |
| [ExportTorrentDataOkResponse](documentation/models/ExportTorrentDataOkResponse.md)                               |             |
| [GetTorrentInfoOkResponse](documentation/models/GetTorrentInfoOkResponse.md)                                     |             |
| [GetTorrentInfo1Request](documentation/models/GetTorrentInfo1Request.md)                                         |             |
| [GetTorrentInfo1OkResponse](documentation/models/GetTorrentInfo1OkResponse.md)                                   |             |
| [CreateUsenetDownloadRequest](documentation/models/CreateUsenetDownloadRequest.md)                               |             |
| [CreateUsenetDownloadOkResponse](documentation/models/CreateUsenetDownloadOkResponse.md)                         |             |
| [GetUsenetListOkResponse](documentation/models/GetUsenetListOkResponse.md)                                       |             |
| [CreateWebDownloadRequest](documentation/models/CreateWebDownloadRequest.md)                                     |             |
| [CreateWebDownloadOkResponse](documentation/models/CreateWebDownloadOkResponse.md)                               |             |
| [GetWebDownloadListOkResponse](documentation/models/GetWebDownloadListOkResponse.md)                             |             |
| [GetHosterListOkResponse](documentation/models/GetHosterListOkResponse.md)                                       |             |
| [GetUpStatusOkResponse](documentation/models/GetUpStatusOkResponse.md)                                           |             |
| [GetStatsOkResponse](documentation/models/GetStatsOkResponse.md)                                                 |             |
| [GetChangelogsJsonOkResponse](documentation/models/GetChangelogsJsonOkResponse.md)                               |             |
| [GetNotificationFeedOkResponse](documentation/models/GetNotificationFeedOkResponse.md)                           |             |
| [GetUserDataOkResponse](documentation/models/GetUserDataOkResponse.md)                                           |             |
| [AddReferralToAccountOkResponse](documentation/models/AddReferralToAccountOkResponse.md)                         |             |
| [GetAllJobsOkResponse](documentation/models/GetAllJobsOkResponse.md)                                             |             |
| [GetAllJobsByHashOkResponse](documentation/models/GetAllJobsByHashOkResponse.md)                                 |             |
| [CreateTorrentOkResponseData](documentation/models/CreateTorrentOkResponseData.md)                               |             |
| [GetTorrentListOkResponseData](documentation/models/GetTorrentListOkResponseData.md)                             |             |
| [DataFiles1](documentation/models/DataFiles1.md)                                                                 |             |
| [GetTorrentCachedAvailabilityOkResponseData](documentation/models/GetTorrentCachedAvailabilityOkResponseData.md) |             |
| [GetTorrentInfoOkResponseData](documentation/models/GetTorrentInfoOkResponseData.md)                             |             |
| [DataFiles2](documentation/models/DataFiles2.md)                                                                 |             |
| [GetTorrentInfo1OkResponseData](documentation/models/GetTorrentInfo1OkResponseData.md)                           |             |
| [DataFiles3](documentation/models/DataFiles3.md)                                                                 |             |
| [CreateUsenetDownloadOkResponseData](documentation/models/CreateUsenetDownloadOkResponseData.md)                 |             |
| [GetUsenetListOkResponseData](documentation/models/GetUsenetListOkResponseData.md)                               |             |
| [DataFiles4](documentation/models/DataFiles4.md)                                                                 |             |
| [CreateWebDownloadOkResponseData](documentation/models/CreateWebDownloadOkResponseData.md)                       |             |
| [GetWebDownloadListOkResponseData](documentation/models/GetWebDownloadListOkResponseData.md)                     |             |
| [DataFiles5](documentation/models/DataFiles5.md)                                                                 |             |
| [GetHosterListOkResponseData](documentation/models/GetHosterListOkResponseData.md)                               |             |
| [GetStatsOkResponseData](documentation/models/GetStatsOkResponseData.md)                                         |             |
| [GetChangelogsJsonOkResponseData](documentation/models/GetChangelogsJsonOkResponseData.md)                       |             |
| [GetNotificationFeedOkResponseData](documentation/models/GetNotificationFeedOkResponseData.md)                   |             |
| [GetUserDataOkResponseData](documentation/models/GetUserDataOkResponseData.md)                                   |             |
| [Settings](documentation/models/Settings.md)                                                                     |             |
| [GetAllJobsOkResponseData](documentation/models/GetAllJobsOkResponseData.md)                                     |             |
| [GetAllJobsByHashOkResponseData](documentation/models/GetAllJobsByHashOkResponseData.md)                         |             |

</details>

## License

This SDK is licensed under the MIT License.

See the [LICENSE](LICENSE) file for more details.
