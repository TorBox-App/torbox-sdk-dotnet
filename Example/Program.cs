using TorboxApi;
using TorboxApi.Config;
using Environment = TorboxApi.Http.Environment;

var config = new TorboxApiConfig
{
    Environment = Environment.Default,
    AccessToken = "YOUR_ACCESS_TOKEN",
};

var client = new TorboxApiClient(config);

var response = await client.General.GetUpStatusAsync();

Console.WriteLine(response);
