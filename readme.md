# Xtream Client

Xtream .net standard client for Xtream Api

## Examples

```csharp
 var xtreamClient = new XtreamClient();
 var panelInfo = await xtreamClient.GetPanelAsync(url, CancellationToken.None);
```