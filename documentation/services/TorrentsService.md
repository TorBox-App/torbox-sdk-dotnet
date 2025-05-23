# TorrentsService

A list of all methods in the `TorrentsService` service. Click on the method name to view detailed information about that method.

| Methods                                                                 | Description                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                             |
| :---------------------------------------------------------------------- | :---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| [CreateTorrentAsync](#createtorrentasync)                               | ### Overview Creates a torrent under your account. Simply send **either** a magnet link, or a torrent file. Once they have been checked, they will begin downloading assuming your account has available active download slots, and they aren't too large. ### Authorization Requires an API key using the Authorization Bearer Header.                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                 |
| [ControlTorrentAsync](#controltorrentasync)                             | ### Overview Controls a torrent. By sending the torrent's ID and the type of operation you want to perform, it will send that request to the torrent client. Operations are either: - **Reannounce** `reannounces the torrent to get new peers` - **Delete** `deletes the torrent from the client and your account permanently` - **Resume** `resumes a paused torrent` ### Authorization Requires an API key using the Authorization Bearer Header.                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                    |
| [RequestDownloadLinkAsync](#requestdownloadlinkasync)                   | ### Overview Requests the download link from the server. Because downloads are metered, TorBox cannot afford to allow free access to the links directly. This endpoint opens the link for 3 hours for downloads. Once a download is started, the user has nearly unlilimited time to download the file. The 1 hour time limit is simply for starting downloads. This prevents long term link sharing. ### Permalinks Instead of generating many CDN urls by requesting this endpoint, you can instead create a permalink such as: `https://api.torbox.app/v1/api/torrents/requestdl?token=APIKEY&torrent_id=NUMBER&file_id=NUMBER&redirect=true` and when a user clicks on it, it will automatically redirect them to the CDN link. This saves requests and doesn't abuse the API. Use this method rather than saving CDN links as they are not permanent. To invalidate these permalinks, simply reset your API token or delete the item from your dashboard. ### Authorization Requires an API key as a parameter for the `token` parameter.                                                                          |
| [GetTorrentListAsync](#gettorrentlistasync)                             | ### Overview Gets the user's torrent list. This gives you the needed information to perform other torrent actions. This information only gets updated every 600 seconds, or when the _Request Update On Torrent_ request is sent to the _relay API_. #### Download States: - "downloading" -\> The torrent is currently downloading. - "uploading" -\> The torrent is currently seeding. - "stalled (no seeds)" -\> The torrent is trying to download, but there are no seeds connected to download from. - "paused" -\> The torrent is paused. - "completed" -\> The torrent is completely downloaded. Do not use this for download completion status. - "cached" -\> The torrent is cached from the server. - "metaDL" -\> The torrent is downloading metadata from the hoard. - "checkingResumeData" -\> The torrent is checking resumable data. All other statuses are basic qBittorrent states. [Check out here for the full list](<https://github.com/qbittorrent/qBittorrent/wiki/WebUI-API-(qBittorrent-4.1)#torrent-management>). ### Authorization Requires an API key using the Authorization Bearer Header. |
| [GetTorrentCachedAvailabilityAsync](#gettorrentcachedavailabilityasync) | ### Overview Takes in a list of comma separated torrent hashes and checks if the torrent is cached. This endpoint only gets a max of around 100 at a time, due to http limits in queries. If you want to do more, you can simply do more hash queries. Such as: `?hash=XXXX&hash=XXXX&hash=XXXX` or `?hash=XXXX,XXXX&hash=XXXX&hash=XXXX,XXXX` and this will work too. Performance is very fast. Less than 1 second per 100. Time is approximately O(log n) time for those interested in taking it to its max. That is without caching as well. This endpoint stores a cache for an hour. You may also pass a `format` parameter with the format you want the data in. Options are either `object` or `list`. You can view examples of both below. ### Authorization Requires an API key using the Authorization Bearer Header.                                                                                                                                                                                                                                                                                         |
| [ExportTorrentDataAsync](#exporttorrentdataasync)                       | ### Overview Exports the magnet or torrent file. Requires a type to be passed. If type is **magnet**, it will return a JSON response with the magnet as a string in the _data_ key. If type is **file**, it will return a bittorrent file as a download. Not compatible with cached downloads. ### Authorization Requires an API key using the Authorization Bearer Header.                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                             |
| [GetTorrentInfoAsync](#gettorrentinfoasync)                             | ### Overview A general route that allows you to give a hash, and TorBox will return data about the torrent. This data is retrieved from the Bittorrent network, so expect it to take some time. If the request goes longer than 10 seconds, TorBox will cancel it. You can adjust this if you like, but the default is 10 seconds. This route is cached as well, so subsequent requests will be instant. ### Authorization None required.                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                               |
| [GetTorrentInfo1Async](#gettorrentinfo1async)                           | ### Overview Same as the GET route, but allows posting data such as magnet, and torrent files. Hashes will have precedence over magnets, and magnets will have precedence over torrent files. Only proper torrent files are accepted. At least one of hash, magnet, or torrent file is required. A general route that allows you to give a hash, and TorBox will return data about the torrent. This data is retrieved from the Bittorrent network, so expect it to take some time. If the request goes longer than 10 seconds, TorBox will cancel it. You can adjust this if you like, but the default is 10 seconds. This route is cached as well, so subsequent requests will be instant. ### Authorization None required.                                                                                                                                                                                                                                                                                                                                                                                           |

## CreateTorrentAsync

### Overview Creates a torrent under your account. Simply send **either** a magnet link, or a torrent file. Once they have been checked, they will begin downloading assuming your account has available active download slots, and they aren't too large. ### Authorization Requires an API key using the Authorization Bearer Header.

- HTTP Method: `POST`
- Endpoint: `/{api_version}/api/torrents/createtorrent`

**Parameters**

| Name       | Type                 | Required | Description       |
| :--------- | :------------------- | :------- | :---------------- |
| input      | CreateTorrentRequest | ❌       | The request body. |
| apiVersion | string               | ✅       |                   |

**Return Type**

`CreateTorrentOkResponse`

**Example Usage Code Snippet**

```csharp
using TorboxApi;
using TorboxApi.Config;
using TorboxApi.Models;
using Environment = TorboxApi.Http.Environment;

var config = new TorboxApiConfig{
    Environment = Environment.Default
};

var client = new TorboxApiClient(config);

var input = new CreateTorrentRequest("boolean", "boolean", new byte[] {}, "{{magnet_link}}", "string", "integer");

var response = await client.Torrents.CreateTorrentAsync(input, "api_version");

Console.WriteLine(response);
```

## ControlTorrentAsync

### Overview Controls a torrent. By sending the torrent's ID and the type of operation you want to perform, it will send that request to the torrent client. Operations are either: - **Reannounce** `reannounces the torrent to get new peers` - **Delete** `deletes the torrent from the client and your account permanently` - **Resume** `resumes a paused torrent` ### Authorization Requires an API key using the Authorization Bearer Header.

- HTTP Method: `POST`
- Endpoint: `/{api_version}/api/torrents/controltorrent`

**Parameters**

| Name       | Type   | Required | Description       |
| :--------- | :----- | :------- | :---------------- |
| input      | object | ❌       | The request body. |
| apiVersion | string | ✅       |                   |

**Return Type**

`ControlTorrentOkResponse`

**Example Usage Code Snippet**

```csharp
using TorboxApi;
using TorboxApi.Config;
using Environment = TorboxApi.Http.Environment;

var config = new TorboxApiConfig{
    Environment = Environment.Default
};

var client = new TorboxApiClient(config);

var response = await client.Torrents.ControlTorrentAsync(new object {}, "api_version");

Console.WriteLine(response);
```

## RequestDownloadLinkAsync

### Overview Requests the download link from the server. Because downloads are metered, TorBox cannot afford to allow free access to the links directly. This endpoint opens the link for 3 hours for downloads. Once a download is started, the user has nearly unlilimited time to download the file. The 1 hour time limit is simply for starting downloads. This prevents long term link sharing. ### Permalinks Instead of generating many CDN urls by requesting this endpoint, you can instead create a permalink such as: `https://api.torbox.app/v1/api/torrents/requestdl?token=APIKEY&torrent_id=NUMBER&file_id=NUMBER&redirect=true` and when a user clicks on it, it will automatically redirect them to the CDN link. This saves requests and doesn't abuse the API. Use this method rather than saving CDN links as they are not permanent. To invalidate these permalinks, simply reset your API token or delete the item from your dashboard. ### Authorization Requires an API key as a parameter for the `token` parameter.

- HTTP Method: `GET`
- Endpoint: `/{api_version}/api/torrents/requestdl`

**Parameters**

| Name       | Type   | Required | Description                                                                                                                                   |
| :--------- | :----- | :------- | :-------------------------------------------------------------------------------------------------------------------------------------------- |
| apiVersion | string | ✅       |                                                                                                                                               |
| token      | string | ❌       | Your API Key                                                                                                                                  |
| torrentId  | string | ❌       | The torrent's ID that you want to download                                                                                                    |
| fileId     | string | ❌       | The files's ID that you want to download                                                                                                      |
| zipLink    | string | ❌       | If you want a zip link. Required if no file_id. Takes precedence over file_id if both are given.                                              |
| userIp     | string | ❌       | The user's IP to determine the closest CDN. Optional.                                                                                         |
| redirect   | string | ❌       | If you want to redirect the user to the CDN link. This is useful for creating permalinks so that you can just make this request URL the link. |

**Return Type**

`RequestDownloadLinkOkResponse`

**Example Usage Code Snippet**

```csharp
using TorboxApi;
using TorboxApi.Config;
using Environment = TorboxApi.Http.Environment;

var config = new TorboxApiConfig{
    Environment = Environment.Default
};

var client = new TorboxApiClient(config);

var response = await client.Torrents.RequestDownloadLinkAsync("api_version", "{{api_key}}", "{{torrent_id}}", "{{torrent_file_id}}", "boolean", "string", "boolean");

Console.WriteLine(response);
```

## GetTorrentListAsync

### Overview Gets the user's torrent list. This gives you the needed information to perform other torrent actions. This information only gets updated every 600 seconds, or when the _Request Update On Torrent_ request is sent to the _relay API_. #### Download States: - "downloading" -\> The torrent is currently downloading. - "uploading" -\> The torrent is currently seeding. - "stalled (no seeds)" -\> The torrent is trying to download, but there are no seeds connected to download from. - "paused" -\> The torrent is paused. - "completed" -\> The torrent is completely downloaded. Do not use this for download completion status. - "cached" -\> The torrent is cached from the server. - "metaDL" -\> The torrent is downloading metadata from the hoard. - "checkingResumeData" -\> The torrent is checking resumable data. All other statuses are basic qBittorrent states. [Check out here for the full list](<https://github.com/qbittorrent/qBittorrent/wiki/WebUI-API-(qBittorrent-4.1)#torrent-management>). ### Authorization Requires an API key using the Authorization Bearer Header.

- HTTP Method: `GET`
- Endpoint: `/{api_version}/api/torrents/mylist`

**Parameters**

| Name        | Type   | Required | Description                                                                                                                                                                                   |
| :---------- | :----- | :------- | :-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| apiVersion  | string | ✅       |                                                                                                                                                                                               |
| bypassCache | string | ❌       | Allows you to bypass the cached data, and always get fresh information. Useful if constantly querying for fresh download stats. Otherwise, we request that you save our database a few calls. |
| id          | string | ❌       | Determines the torrent requested, will return an object rather than list. Optional.                                                                                                           |
| offset      | string | ❌       | Determines the offset of items to get from the database. Default is 0. Optional.                                                                                                              |
| limit       | string | ❌       | Determines the number of items to recieve per request. Default is 1000. Optional.                                                                                                             |

**Return Type**

`GetTorrentListOkResponse`

**Example Usage Code Snippet**

```csharp
using TorboxApi;
using TorboxApi.Config;
using Environment = TorboxApi.Http.Environment;

var config = new TorboxApiConfig{
    Environment = Environment.Default
};

var client = new TorboxApiClient(config);

var response = await client.Torrents.GetTorrentListAsync("api_version", "boolean", "integer", "integer", "integer");

Console.WriteLine(response);
```

## GetTorrentCachedAvailabilityAsync

### Overview Takes in a list of comma separated torrent hashes and checks if the torrent is cached. This endpoint only gets a max of around 100 at a time, due to http limits in queries. If you want to do more, you can simply do more hash queries. Such as: `?hash=XXXX&hash=XXXX&hash=XXXX` or `?hash=XXXX,XXXX&hash=XXXX&hash=XXXX,XXXX` and this will work too. Performance is very fast. Less than 1 second per 100. Time is approximately O(log n) time for those interested in taking it to its max. That is without caching as well. This endpoint stores a cache for an hour. You may also pass a `format` parameter with the format you want the data in. Options are either `object` or `list`. You can view examples of both below. ### Authorization Requires an API key using the Authorization Bearer Header.

- HTTP Method: `GET`
- Endpoint: `/{api_version}/api/torrents/checkcached`

**Parameters**

| Name       | Type   | Required | Description                                                                                                                                              |
| :--------- | :----- | :------- | :------------------------------------------------------------------------------------------------------------------------------------------------------- |
| apiVersion | string | ✅       |                                                                                                                                                          |
| hash       | string | ❌       | The list of torrent hashes you want to check. Comma seperated.                                                                                           |
| format     | string | ❌       | Format you want the data in. Acceptable is either "object" or "list". List is the most performant option as it doesn't require modification of the list. |
| listFiles  | string | ❌       | Allows you to list the files found inside the cached data.                                                                                               |

**Return Type**

`GetTorrentCachedAvailabilityOkResponse`

**Example Usage Code Snippet**

```csharp
using TorboxApi;
using TorboxApi.Config;
using Environment = TorboxApi.Http.Environment;

var config = new TorboxApiConfig{
    Environment = Environment.Default
};

var client = new TorboxApiClient(config);

var response = await client.Torrents.GetTorrentCachedAvailabilityAsync("api_version", "{{torrent_hash}}", "object", "boolean");

Console.WriteLine(response);
```

## ExportTorrentDataAsync

### Overview Exports the magnet or torrent file. Requires a type to be passed. If type is **magnet**, it will return a JSON response with the magnet as a string in the _data_ key. If type is **file**, it will return a bittorrent file as a download. Not compatible with cached downloads. ### Authorization Requires an API key using the Authorization Bearer Header.

- HTTP Method: `GET`
- Endpoint: `/{api_version}/api/torrents/exportdata`

**Parameters**

| Name       | Type   | Required | Description                                                                                                                                                                                                             |
| :--------- | :----- | :------- | :---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| apiVersion | string | ✅       |                                                                                                                                                                                                                         |
| torrentId  | string | ❌       | The torrent's ID.                                                                                                                                                                                                       |
| type\_     | string | ❌       | Either "magnet" or "file". Tells how the API what to get, and what to respond as. If magnet, it returns a JSON response with the magnet as a string in the data key. If file, it responds with a torrent file download. |

**Return Type**

`ExportTorrentDataOkResponse`

**Example Usage Code Snippet**

```csharp
using TorboxApi;
using TorboxApi.Config;
using Environment = TorboxApi.Http.Environment;

var config = new TorboxApiConfig{
    Environment = Environment.Default
};

var client = new TorboxApiClient(config);

var response = await client.Torrents.ExportTorrentDataAsync("api_version", "int", "str");

Console.WriteLine(response);
```

## GetTorrentInfoAsync

### Overview A general route that allows you to give a hash, and TorBox will return data about the torrent. This data is retrieved from the Bittorrent network, so expect it to take some time. If the request goes longer than 10 seconds, TorBox will cancel it. You can adjust this if you like, but the default is 10 seconds. This route is cached as well, so subsequent requests will be instant. ### Authorization None required.

- HTTP Method: `GET`
- Endpoint: `/{api_version}/api/torrents/torrentinfo`

**Parameters**

| Name       | Type   | Required | Description                                                                                                                                                                                          |
| :--------- | :----- | :------- | :--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| apiVersion | string | ✅       |                                                                                                                                                                                                      |
| hash       | string | ❌       | Hash of the torrent you want to get info for. This is required.                                                                                                                                      |
| timeout    | string | ❌       | The amount of time you want TorBox to search for the torrent on the Bittorrent network. If the number of seeders is low or even zero, this value may be helpful to move up. Default is 10. Optional. |

**Return Type**

`GetTorrentInfoOkResponse`

**Example Usage Code Snippet**

```csharp
using TorboxApi;
using TorboxApi.Config;
using Environment = TorboxApi.Http.Environment;

var config = new TorboxApiConfig{
    Environment = Environment.Default
};

var client = new TorboxApiClient(config);

var response = await client.Torrents.GetTorrentInfoAsync("api_version", "string", "integer");

Console.WriteLine(response);
```

## GetTorrentInfo1Async

### Overview Same as the GET route, but allows posting data such as magnet, and torrent files. Hashes will have precedence over magnets, and magnets will have precedence over torrent files. Only proper torrent files are accepted. At least one of hash, magnet, or torrent file is required. A general route that allows you to give a hash, and TorBox will return data about the torrent. This data is retrieved from the Bittorrent network, so expect it to take some time. If the request goes longer than 10 seconds, TorBox will cancel it. You can adjust this if you like, but the default is 10 seconds. This route is cached as well, so subsequent requests will be instant. ### Authorization None required.

- HTTP Method: `POST`
- Endpoint: `/{api_version}/api/torrents/torrentinfo`

**Parameters**

| Name       | Type                   | Required | Description       |
| :--------- | :--------------------- | :------- | :---------------- |
| input      | GetTorrentInfo1Request | ❌       | The request body. |
| apiVersion | string                 | ✅       |                   |

**Return Type**

`GetTorrentInfo1OkResponse`

**Example Usage Code Snippet**

```csharp
using TorboxApi;
using TorboxApi.Config;
using TorboxApi.Models;
using Environment = TorboxApi.Http.Environment;

var config = new TorboxApiConfig{
    Environment = Environment.Default
};

var client = new TorboxApiClient(config);

var input = new GetTorrentInfo1Request("dd8255ecdc7ca55fb0bbf81323d87062db1f6d1c");

var response = await client.Torrents.GetTorrentInfo1Async(input, "api_version");

Console.WriteLine(response);
```
