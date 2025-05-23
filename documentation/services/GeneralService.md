# GeneralService

A list of all methods in the `GeneralService` service. Click on the method name to view detailed information about that method.

| Methods                                                 | Description                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                            |
| :------------------------------------------------------ | :----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| [GetUpStatusAsync](#getupstatusasync)                   | ### Overview Simply gets if the TorBox API is available for use or not. Also might include information about downtimes. ### Authorization None needed.                                                                                                                                                                                                                                                                                                                                                                                                 |
| [GetStatsAsync](#getstatsasync)                         | ### Overview Simply gets general stats about the TorBox service. ### Authorization None needed.                                                                                                                                                                                                                                                                                                                                                                                                                                                        |
| [GetChangelogsRssFeedAsync](#getchangelogsrssfeedasync) | ### Overview Gets most recent 100 changelogs from [https://feedback.torbox.app/changelog.](https://feedback.torbox.app/changelog.) This is useful for people who want updates on the TorBox changelog. Includes all the necessary items to make this compatible with RSS feed viewers for notifications, and proper HTML viewing. ### Authorization None needed.                                                                                                                                                                                       |
| [GetChangelogsJsonAsync](#getchangelogsjsonasync)       | ### Overview Gets most recent 100 changelogs from [https://feedback.torbox.app/changelog.](https://feedback.torbox.app/changelog.) This is useful for developers who want to integrate the changelog into their apps for their users to see. Includes content in HTML and markdown for developers to easily render the text in a fancy yet simple way. ### Authorization None needed.                                                                                                                                                                  |
| [GetSpeedtestFilesAsync](#getspeedtestfilesasync)       | ### Overview Gets CDN speedtest files. This can be used for speedtesting TorBox for users or other usages, such as checking download speeds for verification. Provides all necessary data such as region, server name, and even coordinates. Uses the requesting IP to determine if the server is the closest to the user. You also have the ability to choose between long tests or short tests via the "test_length" parameter. You may also force the region selection by passing the "region" as a specific region. ### Authorization None needed. |

## GetUpStatusAsync

### Overview Simply gets if the TorBox API is available for use or not. Also might include information about downtimes. ### Authorization None needed.

- HTTP Method: `GET`
- Endpoint: `/`

**Return Type**

`GetUpStatusOkResponse`

**Example Usage Code Snippet**

```csharp
using TorboxApi;
using TorboxApi.Config;
using Environment = TorboxApi.Http.Environment;

var config = new TorboxApiConfig{
    Environment = Environment.Default
};

var client = new TorboxApiClient(config);

var response = await client.General.GetUpStatusAsync();

Console.WriteLine(response);
```

## GetStatsAsync

### Overview Simply gets general stats about the TorBox service. ### Authorization None needed.

- HTTP Method: `GET`
- Endpoint: `/{api_version}/api/stats`

**Parameters**

| Name       | Type   | Required | Description |
| :--------- | :----- | :------- | :---------- |
| apiVersion | string | ✅       |             |

**Return Type**

`GetStatsOkResponse`

**Example Usage Code Snippet**

```csharp
using TorboxApi;
using TorboxApi.Config;
using Environment = TorboxApi.Http.Environment;

var config = new TorboxApiConfig{
    Environment = Environment.Default
};

var client = new TorboxApiClient(config);

var response = await client.General.GetStatsAsync("api_version");

Console.WriteLine(response);
```

## GetChangelogsRssFeedAsync

### Overview Gets most recent 100 changelogs from [https://feedback.torbox.app/changelog.](https://feedback.torbox.app/changelog.) This is useful for people who want updates on the TorBox changelog. Includes all the necessary items to make this compatible with RSS feed viewers for notifications, and proper HTML viewing. ### Authorization None needed.

- HTTP Method: `GET`
- Endpoint: `/{api_version}/api/changelogs/rss`

**Parameters**

| Name       | Type   | Required | Description |
| :--------- | :----- | :------- | :---------- |
| apiVersion | string | ✅       |             |

**Return Type**

`object`

**Example Usage Code Snippet**

```csharp
using TorboxApi;
using TorboxApi.Config;
using Environment = TorboxApi.Http.Environment;

var config = new TorboxApiConfig{
    Environment = Environment.Default
};

var client = new TorboxApiClient(config);

var response = await client.General.GetChangelogsRssFeedAsync("api_version");

Console.WriteLine(response);
```

## GetChangelogsJsonAsync

### Overview Gets most recent 100 changelogs from [https://feedback.torbox.app/changelog.](https://feedback.torbox.app/changelog.) This is useful for developers who want to integrate the changelog into their apps for their users to see. Includes content in HTML and markdown for developers to easily render the text in a fancy yet simple way. ### Authorization None needed.

- HTTP Method: `GET`
- Endpoint: `/{api_version}/api/changelogs/json`

**Parameters**

| Name       | Type   | Required | Description |
| :--------- | :----- | :------- | :---------- |
| apiVersion | string | ✅       |             |

**Return Type**

`GetChangelogsJsonOkResponse`

**Example Usage Code Snippet**

```csharp
using TorboxApi;
using TorboxApi.Config;
using Environment = TorboxApi.Http.Environment;

var config = new TorboxApiConfig{
    Environment = Environment.Default
};

var client = new TorboxApiClient(config);

var response = await client.General.GetChangelogsJsonAsync("api_version");

Console.WriteLine(response);
```

## GetSpeedtestFilesAsync

### Overview Gets CDN speedtest files. This can be used for speedtesting TorBox for users or other usages, such as checking download speeds for verification. Provides all necessary data such as region, server name, and even coordinates. Uses the requesting IP to determine if the server is the closest to the user. You also have the ability to choose between long tests or short tests via the "test_length" parameter. You may also force the region selection by passing the "region" as a specific region. ### Authorization None needed.

- HTTP Method: `GET`
- Endpoint: `/{api_version}/api/speedtest`

**Parameters**

| Name       | Type   | Required | Description                                                                                                                                                                                        |
| :--------- | :----- | :------- | :------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| apiVersion | string | ✅       |                                                                                                                                                                                                    |
| testLength | string | ❌       | Determines the size of the file used for the speedtest. May be "long" or "short". Optional.                                                                                                        |
| region     | string | ❌       | Determines what cdns are returned. May be any region that TorBox is located in. To get this value, send a request without this value to determine all of the available regions that are available. |

**Example Usage Code Snippet**

```csharp
using TorboxApi;
using TorboxApi.Config;
using Environment = TorboxApi.Http.Environment;

var config = new TorboxApiConfig{
    Environment = Environment.Default
};

var client = new TorboxApiClient(config);

await client.General.GetSpeedtestFilesAsync("api_version", "string", "string");
```
