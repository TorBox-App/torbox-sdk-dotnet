# NotificationsService

A list of all methods in the `NotificationsService` service. Click on the method name to view detailed information about that method.

| Methods                                                       | Description                                                                                                                                                                                                                                                                                                                                           |
| :------------------------------------------------------------ | :---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| [GetRssNotificationFeedAsync](#getrssnotificationfeedasync)   | ### Overview Gets your notifications in an RSS Feed which allows you to use them with RSS Feed readers or notification services that can take RSS Feeds and listen to updates. As soon as a notification goes to your account, it will be added to your feed. ### Authorization Requires an API key using as a query parameter using the `token` key. |
| [GetNotificationFeedAsync](#getnotificationfeedasync)         | ### Overview Gets your notifications in a JSON object that is easily parsable compared to the RSS Feed. Gives all the same data as the RSS Feed. ### Authorization Requires an API key using the Authorization Bearer Header.                                                                                                                         |
| [ClearAllNotificationsAsync](#clearallnotificationsasync)     | ### Overview Marks all of your notifications as read and deletes them permanently. ### Authorization Requires an API key using the Authorization Bearer Header.                                                                                                                                                                                       |
| [ClearSingleNotificationAsync](#clearsinglenotificationasync) | ### Overview Marks a single notification as read and permanently deletes it from your notifications. Requires a `notification_id` which can be found by getting your notification feed. ### Authorization Requires an API key using the Authorization Bearer Header.                                                                                  |
| [SendTestNotificationAsync](#sendtestnotificationasync)       | ### Overview Sends a test notification to all enabled notification types. This can be useful for validating setups. No need for any body in this request. ### Authorization Requires an API key using the Authorization Bearer Header.                                                                                                                |

## GetRssNotificationFeedAsync

### Overview Gets your notifications in an RSS Feed which allows you to use them with RSS Feed readers or notification services that can take RSS Feeds and listen to updates. As soon as a notification goes to your account, it will be added to your feed. ### Authorization Requires an API key using as a query parameter using the `token` key.

- HTTP Method: `GET`
- Endpoint: `/{api_version}/api/notifications/rss`

**Parameters**

| Name       | Type   | Required | Description |
| :--------- | :----- | :------- | :---------- |
| apiVersion | string | ✅       |             |
| token      | string | ❌       |             |

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

var response = await client.Notifications.GetRssNotificationFeedAsync("api_version", "{{api_key}}");

Console.WriteLine(response);
```

## GetNotificationFeedAsync

### Overview Gets your notifications in a JSON object that is easily parsable compared to the RSS Feed. Gives all the same data as the RSS Feed. ### Authorization Requires an API key using the Authorization Bearer Header.

- HTTP Method: `GET`
- Endpoint: `/{api_version}/api/notifications/mynotifications`

**Parameters**

| Name       | Type   | Required | Description |
| :--------- | :----- | :------- | :---------- |
| apiVersion | string | ✅       |             |

**Return Type**

`GetNotificationFeedOkResponse`

**Example Usage Code Snippet**

```csharp
using TorboxApi;
using TorboxApi.Config;
using Environment = TorboxApi.Http.Environment;

var config = new TorboxApiConfig{
    Environment = Environment.Default
};

var client = new TorboxApiClient(config);

var response = await client.Notifications.GetNotificationFeedAsync("api_version");

Console.WriteLine(response);
```

## ClearAllNotificationsAsync

### Overview Marks all of your notifications as read and deletes them permanently. ### Authorization Requires an API key using the Authorization Bearer Header.

- HTTP Method: `POST`
- Endpoint: `/{api_version}/api/notifications/clear`

**Parameters**

| Name       | Type   | Required | Description |
| :--------- | :----- | :------- | :---------- |
| apiVersion | string | ✅       |             |

**Example Usage Code Snippet**

```csharp
using TorboxApi;
using TorboxApi.Config;
using Environment = TorboxApi.Http.Environment;

var config = new TorboxApiConfig{
    Environment = Environment.Default
};

var client = new TorboxApiClient(config);

await client.Notifications.ClearAllNotificationsAsync("api_version");
```

## ClearSingleNotificationAsync

### Overview Marks a single notification as read and permanently deletes it from your notifications. Requires a `notification_id` which can be found by getting your notification feed. ### Authorization Requires an API key using the Authorization Bearer Header.

- HTTP Method: `POST`
- Endpoint: `/{api_version}/api/notifications/clear/{notification_id}`

**Parameters**

| Name           | Type   | Required | Description |
| :------------- | :----- | :------- | :---------- |
| apiVersion     | string | ✅       |             |
| notificationId | string | ✅       |             |

**Example Usage Code Snippet**

```csharp
using TorboxApi;
using TorboxApi.Config;
using Environment = TorboxApi.Http.Environment;

var config = new TorboxApiConfig{
    Environment = Environment.Default
};

var client = new TorboxApiClient(config);

await client.Notifications.ClearSingleNotificationAsync("api_version", "notification_id");
```

## SendTestNotificationAsync

### Overview Sends a test notification to all enabled notification types. This can be useful for validating setups. No need for any body in this request. ### Authorization Requires an API key using the Authorization Bearer Header.

- HTTP Method: `POST`
- Endpoint: `/{api_version}/api/notifications/test`

**Parameters**

| Name       | Type   | Required | Description |
| :--------- | :----- | :------- | :---------- |
| apiVersion | string | ✅       |             |

**Example Usage Code Snippet**

```csharp
using TorboxApi;
using TorboxApi.Config;
using Environment = TorboxApi.Http.Environment;

var config = new TorboxApiConfig{
    Environment = Environment.Default
};

var client = new TorboxApiClient(config);

await client.Notifications.SendTestNotificationAsync("api_version");
```
