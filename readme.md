# Xtream Client

[![Codacy Badge](https://api.codacy.com/project/badge/Grade/abf760e35131459c8564da39b751c0cb)](https://app.codacy.com/manual/tunisienheni/Xtream.Client?utm_source=github.com&utm_medium=referral&utm_content=Fazzani/Xtream.Client&utm_campaign=Badge_Grade_Dashboard)
[![Build Status](https://dev.azure.com/henifazzani/Xtream.Client/_apis/build/status/Xtream.Client-CI?branchName=master)](https://dev.azure.com/henifazzani/Xtream.Client/_build/latest?definitionId=17&branchName=master)

Xtream .net standard client for Xtream Api

## Installation

```sh
 dotnet add package Xtream.Client
 ```

## Examples

### Example 1: Xtream Client using an url

```csharp
 using(var xtreamClient = new XtreamClient(new XtUrlConnectionFactory(url)))
 {
   //Get Panel Info
   var panelInfo = await xtreamClient.GetPanelAsync(url, CancellationToken.None);
   
   // Get Server and user info
   var allInfos = await xtreamClient.GetUserAndServerInfoAsync(url, CancellationToken.None);
   
   // Get live streams
   var livestreams = await xtreamClient.GetLiveStreamsAsync(url, CancellationToken.None);
   
   // Get Vod
   var vods = await xtreamClient.GetVodStreamsAsync(url, CancellationToken.None);
 }
```

### Example 2: Xtream Client using a basic authentication

```csharp
 using(var xtreamClient = new XtreamClient(new XtBasicConnectionFactory(server, username, password)))
 {
   //Get Panel Info
   var panelInfo = await xtreamClient.GetPanelAsync(url, CancellationToken.None);
   
   // Get Server and user info
   var allInfos = await xtreamClient.GetUserAndServerInfoAsync(url, CancellationToken.None);
   
   // Get live streams
   var livestreams = await xtreamClient.GetLiveStreamsAsync(url, CancellationToken.None);
   
   // Get Vod
   var vods = await xtreamClient.GetVodStreamsAsync(url, CancellationToken.None);
 }
```