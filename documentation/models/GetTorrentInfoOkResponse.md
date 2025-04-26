# GetTorrentInfoOkResponse

**Properties**

| Name    | Type                         | Required | Description |
| :------ | :--------------------------- | :------- | :---------- |
| Data    | GetTorrentInfoOkResponseData | ❌       |             |
| Detail  | string                       | ❌       |             |
| Error   | object                       | ❌       |             |
| Success | bool                         | ❌       |             |

# GetTorrentInfoOkResponseData

**Properties**

| Name     | Type             | Required | Description |
| :------- | :--------------- | :------- | :---------- |
| Files    | List<DataFiles2> | ❌       |             |
| Hash     | string           | ❌       |             |
| Name     | string           | ❌       |             |
| Peers    | double           | ❌       |             |
| Seeds    | double           | ❌       |             |
| Size     | double           | ❌       |             |
| Trackers | List<object>     | ❌       |             |

# DataFiles2

**Properties**

| Name | Type   | Required | Description |
| :--- | :----- | :------- | :---------- |
| Name | string | ❌       |             |
| Size | double | ❌       |             |
