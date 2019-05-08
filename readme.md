# Xtream Client

[![Build Status](https://dev.azure.com/henifazzani/Xtream.Client/_apis/build/status/Xtream.Client-ASP.NET%20Core-CI?branchName=master)](https://dev.azure.com/henifazzani/Xtream.Client/_build/latest?definitionId=16&branchName=master)

Xtream .net standard client for Xtream Api

## Installation

```sh
 dotnet add package Xtream.Client
 ```

## Examples

```csharp
 using(var xtreamClient = new XtreamClient())
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