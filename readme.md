# Xtream Client

[![Codacy Badge](https://api.codacy.com/project/badge/Grade/abf760e35131459c8564da39b751c0cb)](https://app.codacy.com/manual/tunisienheni/Xtream.Client?utm_source=github.com&utm_medium=referral&utm_content=Fazzani/Xtream.Client&utm_campaign=Badge_Grade_Dashboard)
[![Build Status](https://dev.azure.com/henifazzani/Xtream.Client/_apis/build/status/Xtream.Client-CI?branchName=master)](https://dev.azure.com/henifazzani/Xtream.Client/_build/latest?definitionId=17&branchName=master)

A .NET 9 client library for Xtream API, providing a simple and efficient way to interact with Xtream-based IPTV services.

## Features

- 🚀 Simple and intuitive API
- 🔧 Configurable HTTP client with User-Agent support
- 📦 .NET 9 compatible
- ✅ Comprehensive test coverage
- 🔐 Support for URL-based and basic authentication

## Requirements

- .NET 9.0 SDK or later

## Installation

```sh
dotnet add package Xtream.Client
```

## Quick Start

### Example 1: Using URL-based authentication

```csharp
using(var xtreamClient = new XtreamClient(DefaultHttpClientFactory.Default))
{
   var connectionInfo = new XtUrlConnectionFactory(url).Create();
   
   // Get Panel Info
   var panelInfo = await xtreamClient.GetPanelAsync(connectionInfo, CancellationToken.None);
   
   // Get Server and user info
   var allInfos = await xtreamClient.GetUserAndServerInfoAsync(connectionInfo, CancellationToken.None);
   
   // Get live streams
   var livestreams = await xtreamClient.GetLiveStreamsAsync(connectionInfo, CancellationToken.None);
   
   // Get VOD streams
   var vods = await xtreamClient.GetVodStreamsAsync(connectionInfo, CancellationToken.None);
}
```

### Example 2: Using basic authentication

```csharp
using(var xtreamClient = new XtreamClient(DefaultHttpClientFactory.Default))
{
   var connectionInfo = new XtBasicConnectionFactory(server, username, password).Create();
   
   // Get Panel Info
   var panelInfo = await xtreamClient.GetPanelAsync(connectionInfo, CancellationToken.None);
   
   // Get Server and user info
   var allInfos = await xtreamClient.GetUserAndServerInfoAsync(connectionInfo, CancellationToken.None);
   
   // Get live streams
   var livestreams = await xtreamClient.GetLiveStreamsAsync(connectionInfo, CancellationToken.None);
   
   // Get VOD streams
   var vods = await xtreamClient.GetVodStreamsAsync(connectionInfo, CancellationToken.None);
}
```

### Example 3: Custom User-Agent configuration

Some providers require specific User-Agent headers. You can customize the User-Agent:

```csharp
// Using a custom User-Agent
var factory = new DefaultHttpClientFactory("MyApp/2.0");
using(var xtreamClient = new XtreamClient(factory))
{
   var connectionInfo = new XtUrlConnectionFactory(url).Create();
   var panelInfo = await xtreamClient.GetPanelAsync(connectionInfo, CancellationToken.None);
}
```

The default User-Agent is `"XtreamClient/1.0"`. This helps prevent 401 errors from providers that require a User-Agent header.

## Advanced Usage

### Custom HttpClient Factory

Implement `IHttpClientFactory` for advanced scenarios like custom headers, proxy configuration, or timeout settings:

```csharp
public class CustomHttpClientFactory : IHttpClientFactory
{
    public HttpClient Create()
    {
        var client = new HttpClient();
        client.DefaultRequestHeaders.Add("User-Agent", "MyCustomAgent/1.0");
        client.Timeout = TimeSpan.FromSeconds(30);
        return client;
    }
}

var xtreamClient = new XtreamClient(new CustomHttpClientFactory());
```

## API Methods

The `XtreamClient` provides the following methods:

- `GetPanelAsync()` - Get complete panel information
- `GetUserAndServerInfoAsync()` - Get server and user details
- `GetLiveStreamsAsync()` - Get all live streams
- `GetLiveStreamsByCategoriesAsync()` - Get live streams filtered by category
- `GetLiveCategoriesAsync()` - Get all live stream categories
- `GetVodStreamsAsync()` - Get all VOD streams
- `GetAllEpgAsync()` - Get electronic program guide data
- `GetShortEpgForStreamAsync()` - Get EPG for a specific stream
- `GetXmltvAsync()` - Get XMLTV format EPG data

## Contributing

Contributions are welcome! Please feel free to submit a Pull Request.

For AI-assisted contributions, see [AGENTS.md](AGENTS.md) for guidelines.

## License

This project is licensed under the MIT License.

## Support

If you encounter any issues or have questions, please open an issue on GitHub.