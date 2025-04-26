# GetUsenetListOkResponseData

**Properties**

| Name             | Type             | Required | Description |
| :--------------- | :--------------- | :------- | :---------- |
| Active           | bool             | ❌       |             |
| AuthId           | string           | ❌       |             |
| Availability     | double           | ❌       |             |
| CreatedAt        | string           | ❌       |             |
| DownloadFinished | bool             | ❌       |             |
| DownloadPresent  | bool             | ❌       |             |
| DownloadSpeed    | double           | ❌       |             |
| DownloadState    | string           | ❌       |             |
| Eta              | double           | ❌       |             |
| ExpiresAt        | string           | ❌       |             |
| Files            | List<DataFiles4> | ❌       |             |
| Hash             | string           | ❌       |             |
| Id               | double           | ❌       |             |
| InactiveCheck    | double           | ❌       |             |
| Name             | string           | ❌       |             |
| Progress         | double           | ❌       |             |
| Server           | double           | ❌       |             |
| Size             | double           | ❌       |             |
| TorrentFile      | bool             | ❌       |             |
| UpdatedAt        | string           | ❌       |             |
| UploadSpeed      | double           | ❌       |             |

# DataFiles4

**Properties**

| Name      | Type   | Required | Description |
| :-------- | :----- | :------- | :---------- |
| Id        | double | ❌       |             |
| Md5       | string | ❌       |             |
| Mimetype  | string | ❌       |             |
| Name      | string | ❌       |             |
| S3Path    | string | ❌       |             |
| ShortName | string | ❌       |             |
| Size      | double | ❌       |             |
