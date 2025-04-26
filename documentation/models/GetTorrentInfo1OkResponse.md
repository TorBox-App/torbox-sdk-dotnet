# GetTorrentInfo1OkResponse

**Properties**

| Name    | Type                          | Required | Description |
| :------ | :---------------------------- | :------- | :---------- |
| Data    | GetTorrentInfo1OkResponseData | ❌       |             |
| Detail  | string                        | ❌       |             |
| Error   | object                        | ❌       |             |
| Success | bool                          | ❌       |             |

# GetTorrentInfo1OkResponseData

**Properties**

| Name     | Type             | Required | Description |
| :------- | :--------------- | :------- | :---------- |
| Files    | List<DataFiles3> | ❌       |             |
| Hash     | string           | ❌       |             |
| Name     | string           | ❌       |             |
| Peers    | double           | ❌       |             |
| Seeds    | double           | ❌       |             |
| Size     | double           | ❌       |             |
| Trackers | List<object>     | ❌       |             |

# DataFiles3

**Properties**

| Name | Type   | Required | Description |
| :--- | :----- | :------- | :---------- |
| Name | string | ❌       |             |
| Size | double | ❌       |             |
