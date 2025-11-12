# AI Agent Guidelines for Xtream.Client

This document provides instructions and context for AI agents working on the Xtream.Client project.

## Project Overview

Xtream.Client is a .NET 9 library that provides a client for interacting with Xtream-based IPTV APIs. The library focuses on simplicity, reliability, and extensibility.

## Architecture

### Core Components

1. **XtreamClient** - Main client class that provides methods for interacting with Xtream APIs
2. **IHttpClientFactory** - Interface for creating HttpClient instances
3. **DefaultHttpClientFactory** - Default implementation with User-Agent support
4. **Connection Factories** - Classes for creating connection information (URL-based, basic auth)
5. **Entities** - Data models representing API responses

### Key Design Patterns

- **Factory Pattern**: Used for HttpClient creation and connection information setup
- **Dependency Injection**: HttpClient factory is injected into XtreamClient
- **Disposable Pattern**: Proper resource cleanup for HttpClient instances

## Code Conventions

### C# Style

- Use latest C# language features (project targets .NET 9)
- Follow Microsoft's C# coding conventions
- Use XML documentation comments for public APIs
- Prefer `readonly` fields where applicable
- Use `async/await` for asynchronous operations

### Naming Conventions

- Classes: PascalCase (e.g., `DefaultHttpClientFactory`)
- Methods: PascalCase (e.g., `GetPanelAsync`)
- Private fields: _camelCase with underscore prefix (e.g., `_userAgent`)
- Parameters: camelCase (e.g., `userAgent`)
- Constants: PascalCase (e.g., `DefaultUserAgent`)

## Testing Guidelines

### Test Framework

- Uses **xUnit** for unit testing
- Uses **Moq** for mocking dependencies
- Uses **Shouldly** for assertions

### Test Naming Convention

```csharp
[Fact]
public void ClassName_Should_ExpectedBehavior_When_Condition()
{
    // Arrange
    
    // Act
    
    // Assert
}
```

### Test Coverage

- All public methods should have unit tests
- Test both success and failure scenarios
- Test edge cases (null, empty, invalid input)
- Use `[Theory]` and `[InlineData]` for parameterized tests

## HttpClient Factory Pattern

### User-Agent Configuration

The `DefaultHttpClientFactory` supports configurable User-Agent headers to prevent 401 errors from providers:

```csharp
public class DefaultHttpClientFactory : IHttpClientFactory
{
    private readonly string _userAgent;
    
    public DefaultHttpClientFactory(string userAgent = "XtreamClient/1.0")
    {
        _userAgent = userAgent;
    }
    
    public HttpClient Create()
    {
        var client = new HttpClient();
        if (!string.IsNullOrEmpty(_userAgent))
        {
            client.DefaultRequestHeaders.Add("User-Agent", _userAgent);
        }
        return client;
    }
}
```

### Important Considerations

1. **Default User-Agent**: Always use `"XtreamClient/1.0"` as the default
2. **Null Handling**: Allow null/empty User-Agent for flexibility
3. **Backward Compatibility**: Existing code should work without changes
4. **Static Default Property**: `DefaultHttpClientFactory.Default` provides a singleton instance

## Common Tasks

### Adding a New API Method

1. Add method signature to `IXtreamClient` interface
2. Implement method in `XtreamClient` class
3. Add corresponding entity/model if needed
4. Create unit tests for the new method
5. Update README.md with usage example

### Modifying HttpClient Behavior

1. Consider if change belongs in `DefaultHttpClientFactory` or custom implementation
2. Maintain backward compatibility
3. Update tests to cover new behavior
4. Document changes in README.md

### Adding New Dependencies

1. Check for security vulnerabilities using `gh-advisory-database` tool
2. Add to appropriate .csproj file
3. Update package references consistently across projects
4. Document new dependencies if they affect public API

## Build and Test

### Build Commands

```bash
# Restore dependencies
dotnet restore

# Build solution
dotnet build

# Build in Release mode
dotnet build --configuration Release
```

### Test Commands

```bash
# Run all tests
dotnet test

# Run tests with coverage
dotnet test -p:CollectCoverage=true -p:CoverletOutputFormat=opencover
```

### CI/CD

The project uses Azure Pipelines for continuous integration. The pipeline:
- Runs on Ubuntu latest with .NET 9 SDK
- Executes `dotnet restore`, `dotnet build`, and `dotnet test`
- Generates code coverage reports
- Publishes NuGet packages on tagged releases

## Security Considerations

1. **Never commit secrets** - No API keys, passwords, or credentials in code
2. **Validate input** - Check for null/empty values in public APIs
3. **Use HTTPS** - Xtream APIs should use secure connections
4. **Dispose resources** - Properly dispose HttpClient and related resources
5. **Dependency scanning** - Check for known vulnerabilities in dependencies

## Common Issues and Solutions

### Issue: 401 Unauthorized Errors

**Solution**: Ensure User-Agent header is set. Use `DefaultHttpClientFactory` with appropriate User-Agent:

```csharp
var factory = new DefaultHttpClientFactory("CustomAgent/1.0");
var client = new XtreamClient(factory);
```

### Issue: Connection Timeout

**Solution**: Implement custom `IHttpClientFactory` with appropriate timeout:

```csharp
public class CustomHttpClientFactory : IHttpClientFactory
{
    public HttpClient Create()
    {
        var client = new HttpClient();
        client.Timeout = TimeSpan.FromSeconds(60);
        return client;
    }
}
```

### Issue: Test Runtime Errors

**Solution**: Ensure correct .NET runtime is installed. Tests target .NET 9.

## Versioning and Releases

- Follow semantic versioning (MAJOR.MINOR.PATCH)
- Update version in .csproj before release
- Create git tags for releases
- NuGet packages are automatically published from tagged commits

## Documentation Standards

### XML Documentation

All public APIs must have XML documentation:

```csharp
/// <summary>
/// Creates a new HttpClient instance with configured User-Agent header.
/// </summary>
/// <returns>A configured HttpClient instance.</returns>
public HttpClient Create()
{
    // Implementation
}
```

### README Updates

When adding features:
- Add usage examples
- Update feature list
- Document breaking changes
- Keep examples simple and clear

## Resources

- [Xtream API Documentation](https://xtream-codes.com/api)
- [.NET 9 Documentation](https://learn.microsoft.com/en-us/dotnet/core/whats-new/dotnet-9/)
- [xUnit Documentation](https://xunit.net/)
- [Moq Documentation](https://github.com/moq/moq4)

## Questions and Support

For questions about the codebase or architecture decisions, refer to:
- Existing unit tests for examples
- Git history for context on changes
- GitHub issues for known problems and solutions

---

**Last Updated**: 2025-11-12  
**Maintained By**: @Fazzani
