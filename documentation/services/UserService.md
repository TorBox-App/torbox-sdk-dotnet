# UserService

A list of all methods in the `UserService` service. Click on the method name to view detailed information about that method.

| Methods                                                 | Description                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                            |
| :------------------------------------------------------ | :--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| [RefreshApiTokenAsync](#refreshapitokenasync)           | ### Overview If you want a new API token, or your old one has been compromised, you may request a new one. If you happen to forget the token, go the [TorBox settings page ](https://torbox.app/settings) and copy the current one. If this still doesn't work, you may contact us at our support email for a new one. ### Authorization Requires an API key using the Authorization Bearer Header as well as passing the `session_token` from the website to be passed in the body. You can find the `session_token` in the localStorage of your browser on any TorBox.app page under the key `torbox_session_token`. This is a temporary token that only lasts for 1 hour, which is why it is used here to verify the identity of a user as well as their API token. |
| [GetUserDataAsync](#getuserdataasync)                   | ### Overview Gets a users account data and information. ### Plans `0` is Free plan `1` is Essential plan (_$3 plan_) `2` is Pro plan (_$10 plan_) `3` is Standard plan (_$5 plan_) ### Authorization Requires an API key using the Authorization Bearer Header.                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                        |
| [AddReferralToAccountAsync](#addreferraltoaccountasync) | ### Overview Automatically adds a referral code to the user's account. This can be used for developers to automatically add their referral to user's accounts who use their service. This will not override any referral a user already has. If they already have one, then it cannot be changed using this endpoint. It can only be done by the user on the [website](https://torbox.app/subscription). ### Authorization Requires an API key using the Authorization Bearer Header. Use the user's API key, not your own.                                                                                                                                                                                                                                            |
| [GetConfirmationCodeAsync](#getconfirmationcodeasync)   | ### Overview Requests a 6 digit code to be sent to the user's email for verification. Used to verify a user actually wants to perform a potentially dangerous action. ### Authorization Requires an API key using the Authorization Bearer Header.                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                     |

## RefreshApiTokenAsync

### Overview If you want a new API token, or your old one has been compromised, you may request a new one. If you happen to forget the token, go the [TorBox settings page ](https://torbox.app/settings) and copy the current one. If this still doesn't work, you may contact us at our support email for a new one. ### Authorization Requires an API key using the Authorization Bearer Header as well as passing the `session_token` from the website to be passed in the body. You can find the `session_token` in the localStorage of your browser on any TorBox.app page under the key `torbox_session_token`. This is a temporary token that only lasts for 1 hour, which is why it is used here to verify the identity of a user as well as their API token.

- HTTP Method: `POST`
- Endpoint: `/{api_version}/api/user/refreshtoken`

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

await client.User.RefreshApiTokenAsync(new object {}, "api_version");
```

## GetUserDataAsync

### Overview Gets a users account data and information. ### Plans `0` is Free plan `1` is Essential plan (_$3 plan_) `2` is Pro plan (_$10 plan_) `3` is Standard plan (_$5 plan_) ### Authorization Requires an API key using the Authorization Bearer Header.

- HTTP Method: `GET`
- Endpoint: `/{api_version}/api/user/me`

**Parameters**

| Name       | Type   | Required | Description                           |
| :--------- | :----- | :------- | :------------------------------------ |
| apiVersion | string | ✅       |                                       |
| settings   | string | ❌       | Allows you to retrieve user settings. |

**Return Type**

`GetUserDataOkResponse`

**Example Usage Code Snippet**

```csharp
using TorboxApi;
using TorboxApi.Config;
using Environment = TorboxApi.Http.Environment;

var config = new TorboxApiConfig{
    Environment = Environment.Default
};

var client = new TorboxApiClient(config);

var response = await client.User.GetUserDataAsync("api_version", "boolean");

Console.WriteLine(response);
```

## AddReferralToAccountAsync

### Overview Automatically adds a referral code to the user's account. This can be used for developers to automatically add their referral to user's accounts who use their service. This will not override any referral a user already has. If they already have one, then it cannot be changed using this endpoint. It can only be done by the user on the [website](https://torbox.app/subscription). ### Authorization Requires an API key using the Authorization Bearer Header. Use the user's API key, not your own.

- HTTP Method: `POST`
- Endpoint: `/{api_version}/api/user/addreferral`

**Parameters**

| Name       | Type   | Required | Description                    |
| :--------- | :----- | :------- | :----------------------------- |
| apiVersion | string | ✅       |                                |
| referral   | string | ❌       | A referral code. Must be UUID. |

**Return Type**

`AddReferralToAccountOkResponse`

**Example Usage Code Snippet**

```csharp
using TorboxApi;
using TorboxApi.Config;
using Environment = TorboxApi.Http.Environment;

var config = new TorboxApiConfig{
    Environment = Environment.Default
};

var client = new TorboxApiClient(config);

var response = await client.User.AddReferralToAccountAsync("api_version", "{{referral_code}}");

Console.WriteLine(response);
```

## GetConfirmationCodeAsync

### Overview Requests a 6 digit code to be sent to the user's email for verification. Used to verify a user actually wants to perform a potentially dangerous action. ### Authorization Requires an API key using the Authorization Bearer Header.

- HTTP Method: `GET`
- Endpoint: `/{api_version}/api/user/getconfirmation`

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

await client.User.GetConfirmationCodeAsync("api_version");
```
