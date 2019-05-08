# Xtream Client

[![Build Status](https://dev.azure.com/henifazzani/Xtream.Client/_apis/build/status/Xtream.Client-ASP.NET%20Core-CI?branchName=master)](https://dev.azure.com/henifazzani/Xtream.Client/_build/latest?definitionId=16&branchName=master)

Xtream .net standard client for Xtream Api

## Examples

```csharp
 var xtreamClient = new XtreamClient();
 var panelInfo = await xtreamClient.GetPanelAsync(url, CancellationToken.None);
```