# IntegrationsService

A list of all methods in the `IntegrationsService` service. Click on the method name to view detailed information about that method.

| Methods                                           | Description                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                         |
| :------------------------------------------------ | :-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| [AuthenticateOauthAsync](#authenticateoauthasync) | ### Overview Allows you to get an authorization token for using the user's account. Callback is located at `/oauth/{provider}/callback` which will verify the token recieved from the OAuth, then redirect you finally to `https://torbox.app/{provider}/success?token={token}&expires_in={expires_in}&expires_at={expires_at}` #### Providers: - "google" -\> Google Drive - "dropbox" -\> Dropbox - "discord" -\> Discord - "onedrive" -\> Azure AD/Microsoft/Onedrive ### Authorization No authorization needed. This is a whitelabel OAuth solution.                                                                                            |
| [QueueGoogleDriveAsync](#queuegoogledriveasync)   | ### Overview Queues a job to upload the specified file or zip to the Google Drive account sent with the `google_token` key. To get this key, either get an OAuth2 token using `/oauth/google` or your own solution. Make sure when creating the OAuth link, you add the scope `https://www.googleapis.com/auth/drive.file` so TorBox has access to the user's Drive. ### Authorization Requires an API key using the Authorization Bearer Header.                                                                                                                                                                                                   |
| [QueuePixeldrainAsync](#queuepixeldrainasync)     | ### Overview Queues a job to upload the specified file or zip to Pixeldrain. ### Authorization Requires an API key using the Authorization Bearer Header.                                                                                                                                                                                                                                                                                                                                                                                                                                                                                           |
| [QueueOnedriveAsync](#queueonedriveasync)         | ### Overview Queues a job to upload the specified file or zip to the OneDrive sent with the `onedrive_token` key. To get this key, either get an OAuth2 token using `/oauth/onedrive` or your own solution. Make sure when creating the OAuth link you use the scope `files.readwrite.all`. This is compatible with all different types of Microsoft accounts. ### Authorization Requires an API key using the Authorization Bearer Header.                                                                                                                                                                                                         |
| [QueueGofileAsync](#queuegofileasync)             | ### Overview Queues a job to upload the specified file or zip to the GoFile account sent with the `gofile_token` _(optional)_. To get this key, login to your GoFile account and go [here](https://gofile.io/myProfile). Copy the **Account API Token**. This is what you will use as the `gofile_token`, if you choose to use it. If you don't use an Account API Token, GoFile will simply create an anonymous file. This file will expire after inactivity. ### Authorization Requires an API key using the Authorization Bearer Header.                                                                                                         |
| [Queue1fichierAsync](#queue1fichierasync)         | ### Overview Queues a job to upload the specified file or zip to the 1Fichier account sent with the `onefichier_token` key (optional). To get this key you must be a Premium or Premium Gold member at 1Fichier. If you are upgraded, [go to the parameters page](https://1fichier.com/console/params.pl), and get an **API Key**. This is what you will use as the `onefichier_token`, if you choose to use it. If you don't use an API Key, 1Fichier will simply create an anonymous file. ### Authorization Requires an API key using the Authorization Bearer Header.                                                                           |
| [GetAllJobsAsync](#getalljobsasync)               | ### Overview Gets all the jobs attached to a user account. This is good for an overall view of the jobs, such as on a dashboard, or something similar. ### Statuses - "pending" -\> Upload is still waiting in the queue. Waiting for spot to upload. - "uploading" -\> Upload is uploading to the proper remote. Progress will be updated as upload continues. - "completed" -\> Upload has successfully been uploaded. Progress will be at 1, and the download URL will be populated. - "failed" -\> The upload has failed. Check the Detail key for information. ### Authorization Requires an API key using the Authorization Bearer Header.    |
| [GetSpecificJobAsync](#getspecificjobasync)       | ### Overview Gets a specifc job using the Job's ID. To get the ID, you will have to Get All Jobs, and get the ID you want. ### Statuses - "pending" -\> Upload is still waiting in the queue. Waiting for spot to upload. - "uploading" -\> Upload is uploading to the proper remote. Progress will be updated as upload continues. - "completed" -\> Upload has successfully been uploaded. Progress will be at 1, and the download URL will be populated. - "failed" -\> The upload has failed. Check the Detail key for information. ### Authorization Requires an API key using the Authorization Bearer Header.                                |
| [CancelSpecificJobAsync](#cancelspecificjobasync) | ### Overview Cancels a job or deletes the job. Cancels while in progess (pending, uploading), or deletes the job any other time. It will delete it from the database completely. ### Authorization Requires an API key using the Authorization Bearer Header.                                                                                                                                                                                                                                                                                                                                                                                       |
| [GetAllJobsByHashAsync](#getalljobsbyhashasync)   | ### Overview Gets all jobs that match a specific hash. Good for checking on specific downloads such as a download page, that could contain a lot of jobs. ### Statuses - "pending" -\> Upload is still waiting in the queue. Waiting for spot to upload. - "uploading" -\> Upload is uploading to the proper remote. Progress will be updated as upload continues. - "completed" -\> Upload has successfully been uploaded. Progress will be at 1, and the download URL will be populated. - "failed" -\> The upload has failed. Check the Detail key for information. ### Authorization Requires an API key using the Authorization Bearer Header. |

## AuthenticateOauthAsync

### Overview Allows you to get an authorization token for using the user's account. Callback is located at `/oauth/{provider}/callback` which will verify the token recieved from the OAuth, then redirect you finally to `https://torbox.app/{provider}/success?token={token}&expires_in={expires_in}&expires_at={expires_at}` #### Providers: - "google" -\> Google Drive - "dropbox" -\> Dropbox - "discord" -\> Discord - "onedrive" -\> Azure AD/Microsoft/Onedrive ### Authorization No authorization needed. This is a whitelabel OAuth solution.

- HTTP Method: `GET`
- Endpoint: `/{api_version}/api/integration/oauth/{provider}`

**Parameters**

| Name       | Type   | Required | Description |
| :--------- | :----- | :------- | :---------- |
| apiVersion | string | ✅       |             |
| provider   | string | ✅       |             |

**Example Usage Code Snippet**

```csharp
using TorboxApi;
using TorboxApi.Config;
using Environment = TorboxApi.Http.Environment;

var config = new TorboxApiConfig{
    Environment = Environment.Default
};

var client = new TorboxApiClient(config);

await client.Integrations.AuthenticateOauthAsync("api_version", "provider");
```

## QueueGoogleDriveAsync

### Overview Queues a job to upload the specified file or zip to the Google Drive account sent with the `google_token` key. To get this key, either get an OAuth2 token using `/oauth/google` or your own solution. Make sure when creating the OAuth link, you add the scope `https://www.googleapis.com/auth/drive.file` so TorBox has access to the user's Drive. ### Authorization Requires an API key using the Authorization Bearer Header.

- HTTP Method: `POST`
- Endpoint: `/{api_version}/api/integration/googledrive`

**Parameters**

| Name       | Type   | Required | Description       |
| :--------- | :----- | :------- | :---------------- |
| input      | object | ❌       | The request body. |
| apiVersion | string | ✅       |                   |

**Example Usage Code Snippet**

```csharp
using TorboxApi;
using TorboxApi.Config;
using Environment = TorboxApi.Http.Environment;

var config = new TorboxApiConfig{
    Environment = Environment.Default
};

var client = new TorboxApiClient(config);

await client.Integrations.QueueGoogleDriveAsync(new object {}, "api_version");
```

## QueuePixeldrainAsync

### Overview Queues a job to upload the specified file or zip to Pixeldrain. ### Authorization Requires an API key using the Authorization Bearer Header.

- HTTP Method: `POST`
- Endpoint: `/{api_version}/api/integration/pixeldrain`

**Parameters**

| Name       | Type   | Required | Description       |
| :--------- | :----- | :------- | :---------------- |
| input      | object | ❌       | The request body. |
| apiVersion | string | ✅       |                   |

**Example Usage Code Snippet**

```csharp
using TorboxApi;
using TorboxApi.Config;
using Environment = TorboxApi.Http.Environment;

var config = new TorboxApiConfig{
    Environment = Environment.Default
};

var client = new TorboxApiClient(config);

await client.Integrations.QueuePixeldrainAsync(new object {}, "api_version");
```

## QueueOnedriveAsync

### Overview Queues a job to upload the specified file or zip to the OneDrive sent with the `onedrive_token` key. To get this key, either get an OAuth2 token using `/oauth/onedrive` or your own solution. Make sure when creating the OAuth link you use the scope `files.readwrite.all`. This is compatible with all different types of Microsoft accounts. ### Authorization Requires an API key using the Authorization Bearer Header.

- HTTP Method: `POST`
- Endpoint: `/{api_version}/api/integration/onedrive`

**Parameters**

| Name       | Type   | Required | Description       |
| :--------- | :----- | :------- | :---------------- |
| input      | object | ❌       | The request body. |
| apiVersion | string | ✅       |                   |

**Example Usage Code Snippet**

```csharp
using TorboxApi;
using TorboxApi.Config;
using Environment = TorboxApi.Http.Environment;

var config = new TorboxApiConfig{
    Environment = Environment.Default
};

var client = new TorboxApiClient(config);

await client.Integrations.QueueOnedriveAsync(new object {}, "api_version");
```

## QueueGofileAsync

### Overview Queues a job to upload the specified file or zip to the GoFile account sent with the `gofile_token` _(optional)_. To get this key, login to your GoFile account and go [here](https://gofile.io/myProfile). Copy the **Account API Token**. This is what you will use as the `gofile_token`, if you choose to use it. If you don't use an Account API Token, GoFile will simply create an anonymous file. This file will expire after inactivity. ### Authorization Requires an API key using the Authorization Bearer Header.

- HTTP Method: `POST`
- Endpoint: `/{api_version}/api/integration/gofile`

**Parameters**

| Name       | Type   | Required | Description       |
| :--------- | :----- | :------- | :---------------- |
| input      | object | ❌       | The request body. |
| apiVersion | string | ✅       |                   |

**Example Usage Code Snippet**

```csharp
using TorboxApi;
using TorboxApi.Config;
using Environment = TorboxApi.Http.Environment;

var config = new TorboxApiConfig{
    Environment = Environment.Default
};

var client = new TorboxApiClient(config);

await client.Integrations.QueueGofileAsync(new object {}, "api_version");
```

## Queue1fichierAsync

### Overview Queues a job to upload the specified file or zip to the 1Fichier account sent with the `onefichier_token` key (optional). To get this key you must be a Premium or Premium Gold member at 1Fichier. If you are upgraded, [go to the parameters page](https://1fichier.com/console/params.pl), and get an **API Key**. This is what you will use as the `onefichier_token`, if you choose to use it. If you don't use an API Key, 1Fichier will simply create an anonymous file. ### Authorization Requires an API key using the Authorization Bearer Header.

- HTTP Method: `POST`
- Endpoint: `/{api_version}/api/integration/1fichier`

**Parameters**

| Name       | Type   | Required | Description       |
| :--------- | :----- | :------- | :---------------- |
| input      | object | ❌       | The request body. |
| apiVersion | string | ✅       |                   |

**Example Usage Code Snippet**

```csharp
using TorboxApi;
using TorboxApi.Config;
using Environment = TorboxApi.Http.Environment;

var config = new TorboxApiConfig{
    Environment = Environment.Default
};

var client = new TorboxApiClient(config);

await client.Integrations.Queue1fichierAsync(new object {}, "api_version");
```

## GetAllJobsAsync

### Overview Gets all the jobs attached to a user account. This is good for an overall view of the jobs, such as on a dashboard, or something similar. ### Statuses - "pending" -\> Upload is still waiting in the queue. Waiting for spot to upload. - "uploading" -\> Upload is uploading to the proper remote. Progress will be updated as upload continues. - "completed" -\> Upload has successfully been uploaded. Progress will be at 1, and the download URL will be populated. - "failed" -\> The upload has failed. Check the Detail key for information. ### Authorization Requires an API key using the Authorization Bearer Header.

- HTTP Method: `GET`
- Endpoint: `/{api_version}/api/integration/jobs`

**Parameters**

| Name       | Type   | Required | Description |
| :--------- | :----- | :------- | :---------- |
| apiVersion | string | ✅       |             |

**Return Type**

`GetAllJobsOkResponse`

**Example Usage Code Snippet**

```csharp
using TorboxApi;
using TorboxApi.Config;
using Environment = TorboxApi.Http.Environment;

var config = new TorboxApiConfig{
    Environment = Environment.Default
};

var client = new TorboxApiClient(config);

var response = await client.Integrations.GetAllJobsAsync("api_version");

Console.WriteLine(response);
```

## GetSpecificJobAsync

### Overview Gets a specifc job using the Job's ID. To get the ID, you will have to Get All Jobs, and get the ID you want. ### Statuses - "pending" -\> Upload is still waiting in the queue. Waiting for spot to upload. - "uploading" -\> Upload is uploading to the proper remote. Progress will be updated as upload continues. - "completed" -\> Upload has successfully been uploaded. Progress will be at 1, and the download URL will be populated. - "failed" -\> The upload has failed. Check the Detail key for information. ### Authorization Requires an API key using the Authorization Bearer Header.

- HTTP Method: `GET`
- Endpoint: `/{api_version}/api/integration/job/{job_id}`

**Parameters**

| Name       | Type   | Required | Description |
| :--------- | :----- | :------- | :---------- |
| apiVersion | string | ✅       |             |
| jobId      | string | ✅       |             |

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

var response = await client.Integrations.GetSpecificJobAsync("api_version", "job_id");

Console.WriteLine(response);
```

## CancelSpecificJobAsync

### Overview Cancels a job or deletes the job. Cancels while in progess (pending, uploading), or deletes the job any other time. It will delete it from the database completely. ### Authorization Requires an API key using the Authorization Bearer Header.

- HTTP Method: `DELETE`
- Endpoint: `/{api_version}/api/integration/job/{job_id}`

**Parameters**

| Name       | Type   | Required | Description |
| :--------- | :----- | :------- | :---------- |
| apiVersion | string | ✅       |             |
| jobId      | string | ✅       |             |

**Example Usage Code Snippet**

```csharp
using TorboxApi;
using TorboxApi.Config;
using Environment = TorboxApi.Http.Environment;

var config = new TorboxApiConfig{
    Environment = Environment.Default
};

var client = new TorboxApiClient(config);

await client.Integrations.CancelSpecificJobAsync("api_version", "job_id");
```

## GetAllJobsByHashAsync

### Overview Gets all jobs that match a specific hash. Good for checking on specific downloads such as a download page, that could contain a lot of jobs. ### Statuses - "pending" -\> Upload is still waiting in the queue. Waiting for spot to upload. - "uploading" -\> Upload is uploading to the proper remote. Progress will be updated as upload continues. - "completed" -\> Upload has successfully been uploaded. Progress will be at 1, and the download URL will be populated. - "failed" -\> The upload has failed. Check the Detail key for information. ### Authorization Requires an API key using the Authorization Bearer Header.

- HTTP Method: `GET`
- Endpoint: `/{api_version}/api/integration/jobs/{hash}`

**Parameters**

| Name       | Type   | Required | Description |
| :--------- | :----- | :------- | :---------- |
| apiVersion | string | ✅       |             |
| hash       | string | ✅       |             |

**Return Type**

`GetAllJobsByHashOkResponse`

**Example Usage Code Snippet**

```csharp
using TorboxApi;
using TorboxApi.Config;
using Environment = TorboxApi.Http.Environment;

var config = new TorboxApiConfig{
    Environment = Environment.Default
};

var client = new TorboxApiClient(config);

var response = await client.Integrations.GetAllJobsByHashAsync("api_version", "hash");

Console.WriteLine(response);
```
