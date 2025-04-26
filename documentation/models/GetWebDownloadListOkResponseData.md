# GetWebDownloadListOkResponseData

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
| Error            | string           | ❌       |             |
| Eta              | double           | ❌       |             |
| ExpiresAt        | string           | ❌       |             |
| Files            | List<DataFiles5> | ❌       |             |
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

# DataFiles5

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
